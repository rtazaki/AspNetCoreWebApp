using AspNetCoreWebApp.Devices;
using AspNetCoreWebApp.States;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly State _state;
        private readonly IDevice _device;
        public HomeController(State state, IDevice device)
        {
            _state = state;
            _device = device;
        }

        [HttpGet, Route("v1/index")]
        public IActionResult IndexGet()
        {
            if (_state.asyncLock.IsLock())
            {
                return StatusCode(400, "Get Waiting");
            }
            var result = new Requests.Response.Base { Name = "Get" };
            using (_state.asyncLock.Lock())
            {
                result.DeviceCode = _device.HeavyWait();
            }
            return StatusCode(200, result);
        }

        [HttpPost, Route("v1/index")]
        public async Task<IActionResult> IndexPostAsync()
        {
            if (_state.asyncLock.IsLock())
            {
                return StatusCode(400, "Post Waiting");
            }
            var result = new Requests.Response.Base { Name = "Post" };
            using(await _state.asyncLock.LockAsync())
            {
                result.DeviceCode = await _device.HeavyWaitAsync();
            }
            return StatusCode(200, result);
        }

        [HttpPut, Route("v1/index")]
        public IActionResult Test()
        {
            if (_state.asyncLock.IsLock())
            {
                return StatusCode(400, "Put Waiting");
            }
            using(_state.asyncLock.Lock())
            {
            }
            return StatusCode(200, "test");
        }
    }
}