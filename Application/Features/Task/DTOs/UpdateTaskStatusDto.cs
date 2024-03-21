using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs
{
    public class UpdateTaskStatusDto
    {
        public int Id { get; set; }

        public Status Status { get; set; }
    }
}
