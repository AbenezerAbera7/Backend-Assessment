using Application.Features.Project.DTOs.Common;
using Application.Features.Task.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs
{
    public class GetProjectDetailDto : BaseProjectDto
    {
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }

        public List<GetTaskListDto> Tasks { get; set; }
    }
}
