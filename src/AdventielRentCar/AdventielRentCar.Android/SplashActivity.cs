using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace AdventielRentCar.Droid
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, Icon = "@drawable/ic_launcher")]
    public class SplashActivity : Activity
    {
        static readonly string Tag = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(Tag, "SplashActivity.OnCreate");
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            var startupWork = new Task(SimulateStartup);
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        void SimulateStartup()
        {
            Log.Debug(Tag, "Performing some startup work that takes a bit of time.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}