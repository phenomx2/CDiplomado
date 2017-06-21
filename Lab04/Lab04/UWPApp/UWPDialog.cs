using System;
using PCLProject;

namespace UWPApp
{
    public class UWPDialog : IDialog
    {
        public async void Show(string message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}