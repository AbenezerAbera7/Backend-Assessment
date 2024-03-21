using Application.Features.Project.DTOs;
using Application.Features.Task.DTOs;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region  Task
            CreateMap<Domain.Entites.Task, CreateTaskDto>().ReverseMap();
            CreateMap<Domain.Entites.Task, UpdateTaskDto>().ReverseMap();
            CreateMap<Domain.Entites.Task, GetTaskListDto>().ReverseMap();
            CreateMap<Domain.Entites.Task, GetTaskDetailDto>().ReverseMap();
            #endregion


            #region  Project
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectListDto>().ReverseMap();
            CreateMap<Project, GetProjectDetailDto>().ReverseMap();
            #endregion
        }
    }
}
