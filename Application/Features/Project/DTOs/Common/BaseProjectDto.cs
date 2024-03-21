using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs.Common
{
    public abstract class BaseProjectDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
