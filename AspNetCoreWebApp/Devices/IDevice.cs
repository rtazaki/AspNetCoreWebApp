using System.Threading.Tasks;

namespace AspNetCoreWebApp.Devices
{
    public interface IDevice
    {
        public int HeavyWait();
        public Task<int> HeavyWaitAsync();
    }
}