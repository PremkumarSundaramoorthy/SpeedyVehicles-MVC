using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Speedy.Application.Contracts.Presistence;
using Speedy.Domain.Models;
using Speedy.Infrastructure.Common;
using Speedy.Infrastructure.Data;
using Speedy.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, 
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

            Brand = new BrandRepository(_dbContext);
            VehicleType = new VehicleTypeRepository(_dbContext);
            Post = new PostRepository(_dbContext);
        }

        public IBrandRepository Brand { get; private set; }

        public IVehicleTypeRepository VehicleType { get; private set; }

        public IPostRepository Post { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            _dbContext.SaveCommonFields(_userManager, _httpContextAccessor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
