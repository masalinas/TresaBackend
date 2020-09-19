using System;
using System.Collections.Generic;

using Tresa.Models;

namespace Tresa.Services.Contracts
{
    public interface IBatteryService : IBaseService<Battery>
    {
        IEnumerable<Test> GetTests(long id);
    }
}
