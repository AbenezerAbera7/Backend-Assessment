using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Project : BaseDomainEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
