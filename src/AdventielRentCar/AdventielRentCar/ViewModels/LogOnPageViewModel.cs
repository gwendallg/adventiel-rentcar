using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Globalization;
using AdventielRentCar.Services;
using Xamarin.Forms;

namespace AdventielRentCar.ViewModels
{
    public class LogOnPageViewModel : ViewModelBase
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

        /// <summary>
        /// mvvm command choisir la langue
        /// </summary>
        public DelegateCommand ChooseLanguageCommand { get; set; }
        
        /// <summary>
        /// mvvm command se connecter
        /// </summary>
        public DelegateCommand LogOnCommand { get; set; }

        /// <summary>
        /// initialise un nouvelle instance de la classe
        /// </summary>
        /// <param name="navigationService">service de navigation</param>
        /// <param name="userService">service utilisateur</param>
        /// <param name="languageService">service de langue</param>
        /// <param name="pageDialogService">service de page dialogue</param>
        public LogOnPageViewModel(
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
            Translate();
        }

        /// <summary>
        /// appelé lor
        /// </summary>
        private async void OnChooseLanguage()
        {
            await NavigationService.NavigateAsync("LanguagePopupPage");
        }

        /// <summary>
        /// appelé lors la connexion
        /// </summary>
        private async void OnLogOn()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password)) return;
            var user = _userService.Authenticate(Login, Password);
            if (user != null && IsRemenberMe)
            {
                _userService.SetRememberLogin(user.Login);
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(
                    _languageService.Translate("Error"),
                    _languageService.Translate("InvalidLoginOrPassword"),
                    _languageService.Translate("Cancel"));
            }
        }

        /// <summary>
        /// traduit les libellés
        /// </summary>
        private void Translate()
        {
            DefaultLanguage = ImageSource.FromFile("ic_language_" + _languageService.CurrentCulture.Name);
            LblSigin = _languageService.Translate("SignIn");
            LblLogin = _languageService.Translate("Login");
            LblLogOn = _languageService.Translate("LogOn");
            LblPassword = _languageService.Translate("Password");
            LblSelectLanguage = _languageService.Translate("SelectLanguage");
            LblRememberMe = _languageService.Translate("RemenberMe");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (!parameters.ContainsKey(Constants.ReferenceCodes.DefaultLanguage)) return;
            _languageService.CurrentCulture =
                (CultureInfo) parameters[Constants.ReferenceCodes.DefaultLanguage];
            Translate();
        }
    }
}
