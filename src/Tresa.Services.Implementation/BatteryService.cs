using System;
using System.Collections.Generic;
using System.Linq;

using Tresa.Models;
using Tresa.DataAccess;
using Tresa.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Tresa.Services.Implementation
{
    public class BatteryService : BaseService<Battery>, IBatteryService
    {
        private IRepository<Test> repositoryTest;
       
        public BatteryService(IRepository<Battery> repositoryBattery, IRepository<Test> repositoryTest) : base(repositoryBattery)
        {
            this.repositoryTest = repositoryTest;
        }

        public IEnumerable<Test> GetTests(long id)
        {
            return this.repositoryTest.DbSet.Where<Test>(p => p.BatteryId == id);
        }
    }
}
