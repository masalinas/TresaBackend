using System;
using System.Collections.Generic;

using Tresa.Models;

namespace Tresa.Services.Contracts
{
    public interface IDeviceService : IBaseService<Device>
    {
        IEnumerable<Battery> GetBatteries(long id);
    }
}
