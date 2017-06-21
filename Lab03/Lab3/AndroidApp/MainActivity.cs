using Android.App;
using Android.Widget;
using Android.OS;
using SALLab03;
using SharedProject;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var helper = new MySharedCode();
            //new AlertDialog.Builder(this)
            //    .SetMessage(helper.GetFilePath("demo.dat"))
            //    .Show();

            Validate();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            string studentEmail = "rgfxadrian@outlook.com";
            string password = "SustentablE3093";
            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            ResultInfo resultInfo = await serviceClient.ValidateAsync(studentEmail, password, deviceId);

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

