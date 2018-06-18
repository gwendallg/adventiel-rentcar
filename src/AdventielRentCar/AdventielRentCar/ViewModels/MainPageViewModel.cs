using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Globalization;
using System.Threading;
using AdventielRentCar.Services;
using Xamarin.Forms;

namespace AdventielRentCar.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ILanguageService _languageService;
        private readonly IUserService _userService;
        private readonly IPageDialogService _pageDialogService;

        private string _signIn;

        /// <summary>
        /// libellé s'enregistrer
        /// </summary>
        public string LblSigin
        {
            get => _signIn;
            set => SetProperty(ref _signIn, value);
        }

        private string _lblLogin;

        /// <summary>
        /// libellé Identifiant
        /// </summary>
        public string LblLogin
        {
            get => _lblLogin;
            set => SetProperty(ref _lblLogin, value);
        }

        private string _lblRememberMe;

        /// <summary>
        /// libellé se souvenir de moi
        /// </summary>
        public string LblRememberMe
        {
            get => _lblRememberMe;
            set => SetProperty(ref _lblRememberMe, value);
        }

        private string _login;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _lblPassword;

        /// <summary>
        /// libellé mot de passe
        /// </summary>
        public string LblPassword
        {
            get => _lblPassword;
            set => SetProperty(ref _lblPassword, value);
        }

        private string _lblSelectLanguage;

        /// <summary>
        /// libellé sélectionner le language
        /// </summary>
        public string LblSelectLanguage
        {
            get => _lblSelectLanguage;
            set => SetProperty(ref _lblSelectLanguage, value);
        }

        private string _lblLogOn;

        /// <summary>
        /// libellé se connecter
        /// </summary>
        public string LblLogOn
        {
            get => _lblLogOn;
            set => SetProperty(ref _lblLogOn, value);
        }

        private bool _isRemenberMe;

        public bool IsRemenberMe
        {
            get => _isRemenberMe;
            set => SetProperty(ref _isRemenberMe, value);
        }

        private ImageSource _defaultLanguage;

        public ImageSource DefaultLanguage
        {
            get => _defaultLanguage;
            set => SetProperty(ref _defaultLanguage, value);
        }

        public DelegateCommand ChooseLanguageCommand { get; set; }

        public DelegateCommand LogOnCommand { get; set; }

        public MainPageViewModel(
            INavigationService navigationService,
            IUserService userService,
            ILanguageService languageService,
            IPageDialogService pageDialogService
        )
            : base(navigationService)
        {
            _userService = userService;
            _languageService = languageService;
            _pageDialogService = pageDialogService;

            ChooseLanguageCommand = new DelegateCommand(OnChooseLanguage);
            LogOnCommand = new DelegateCommand(OnLogOn);

            Login = _userService.GetRememberLogin();
            IsRemenberMe = !string.IsNullOrWhiteSpace(Login);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(_languageService.GetDefaultLanguage());
            Translate();
        }

        private async void OnChooseLanguage()
        {
            await NavigationService.NavigateAsync("LanguagePopupPage");
        }

        private async void OnLogOn()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password)) return;
            var user = _userService.Authenticate(Login, Password);
            if (user != null && IsRemenberMe)
            {
                _userService.SetRememberLogin(user.Login);
            }else{
                await _pageDialogService.DisplayAlertAsync("Error", "Login ou mot de passe invalide", "Annuler");
            }
        }

        /// <summary>
        /// traduit les libellés
        /// </summary>
        private void Translate()
        {
            DefaultLanguage = ImageSource.FromFile("ic_language_" + Thread.CurrentThread.CurrentUICulture.Name);
            LblSigin = _languageService.Translate("SignIn", Thread.CurrentThread.CurrentUICulture);
            LblLogin = _languageService.Translate("Login", Thread.CurrentThread.CurrentUICulture);
            LblLogOn = _languageService.Translate("LogOn", Thread.CurrentThread.CurrentUICulture);
            LblPassword = _languageService.Translate("Password", Thread.CurrentThread.CurrentUICulture);
            LblSelectLanguage = _languageService.Translate("SelectLanguage", Thread.CurrentThread.CurrentUICulture);
            LblRememberMe = _languageService.Translate("RemenberMe", Thread.CurrentThread.CurrentUICulture);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (!parameters.ContainsKey(Constants.ReferenceCodes.DefaultLanguage)) return;
            Thread.CurrentThread.CurrentUICulture =
                (CultureInfo)parameters[Constants.ReferenceCodes.DefaultLanguage];
            Translate();
        }
    }
}
