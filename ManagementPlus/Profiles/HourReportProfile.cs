using AutoMapper;
using ManagementPlus.Extensions;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;

namespace ManagementPlus.Profiles
{
    public class HourReportProfile : Profile
    {
        public HourReportProfile()
        {
            CreateMap<HourReportToCreateVM, HourReport>().ForMember(
                dest => dest.ReportedTime,
                opt => opt.MapFrom(src => src.ReportedTime.ToTimeSpanTicks())
            ).ForMember(
                dest => dest.DiscountTime,
                opt => opt.MapFrom(src => src.DiscountTime.ToTimeSpanTicks())
            );
        }
    }
}
