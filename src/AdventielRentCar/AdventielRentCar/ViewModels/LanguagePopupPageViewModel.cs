using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using AdventielRentCar.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace AdventielRentCar.ViewModels
{
   public class LanguagePopupPageViewModel : ViewModelBase
    {
        private readonly ILanguageService _languageService;

        private static readonly ResourceManager ResourceManager = new ResourceManager("AdventielRentCar.Resources.AppResource", typeof(LanguagePopupPageViewModel).GetTypeInfo().Assembly);

        public ObservableCollection<LanguagePopupPageItemViewModel> Languages { get; set; }

        public DelegateCommand<LanguagePopupPageItemViewModel> TappedCommand { get; set; }

        public LanguagePopupPageViewModel(INavigationService navigationService, ILanguageService languageService) :
            base(navigationService)
        {
            Languages = new ObservableCollection<LanguagePopupPageItemViewModel>();
            _languageService = languageService;
            Title = _languageService.Translate("SelectLanguage", CultureInfo.GetCultureInfo(_languageService.GetDefaultLanguage()));
            _languageService.GetAvailableLanguages().ForEach(l =>
            {
                var item = new LanguagePopupPageItemViewModel
                {
                    Label = ResourceManager.GetString("Language_" + l, CultureInfo.GetCultureInfo(l)),
                    Culture = CultureInfo.GetCultureInfo(l),
                    Image = ImageSource.FromFile("ic_language_" + l)
                };
                Languages.Add(item);
            });

            TappedCommand = new DelegateCommand<LanguagePopupPageItemViewModel>(OnTapped);
        }

        private async void OnTapped(LanguagePopupPageItemViewModel obj)
        {
            var parameters = new NavigationParameters {{Constants.ReferenceCodes.DefaultLanguage, obj.Culture}};
            _languageService.SetDefaultLanguage(obj.Culture.Name);
            Application.Current.SetCurrentCulture(obj.Culture);
            await NavigationService.GoBackAsync(parameters);
        }
    }
}
