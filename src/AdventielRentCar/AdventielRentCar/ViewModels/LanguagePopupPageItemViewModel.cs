using System.Globalization;
using Xamarin.Forms;

namespace AdventielRentCar.ViewModels
{
    public class LanguagePopupPageItemViewModel
    {
        public string Label { get; set; }

        public ImageSource Image { get; set; }

        public CultureInfo Culture { get; set; }
    }
}
