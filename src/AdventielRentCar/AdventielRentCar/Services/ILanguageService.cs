using System.Collections.Generic;
using System.Globalization;

namespace AdventielRentCar.Services
{
    /// <summary>
    /// interface de service de gestion de langues
    /// </summary>
    public interface ILanguageService
    {
        /// <summary>
        /// retourne la liste des langues prisent en charge par l'application
        /// </summary>
        /// <returns></returns>
        List<string> GetAvailableLanguages();

        /// <summary>
        /// réalise la traduction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        string Translate(string id, CultureInfo cultureInfo);

        /// <summary>
        /// retourne la langue courante
        /// </summary>
        /// <returns></returns>
        string GetDefaultLanguage();

        /// <summary>
        /// affecte la langue courante
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        void SetDefaultLanguage(string language);
    }
}
