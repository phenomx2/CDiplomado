using Android.App;
using Android.Widget;
using Android.OS;
using SALLab02;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
        private async void Validate()
        {
            ServiceClient client = new ServiceClient();
            string studentName = "@outlook.com";
            string password = "";
            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            ResultInfo resultInfo = await client.ValidateAsync(studentName, password, deviceId);
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{resultInfo.Status}\n{resultInfo.Fullname}\n{resultInfo.Token}");
            alert.SetButton("Ok", (s, a) => { });
            alert.Show();

        }

    }
}

