using AutoMapper;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{

    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamViewModel, Exam>();
            CreateMap<Exam, ExamViewModel>()
                .ForMember(dest => dest.Questions, opt => opt
                    .MapFrom(src => src.QuestionExams.Select(x=>x.Question)));

            CreateMap<ExamDto, Exam>()
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt
                    .MapFrom(src => string.IsNullOrEmpty(src.Id) ? DateTime.UtcNow : src.CreatedDate))
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));
            CreateMap<Exam, ExamDto >();

            // TODO
        }
    }
}
