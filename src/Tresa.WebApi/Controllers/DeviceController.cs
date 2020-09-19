using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Tresa.Models;
using Tresa.Services.Contracts;

namespace Tresa.WebApi.Controllers
{
    [Route("api/devices")]
    public class DeviceController : BaseController<Device> 
    {
        private new IDeviceService service;

        public DeviceController(IDeviceService service, ILogger<DeviceController> logger) : base(service, logger)
        {
            this.service = service;
        }

        [HttpGet("{id}/batteries")]
        public IEnumerable<Battery> GetBatteries(long id)
        {
            return this.service.GetBatteries(id);
        }
    }
}
