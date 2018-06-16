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
                e.NewElement.Released += OnReleased;
                e.NewElement.Pressed += OnPressed;
                e.NewElement.SizeChanged += OnSizeChanged;
            }
            else if (e.OldElement != null)
            {
                e.OldElement.Pressed -= OnPressed;
                e.OldElement.Released -= OnReleased;
                e.OldElement.SizeChanged -= OnSizeChanged;
            }
        }

        private void OnReleased (object sender, EventArgs e)
        {
            if (Control == null) return;
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetColor(Android.Graphics.Color.White);
            gradientDrawable.SetStroke(10, Android.Graphics.Color.Black);
            gradientDrawable.SetCornerRadius(38.0f);
            Control.SetBackground(gradientDrawable);
            Control.SetTextColor(Android.Graphics.Color.Black);
        }

        private void OnPressed(object sender, EventArgs e)
        {
            if(Control==null) return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetColor(((RoundedButton)Element).AltBackgroundColor.ToAndroid());
            gradientDrawable.SetStroke(10, ((RoundedButton)Element).AltForeColor.ToAndroid());
            gradientDrawable.SetCornerRadius(38.0f);
            Control.SetBackground(gradientDrawable);
            Control.SetTextColor(((RoundedButton)Element).AltForeColor.ToAndroid());
        }
        
        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (Control == null) return;
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetColor(Android.Graphics.Color.White);
            gradientDrawable.SetStroke(10, Android.Graphics.Color.Black);
            gradientDrawable.SetCornerRadius(38.0f);
            Control.SetBackground(gradientDrawable);
            Control.SetTextColor(Android.Graphics.Color.Black);
        }
    }
}