using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab1
{
    [Activity(Label = "Lab1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _button;
        private TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            _button = FindViewById<Button>(Resource.Id.MyButton);
            _textView = FindViewById<TextView>(Resource.Id.textViewDev);

            _button.Click += ButtonOnClick;
        }

        private async void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            _textView.Text = "Adrián Alberto Romero Granados";
            var myDeviceId =
                Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var helper = new XamarinDiplomado.ServiceHelper();
            await helper.InsertarEntidad("dxaudmx@microsoft.com", "Lab1", myDeviceId);
            _button.Text = "Gracias por completar el lab1";
        }
    }
}

