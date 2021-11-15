using AutoMapper;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Profiles
{
    public class IndividualContributorProfile : Profile
    {
        public IndividualContributorProfile()
        {
            CreateMap<IndividualContributor, IndividualContributorVM>().ForMember(
                dest => dest.Level,
                opt => opt.MapFrom(src => IndividualContributor.GetBandFromLevel(src.Level))
            );

            CreateMap<IndividualContributorToCreateVM, IndividualContributor>();

            CreateMap<IndividualContributor, IndividualContributorToEditVM>();

            CreateMap<IndividualContributorToEditVM, IndividualContributor>();
        }
    }
}
