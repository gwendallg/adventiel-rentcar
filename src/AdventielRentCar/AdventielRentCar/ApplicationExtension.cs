using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AdventielRentCar
{
    public static class ApplicationExtension
    {
        public static CultureInfo GetCurrentCulture(this Application application)
        {
            lock (application)
            {
                if (!application.Properties.ContainsKey("CurrentCulture"))
                {
                    application.Properties["CurrentCulture"] = CultureInfo.CurrentUICulture;
                }
            }
            return application.Properties["CurrentCulture"] as CultureInfo;
        }

        public static void SetCurrentCulture(this Application application,CultureInfo cultureInfo)
        {
            lock (application)
            {
                application.Properties["CurrentCulture"] = cultureInfo;
            }
        }
    }
}
