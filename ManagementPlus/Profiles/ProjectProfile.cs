using AutoMapper;
using ManagementPlus.Extensions;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectToCreateVM, Project>().ForMember(
                dest => dest.HoursLimit, 
                opt => opt.MapFrom(src => src.HoursLimit.ToTimeSpanTicks())
            );

            CreateMap<Project, ProjectVM>().ForMember(
                dest => dest.HoursLimit,
                opt => opt.MapFrom(src => src.HoursLimit.ToStringFromTimeSpanTicks())
            );

            CreateMap<ProjectToEditVM, Project>().ForMember(
                dest => dest.HoursLimit,
                opt => opt.MapFrom(src => src.HoursLimit.ToTimeSpanTicks())
            );

            CreateMap<Project, ProjectToEditVM>().ForMember(
                dest => dest.HoursLimit,
                opt => opt.MapFrom(src => src.HoursLimit.ToStringFromTimeSpanTicks())
            );
        }
    }
}
