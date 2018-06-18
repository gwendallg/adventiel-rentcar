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
     
        /// <summary>
        /// initialise une nouvelle instance la classe
        /// </summary>
        public DatabaseService(IMigrationService migrationService)
        {
            _databasePath = DependencyService.Get<IPlatFormService>().GetLocalFilePath("database.db");
            using (var connection = Connnection())
            {
                migrationService.Migrate(connection);
            }
        }

        /// <inheritdoc />
        public SQLiteConnection Connnection()
        {
            var result = new SQLiteConnection(_databasePath);
            return result;
        }

       
    }
}
