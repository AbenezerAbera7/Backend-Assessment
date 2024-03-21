using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project> GetWithDetails(int id);
    }
}
