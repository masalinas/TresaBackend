using System;
using System.Collections.Generic;
using System.Linq;

using Tresa.Models;
using Tresa.DataAccess;
using Tresa.Services.Contracts;

namespace Tresa.Services.Implementation
{
    public class TestService : BaseService<Test>, ITestService
    {
        public TestService(IRepository<Test> repositoryTest) : base(repositoryTest)
        {           
        }
    }
}
