using AutoMapper;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{
    public class QuestionAnswerProfile : Profile
    {
        public QuestionAnswerProfile()
        {
            CreateMap<QuestionAnswerDto, QuestionAnswer>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id))
                .ForMember(d => d.ExamResultId, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                    {
                        var refId = context.Options.Items["examResultId"] as string;
                        if (!string.IsNullOrEmpty(refId)) return refId;
                        return null;
                    }
                ));

            CreateMap<QuestionAnswerViewModel, QuestionAnswer>();

            CreateMap<QuestionAnswer, QuestionAnswerViewModel>();
        }
    }
}
