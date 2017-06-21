using Android.App;
using Android.Content;
using PCLProject;

namespace AndroidApp
{
    public class AndroidDialog : IDialog
    {
        private Context _appContext;

        public AndroidDialog(Context context)
        {
            _appContext = context;
        }

        public void Show(string message)
        {
            Android.App.AlertDialog.Builder builder = 
                new AlertDialog.Builder(_appContext);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton("Ok", (s, a) => { });
            alert.Show();
        }
    }
}