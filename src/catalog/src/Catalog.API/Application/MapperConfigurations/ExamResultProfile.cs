using AutoMapper;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{

    public class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            CreateMap<ExamResultViewModel, ExamResult>();
                
            CreateMap<ExamResult, ExamResultViewModel>()
                .ForMember(d => d.ExamName, opt => opt.MapFrom(s => s.Exam.Name));
        }
    }
}
