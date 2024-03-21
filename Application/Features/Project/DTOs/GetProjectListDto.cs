﻿using Application.Features.Project.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs
{
    public class GetProjectListDto : BaseProjectDto
    {
        public int OwnerId { get; set; }

        public int ProjectId { get; set; }
    }
}
