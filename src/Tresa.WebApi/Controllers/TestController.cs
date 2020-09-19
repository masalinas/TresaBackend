using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Tresa.Models;
using Tresa.Services.Contracts;

namespace Tresa.WebApi.Controllers
{
    [Route("api/tests")]
    public class TestController : BaseController<Test>
    {
        public TestController(ITestService service, ILogger<TestController> logger) : base(service, logger)
        {
        }
    }
}
