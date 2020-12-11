using AspNetCoreWebApp.Devices;
using AspNetCoreWebApp.States;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IState _state;
        private readonly IDevice _device;
        public HomeController(IState state, IDevice device)
        {
            _state = state;
            _device = device;
        }

        [HttpGet, Route("v1/index")]
        public IActionResult IndexGet()
        {
            if (_state.ProtectedActionSemaphore.CurrentCount < 1)
            {
                return StatusCode(400, "Get Waiting");
            }
            var result = new Requests.Response.Base { Name = "Get" };
            _state.ProtectedActionSemaphore.Wait();
            try
            {
                result.DeviceCode = _device.HeavyWait();
            }
            finally { _state.ProtectedActionSemaphore.Release(); }
            return StatusCode(200, result);
        }

        [HttpPost, Route("v1/index")]
        public async Task<IActionResult> IndexPostAsync()
        {
            if (_state.ProtectedActionSemaphore.CurrentCount < 1)
            {
                return StatusCode(400, "Post Waiting");
            }
            var result = new Requests.Response.Base { Name = "Post" };
            await _state.ProtectedActionSemaphore.WaitAsync();
            try
            {
                result.DeviceCode = await _device.HeavyWaitAsync();
            }
            finally { _state.ProtectedActionSemaphore.Release(); }
            return StatusCode(200, result);
        }

        [HttpPut, Route("v1/index")]
        public IActionResult Test()
        {
            if (_state.ProtectedActionSemaphore.CurrentCount < 1)
            {
                return StatusCode(400, "Put Waiting");
            }
            _state.ProtectedActionSemaphore.Wait();
            try
            {
            }
            finally { _state.ProtectedActionSemaphore.Release(); }
            return StatusCode(200, "test");
        }
    }
}