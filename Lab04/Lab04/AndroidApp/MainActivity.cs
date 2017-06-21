using Android.App;
using Android.Widget;
using Android.OS;
using PCLProject;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var validator = new AppValidator(new AndroidDialog(this))
            {
                Email = "rgfxadrian@outlook.com",
                Password = "SustentablE3093",
                DeviceId = Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId)
            };

            validator.Validate();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

