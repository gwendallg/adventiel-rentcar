using System.Globalization;
using AdventielRentCar.Services;
using Prism;
using Prism.Ioc;
using AdventielRentCar.Views;
using Prism.Plugin.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AdventielRentCar
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var languageService = Container.Resolve<ILanguageService>();
            Application.Current.SetCurrentCulture(CultureInfo.GetCultureInfo(languageService.GetDefaultLanguage()));
            await NavigationService.NavigateAsync("Navigation/Login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<MainPage>("Main");
            containerRegistry.RegisterForNavigation<HomePage>("Home");
            containerRegistry.RegisterForNavigation<LoginPage>("Login");
            containerRegistry.RegisterForNavigation<LanguagePopupPage>();

            containerRegistry.RegisterSingleton<IMigrationService, MigrationService>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
            containerRegistry.RegisterSingleton<ILanguageService, LanguageService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
        }
    }
}
