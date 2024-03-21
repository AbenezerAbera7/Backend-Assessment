using Application.Contracts.Persistence;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Entites.Task>, ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async System.Threading.Tasks.Task<Domain.Entites.Task> GetWithDetails(int id)
        {
            return await _dbContext.Tasks
                .Include(u => u.Project)
                .FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Domain.Entites.Task UpdateStatus(Domain.Entites.Task Task, Status status)
        {
            Task.Status = status;
            _dbContext.Entry(Task).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
