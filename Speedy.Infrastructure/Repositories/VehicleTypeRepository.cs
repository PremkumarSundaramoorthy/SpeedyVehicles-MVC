using Microsoft.EntityFrameworkCore;
using Speedy.Application.Contracts.Presistence;
using Speedy.Domain.Models;
using Speedy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedy.Infrastructure.Repositories
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Update(VehicleType vehicleType)
        {
            var objFromDb = await _dbContext.VehicleType.FirstOrDefaultAsync(x => x.Id == vehicleType.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = vehicleType.Name;
            }

            _dbContext.Update(objFromDb);
        }
    }
}
