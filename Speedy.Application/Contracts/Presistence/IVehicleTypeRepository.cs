using Speedy.Domain.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedy.Application.Contracts.Presistence
{
    public interface IVehicleTypeRepository : IGenericRepository<VehicleType>
    {
        Task Update(VehicleType vehicleType);
    }
}
