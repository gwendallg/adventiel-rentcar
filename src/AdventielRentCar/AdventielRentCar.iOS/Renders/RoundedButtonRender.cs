using System;
using AdventielRentCar.Controls;
using AdventielRentCar.iOS.Renders;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRender))]
namespace AdventielRentCar.iOS.Renders
{
    public class RoundedButtonRender : ButtonRenderer
    {


        void Button_Released(object sender, EventArgs e)
        {
            var button = (RoundedButton)sender;
            button.BackgroundColor = Color.White;
            button.TextColor = Color.Black;

        }


        void Button_Pressed(object sender, EventArgs e)
        {
            var button = (RoundedButton)sender;
            button.BackgroundColor = button.AltBackgroundColor;
            button.TextColor = button.AltForeColor;

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (e.OldElement != null)
                {
                    var button = ((RoundedButton)e.NewElement);
                    button.Pressed -= Button_Pressed;
                    button.Released -= Button_Released;
                }
                if (e.NewElement != null)
                {
                    var button = ((RoundedButton)e.NewElement);
                    button.Released += Button_Released;
                    button.BackgroundColor = Color.White;
                    button.TextColor = Color.Black;
                    button.BorderWidth = 3;
                    button.BorderRadius = 10;
                    button.Pressed += Button_Pressed;
                }
            }
        }
    }
}
