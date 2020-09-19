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
    [Route("api/batteries")]
    public class BatteryController: BaseController<Battery>
    {
        private new IBatteryService service;

        public BatteryController(IBatteryService service, ILogger<BatteryController> logger) : base(service, logger)
        {
            this.service = service;
        }

        [HttpGet("{id}/tests")]
        public IEnumerable<Test> GetTests(long id)
        {
            return this.service.GetTests(id);
        }

    }
}
