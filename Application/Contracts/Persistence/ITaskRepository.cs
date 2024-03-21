using Domain.Entites;
using Domain.Enums;
using Task = Domain.Entites.Task;

namespace Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        Task UpdateStatus(Task task, Status status);
        Task<Task> GetWithDetails(int id);
    }
}
