using AdventielRentCar.iOS.Services;
using AdventielRentCar.Services;
using Foundation;
using System;
using System.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatFormService))]
namespace AdventielRentCar.iOS.Services
{
    /// <summary>
    /// implémentation du service plateforme pour iOS
    /// </summary>
    public class PlatFormService : IPlatFormService
    {
        /// <inheritdoc />
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        /// <inheritdoc />
        public int GetAppBuildVersionInfo()
        {
            return int.Parse(NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString());
        }

        /// <inheritdoc />
        public string GetApplicationVersionInfo()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }

        /// <inheritdoc />
        public string GetPlatformInfo()
        {
            return "iOS";
        }

        /// <inheritdoc />
        public string GetPlaformInfoVersion()
        {
            return UIDevice.CurrentDevice.SystemVersion;
        }
    }
}