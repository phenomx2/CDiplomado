using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Enabled = false;
            var translatedNumber = string.Empty;

            translateButton.Click += delegate(object s, EventArgs args)
            {
                var translator = new PhoneTranslator();
                translatedNumber = translator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    callButton.Text = "Llamar";
                    callButton.Enabled = false;
                }
                else
                {
                    callButton.Text = $"Llamar al {translatedNumber}";
                    callButton.Enabled = true;
                }
            };

            callButton.Click += delegate(object sender, EventArgs args)
            {
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage($"Llamar al numero {translatedNumber}");
                callDialog.SetNeutralButton("Llamar", delegate
                {
                    var callIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callIntent);
                });
            }; 

        }

    }
}

