using System;
using AdventielRentCar.Controls;
using AdventielRentCar.Droid.Renders;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRender))]
namespace AdventielRentCar.Droid.Renders
{
    public class RoundedButtonRender : ButtonRenderer
    {
        public RoundedButtonRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var roundedButton = (RoundedButton)e.NewElement;
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetShape(ShapeType.Rectangle);
                gradientDrawable.SetColor(roundedButton.BackgroundColor.ToAndroid());
                gradientDrawable.SetStroke(Convert.ToInt32(roundedButton.BorderWidth),
                    roundedButton.BorderColor.ToAndroid());
                gradientDrawable.SetCornerRadius(roundedButton.BorderRadius);
                Control.SetBackground(gradientDrawable);
                Control.SetTextColor(roundedButton.TextColor.ToAndroid());
                e.NewElement.Released += OnReleased;
                e.NewElement.Pressed += OnPressed;
            }
            else if (e.OldElement != null)
            {
                e.OldElement.Pressed -= OnPressed;
                e.OldElement.Released -= OnReleased;
            }
        }

        private void OnReleased(object sender, EventArgs e)
        {
            if (Control == null) return;
            var roundedButton = (RoundedButton)Element;
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetColor(roundedButton.BackgroundColor.ToAndroid());
            gradientDrawable.SetStroke(Convert.ToInt32(roundedButton.BorderWidth),
                roundedButton.BorderColor.ToAndroid());
            gradientDrawable.SetCornerRadius(roundedButton.BorderRadius);
            Control.SetBackground(gradientDrawable);
            Control.SetTextColor(roundedButton.TextColor.ToAndroid());
        }

        private void OnPressed(object sender, EventArgs e)
        {
            if (Control == null) return;
            var roundedButton = (RoundedButton)Element;
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetColor(((RoundedButton)Element).AltBackgroundColor.ToAndroid());
            gradientDrawable.SetStroke(Convert.ToInt32(roundedButton.BorderWidth), ((RoundedButton)Element).AltBorderColor.ToAndroid());
            gradientDrawable.SetCornerRadius(roundedButton.BorderRadius);
            Control.SetBackground(gradientDrawable);
            Control.SetTextColor(((RoundedButton)Element).AltTextColor.ToAndroid());
        }
    }
}