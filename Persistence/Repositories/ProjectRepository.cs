using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly AppContext _dbContext;
        public ProjectRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        
        public async Task<Project> GetWithDetails(int id)
        {
            return await _dbContext.Projects.Include(c => c.Tasks).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
