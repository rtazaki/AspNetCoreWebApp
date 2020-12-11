using System.Threading.Tasks;

namespace AspNetCoreWebApp.Devices
{
    public class Device : IDevice
    {
        public int HeavyWait()
        {
            System.Threading.Thread.Sleep(10000);
            return 5;
        }
        public async Task<int> HeavyWaitAsync()
        {
            await Task.Delay(10000);
            return 10;
        }
    }
}