using Application.Features.Task.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs
{
    public class CreateTaskDto : BaseTaskDto
    {
        public int UserId { get; set; }
    }
}
