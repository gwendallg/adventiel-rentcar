using System;
using System.Collections.Generic;
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
            var button = (RoundedButton) sender;
            button.BackgroundColor = ((List<Color>) button.Bag)[0];
            button.TextColor = ((List<Color>) button.Bag)[1];
            button.BorderColor = ((List<Color>) button.Bag)[2];
        }

        void Button_Pressed(object sender, EventArgs e)
        {
            var button = (RoundedButton) sender;
            button.BackgroundColor = button.AltBackgroundColor;
            button.TextColor = button.AltTextColor;
            button.BorderColor = button.AltBorderColor;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (e.OldElement != null)
                {
                    var button = ((RoundedButton)e.OldElement);
                    button.Bag = null;
                    button.Pressed -= Button_Pressed;
                    button.Released -= Button_Released;
                }

                if (e.NewElement != null)
                {
                    var button = (RoundedButton) e.NewElement;
                    button.BorderRadius = 15;
                    button.Bag = new List<Color>();
                    ((List<Color>) button.Bag).Add(button.BackgroundColor);
                    ((List<Color>) button.Bag).Add(button.TextColor);
                    ((List<Color>) button.Bag).Add(button.BorderColor);
                    button.Released += Button_Released;
                    button.Pressed += Button_Pressed;
                }
            }
        }
    }
}
