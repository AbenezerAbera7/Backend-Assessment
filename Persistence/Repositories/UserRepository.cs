using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<User> GetByEmail(string Email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == Email);
        }
    }
}
