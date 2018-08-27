using System;
using System.Linq;
using System.Threading.Tasks;
using AdventielRentCar.Models;
using Prism.Navigation;
using Xamarin.Forms;

namespace AdventielRentCar.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {

        private readonly INavigationService _navigationService;
        private readonly IDatabaseService _databaseService;
        private readonly ICryptographyService _cryptographyService;
        private readonly ILanguageService _languageService;

        /// <summary>
        /// initialise une nouvelle instance de la classe
        /// </summary>
        /// <param name="databaseService"></param>
        /// <param name="navigationService"></param>
        public UserService(IDatabaseService databaseService, INavigationService navigationService, ILanguageService languageService)
        {
            _cryptographyService = DependencyService.Get<ICryptographyService>();
            _navigationService = navigationService;
            _databaseService = databaseService;
            _languageService = languageService;
        }

        /// <inheritdoc />
        public void AddUser(User user, string newPassword)
        {
            using (var connection = _databaseService.Connnection())
            {
                user.Salt = _cryptographyService.Salt();
                user.Hash = _cryptographyService.Sha256(string.Concat(newPassword, user.Salt));
                connection.Insert(user);
            }
        }

        public async Task LoginAsync(string login, string password, bool remember)
        {
            using (var connection = _databaseService.Connnection())
            {
                var usernameToInvariant = login.ToLowerInvariant();
                var user = connection.Find<User>(u => u.Login == usernameToInvariant);
                if (user == null) throw new Exception(_languageService.Translate("InvalidLoginOrPassword"));
                var hash = _cryptographyService.Sha256(string.Concat(password, user.Salt));
                if (hash != user.Hash) throw new Exception(_languageService.Translate("InvalidLoginOrPassword"));

                if (remember)
                {
                    var reference = connection.Table<Reference>().Single(r =>
                        r.Domain == Constants.ReferenceDomains.Parameters &&
                        r.Code == Constants.ReferenceCodes.RememberLogin);
                    reference.Value = login;
                    connection.Update(reference);
                }

                Application.Current.Properties["login"] = login;
                await _navigationService.NavigateAsync("Main/Navigation/Home");
            }
        }

        /// <inheritdoc />
        public async Task LogoutAsync()
        {
            Application.Current.Properties.Remove("login");
            var parameters = new NavigationParameters {{Constants.NavigationSemaphore.LogOut, true}};
            await _navigationService.GoBackToRootAsync(parameters);
        }

        /// <inheritdoc />
        public string GetRememberLogin()
        {
            using (var connection = _databaseService.Connnection())
            {
                var reference = connection.Table<Reference>().Single(r =>
                    r.Domain == Constants.ReferenceDomains.Parameters &&
                    r.Code == Constants.ReferenceCodes.RememberLogin);
                return reference.Value;
            }
        }
    }
}
