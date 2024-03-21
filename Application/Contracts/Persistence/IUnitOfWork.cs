using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }

        IProjectRepository ProjectRepository { get; }

        IUserRepository UserRepository { get; }

        Task<int> Save();
    }
}
