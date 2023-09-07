using AutoMapper;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<ScheduleViewModel, Schedule>();
            CreateMap<Schedule, ScheduleViewModel>();

            CreateMap<ScheduleDto, Schedule>()
                .ForMember(dest => dest.CreatedDate, opt => opt
                    .MapFrom(src => string.IsNullOrEmpty(src.Id) ? DateTime.UtcNow : src.CreatedDate))
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id))
                .ForMember(dest => dest.ExamId, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                    {
                        var questionId = context.Options.Items["examId"] as string;
                        if (!string.IsNullOrEmpty(questionId)) return questionId;
                        return null;
                    }
                ));
            CreateMap<Schedule, ScheduleDto>();

            // TODO
        }
    }
}
