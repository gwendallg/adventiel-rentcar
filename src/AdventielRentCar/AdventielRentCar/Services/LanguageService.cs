using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using AdventielRentCar.Models;
using Xamarin.Forms;

namespace AdventielRentCar.Services
{
    /// <inheritdoc />
    /// <summary>
    /// implémentation du service de langues
    /// </summary>
    public class LanguageService : ILanguageService
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("AdventielRentCar.Resources.AppResource",
                typeof(LanguageService).GetTypeInfo().Assembly);

       
        private readonly IDatabaseService _databaseService;

        /// <inheritdoc />
        public LanguageService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <inheritdoc />
        public List<string> GetAvailableLanguages()
        {
            return new List<string>(new[] {"fr", "en", "es", "de", "it", "ja", "ru"});
        }

        /// <inheritdoc />
        public string Translate(string id, CultureInfo cultureInfo)
        {
            return ResourceManager.GetString(id, cultureInfo);
        }

        /// <inheritdoc />
        public string Translate(string id)
        {
            return Translate(id, Application.Current.GetCurrentCulture());
        }

        /// <inheritdoc />
        public string GetDefaultLanguage()
        {
            using (var connection = _databaseService.Connnection())
            {

                var result = connection.Table<Reference>().Single(r =>
                        r.Domain == Constants.ReferenceDomains.Parameters &&
                        r.Code == Constants.ReferenceCodes.DefaultLanguage)
                    .Value;
                if (!Application.Current.Properties.ContainsKey("CultureInfo"))
                {
                    Application.Current.Properties["CultureInfo"] = CultureInfo.GetCultureInfo(result);
                }

                return result;
            }
        }

        /// <inheritdoc />
        public void SetDefaultLanguage(string language)
        {
            using (var connection = _databaseService.Connnection())
            {
                var reference = connection.Table<Reference>().Single(r =>
                    r.Domain == Constants.ReferenceDomains.Parameters &&
                    r.Code == Constants.ReferenceCodes.DefaultLanguage);
                reference.Value = language;
                connection.Update(reference);
                Application.Current.Properties["CultureInfo"] = CultureInfo.GetCultureInfo(language);
            }
        }
    }
}
