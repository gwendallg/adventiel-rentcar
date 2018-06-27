using Prism.Commands;
using Prism.Mvvm;
using AdventielRentCar.Services;
using Prism.Navigation;

namespace AdventielRentCar.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
	    private readonly INavigationService _navigationService;

	    public MainPageViewModel(INavigationService navigationService,IUserService userService)
	    {
	        _navigationService = navigationService;
	        NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            LogoutCommand = new DelegateCommand(async ()=> await userService.LogoutAsync());
	    }

        public DelegateCommand LogoutCommand { get; }
	    public DelegateCommand<string> NavigateCommand { get; }

	    private string _userName;

	    public string UserName
	    {
	        get => _userName;
	        set => SetProperty(ref _userName, value);
	    }

        private async void OnNavigateCommandExecuted(string path)
	    {
	        await _navigationService.NavigateAsync(path);
	    }
    }
}
