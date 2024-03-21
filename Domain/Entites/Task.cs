using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Task : BaseDomainEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Status Status { get; set; } = Status.NotStarted;

        public int ProjectId { get; set; }

        public Project Project { get; set; }
        
    }
}
