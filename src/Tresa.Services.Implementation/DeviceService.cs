using System;
using System.Collections.Generic;
using System.Linq;

using Tresa.Models;
using Tresa.DataAccess;
using Tresa.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Tresa.Services.Implementation
{
    public class DeviceService : BaseService<Device>, IDeviceService
    {
        private IRepository<Battery> repositoryBattery;

        public DeviceService(IRepository<Device> repositoryDevice, IRepository<Battery> repositoryBattery) : base(repositoryDevice)
        {
            this.repositoryBattery = repositoryBattery;
        }

        /*public IEnumerable<Device> GetIncludeBatteries(long id)
        {
            return this.repository.DbSet.Where<Device>(p => p.Id == id).Include<Device, IEnumerable<Battery>>(p => p.Batteries);
        }*/

        public IEnumerable<Battery> GetBatteries(long id)
        {
            return this.repositoryBattery.DbSet.Where<Battery>(p => p.DeviceId == id);
        }
    }
}
