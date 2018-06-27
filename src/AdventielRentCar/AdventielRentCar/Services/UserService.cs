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

        /// <summary>
        /// initialise une nouvelle instance de la classe
        /// </summary>
        /// <param name="databaseService"></param>
        /// <param name="navigationService"></param>
        public UserService(IDatabaseService databaseService, INavigationService navigationService)
        {
            _cryptographyService = DependencyService.Get<ICryptographyService>();
            _navigationService = navigationService;
            _databaseService = databaseService;
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

        /// <inheritdoc />
        public User Authenticate(string login, string password)
        {
            using (var connection = _databaseService.Connnection())
            {
                var loginToLower = login.ToLowerInvariant();
                var user = connection.Find<User>(u => u.Login == loginToLower);
                if (user == null) return null;
                var hash = _cryptographyService.Sha256(string.Concat(password, user.Salt));
                return hash != user.Hash ? null : user;
            }
        }

        /// <inheritdoc />
        public async Task LogoutAsync()
        {
            await _navigationService.NavigateAsync("Login");
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

        /// <inheritdoc />
        public void SetRememberLogin(string login)
        {
            using (var connection = _databaseService.Connnection())
            {
                var reference = connection.Table<Reference>().Single(r =>
                    r.Domain == Constants.ReferenceDomains.Parameters &&
                    r.Code == Constants.ReferenceCodes.RememberLogin);
                reference.Value = login;
                connection.Update(reference);
            }
        }
    }
}
