using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdventielRentCar.Controls
{
    [ContentProperty("Text")]
    public class TranslateExtension: IMarkupExtension
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("AdventielRentCar.Resources.AppResource", typeof(TranslateExtension).GetTypeInfo().Assembly);

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Text == null ? null : ResourceManager.GetString(Text, Application.Current.Properties["CultureInfo"] as CultureInfo);
        }
    }
}
