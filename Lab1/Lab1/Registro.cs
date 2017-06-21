using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace XamarinDiplomado
{
    public class ServiceHelper
    {
        readonly MobileServiceClient _clienteServicio = new MobileServiceClient(@"http://xamarin-diplomado.azurewebsites.net/");

        private IMobileServiceTable<LabItem> _labItemTable;

        public async Task InsertarEntidad(string direccionCorreo, string lab, string androidId)
        {
            _labItemTable = _clienteServicio.GetTable<LabItem>();

            await _labItemTable.InsertAsync(new LabItem
            {
                Email = direccionCorreo,
                Lab = lab,
                DeviceId = androidId
            });
        }
    }
    public class LabItem
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Lab { get; set; }
        public string DeviceId { get; set; }

    }
}