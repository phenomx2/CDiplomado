using SALLab04;

namespace PCLProject
{
    public class AppValidator
    {
        private IDialog _dialog;
        public string Email { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }

        public AppValidator(IDialog dialog)
        {
            _dialog = dialog;
        }

        public async void Validate()
        {
            string result = string.Empty;
            var serviceClient = new ServiceClient();
            var svcResult = await serviceClient.ValidateAsync(Email, Password, DeviceId);
            result = $"{svcResult.Status}\n{svcResult.Fullname}\n{svcResult.Token}";
            _dialog.Show(result);
        }
    }
}