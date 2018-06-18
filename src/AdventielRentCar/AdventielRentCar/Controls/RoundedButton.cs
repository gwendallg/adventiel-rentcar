using Xamarin.Forms;

namespace AdventielRentCar.Controls
{
    /// <summary>
    /// componsant bouton bord arrondi
    /// </summary>
    public class RoundedButton : Button
    {
        public object Bag { get; set; }

        public static readonly BindableProperty AltBackgroundColorProperty =
            BindableProperty.Create(
                nameof(AltBackgroundColor),
                typeof(Color),
                typeof(RoundedButton),
                Color.Default
            );
        public static readonly BindableProperty AltTextColorProperty =
            BindableProperty.Create(
                nameof(AltTextColor),
                typeof(Color),
                typeof(RoundedButton),
                Color.Default
            );

        public static readonly BindableProperty AltBorderColorProperty =
            BindableProperty.Create(
                nameof(AltBackgroundColor),
                typeof(Color),
                typeof(RoundedButton),
                Color.Default
            );

        public Color AltTextColor
        {
            get => (Color)GetValue(AltTextColorProperty);
            set => SetValue(AltTextColorProperty, value);
        }

        public Color AltBorderColor
        {
            get => (Color)GetValue(AltBorderColorProperty);
            set => SetValue(AltBorderColorProperty, value);
        }

        public Color AltBackgroundColor
        {
            get => (Color)GetValue(AltBackgroundColorProperty);
            set => SetValue(AltBackgroundColorProperty, value);
        }
    }
}
