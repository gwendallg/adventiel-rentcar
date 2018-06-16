using Xamarin.Forms;

namespace AdventielRentCar.Controls
{
    /// <summary>
    /// componsant bouton bord arrondi
    /// </summary>
    public class RoundedButton : Button
    {
        public static readonly BindableProperty AltBackgroundColorProperty =
            BindableProperty.Create(
                nameof(AltBackgroundColor),
                typeof(Color),
                typeof(RoundedButton),
                Color.Default
            );

        public static readonly BindableProperty AltForeColorProperty =
            BindableProperty.Create(
                nameof(AltBackgroundColor),
                typeof(Color),
                typeof(RoundedButton),
                Color.Default
            );

        public Color AltForeColor
        {
            get => (Color)GetValue(AltForeColorProperty);
            set => SetValue(AltForeColorProperty, value);
        }

        public Color AltBackgroundColor
        {
            get => (Color)GetValue(AltBackgroundColorProperty);
            set => SetValue(AltBackgroundColorProperty, value);
        }
    }
}
