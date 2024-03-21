using Application.Features.Task.DTOs.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs
{
    public class GetTaskListDto : BaseTaskDto
    {
        public int UserId { get; set; }

        public Status Status { get; set; }
    }
}
