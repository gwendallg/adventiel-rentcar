using AdventielRentCar.Droid.Services;
using AdventielRentCar.Services;
using Android.Content.PM;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatFormService))]
namespace AdventielRentCar.Droid.Services
{
    /// <summary>
    /// implémentation du service plateforme pour Android
    /// </summary>
    public class PlatFormService : IPlatFormService
    {
        /// <inheritdoc />
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);
        }

        /// <inheritdoc />
        public int GetAppBuildVersionInfo()
        {
            var context = Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionCode;
        }

        /// <inheritdoc />
        public string GetApplicationVersionInfo()
        {
            var context = Android.App.Application.Context;
            var manager = context.PackageManager;
            var info = manager.GetPackageInfo(context.PackageName, 0);
            return info.VersionName;
        }

        /// <inheritdoc />
        public string GetPlatformInfo()
        {
            return
                $"Android - Manufacturer: ${Android.OS.Build.Manufacturer}, Product: ${Android.OS.Build.Product}, Model: ${Android.OS.Build.Model}";
        }

        /// <inheritdoc />
        public string GetPlaformInfoVersion()
        {
            return Android.OS.Build.VERSION.Sdk;
        }
    }
}