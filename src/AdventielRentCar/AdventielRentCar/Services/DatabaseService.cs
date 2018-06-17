using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventielRentCar.Models;
using SQLite;
using Xamarin.Forms;

namespace AdventielRentCar.Services
{
    /// <summary>
    /// implémenation du service d'accès à la base de données
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        private readonly string _databasePath;
        private readonly IPlatFormService _platFormService;
        private readonly ICryptographyService _cryptographyService;
        private readonly Regex _regex = new Regex(@"V([0-9]+)__(.)*\.sql");

        /// <summary>
        /// initialise une nouvelle instance la classe
        /// </summary>
        public DatabaseService()
        {
            _platFormService = DependencyService.Get<IPlatFormService>();
            _cryptographyService = DependencyService.Get<ICryptographyService>();
            _databasePath = _platFormService.GetLocalFilePath("Database.db3");
            using (var connection = Connnection())
            {
                Migrate(connection);
            }
        }

        /// <inheritdoc />
        public SQLiteConnection Connnection()
        {
            var result = new SQLiteConnection(_databasePath);
            return result;
        }

        /// <summary>
        /// applique la migration 
        /// </summary>
        /// <param name="sqLiteConnection"></param>
        /// <param name="migration"></param>
        /// <param name="script"></param>
        private static List<Migration> ApplyMigration(SQLiteConnection sqLiteConnection, Migration migration, String script)
        {
            sqLiteConnection.BeginTransaction();
            var queries = script.Split(';');
            foreach (var query in queries)
            {
                if(string.IsNullOrWhiteSpace(query)) continue;
                sqLiteConnection.Execute(query);
            }
            migration.Duration = DateTime.Now.Subtract(migration.DateCreation).TotalMilliseconds;
            sqLiteConnection.Insert(migration);
            sqLiteConnection.Commit();
            return sqLiteConnection.Table<Migration>().ToList();
        }

        /// <summary>
        /// essaye de construire une nouvelle migration si celle-ci n'a pas déjà été appliquée à la base de données
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="migrations"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        private Migration TryBuilNewMigration(string resource, IEnumerable<Migration> migrations, out string script)
        {
            var match = _regex.Match(resource);
            // extraction de l'indentifiant de la migration   
            var id = Convert.ToInt32(match.Groups[1].Value, CultureInfo.InvariantCulture);
            // recherche de la migration si elle a déjà été jouée
            var exist = migrations.SingleOrDefault(m =>
                m.Id == id);
            string checkum;
            // désérialisation de resource
            using (var s = GetType().Assembly.GetManifestResourceStream(resource))
            {
                using (var sr = new StreamReader(s ?? throw new InvalidOperationException()))
                {
                    script = sr.ReadToEnd();
                    checkum = _cryptographyService.Md5(script);
                }
            }

            if (exist != null)
            {
                // migration exist et est valide
                if (exist.Checkum == checkum)
                {
                    return null;
                }

                throw new Exception($"invalid Cheksum Migration ${exist.Id}");
            }

            // création de la migration
            return new Migration()
            {
                Id = id,
                Script = match.Value,
                AppVersion = _platFormService.GetApplicationVersionInfo(),
                Platform = _platFormService.GetPlatformInfo(),
                PlatformVersion = _platFormService.GetPlaformInfoVersion(),
                Checkum = checkum,
                DateCreation = DateTime.Now
            };
        }

        /// <summary>
        /// applique les migrations
        /// </summary>
        private void Migrate(SQLiteConnection connection)
        {
            // création de la table des migration si elle n'exite pas
            connection.CreateTable<Migration>();
            // récupération des migrations déjà appliquées en base de données
            var migrations = connection.Table<Migration>().ToList();

            // récupération des migrations appliquables
            var resources = GetType().Assembly.GetManifestResourceNames()
                                     .Where(r => r.StartsWith("AdventielRentCar.Migrations.db",StringComparison.InvariantCulture))
                                     .OrderBy(r => r);
            foreach (var resource in resources)
            {
                var migration = TryBuilNewMigration(resource, migrations, out var script);
                if (migration == null) continue;
                try
                {
                    migrations = ApplyMigration(connection, migration, script);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
