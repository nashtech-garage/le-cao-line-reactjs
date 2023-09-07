using AutoMapper;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerDto, Answer>()
                .ForMember(d => d.Id,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id))
                .ForMember(d => d.QuestionId, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                    {
                        var questionId = context.Options.Items["questionId"] as string;
                        if (!string.IsNullOrEmpty(questionId)) return questionId;
                        return null;
                    }
                ));

            CreateMap<AnswerViewModel, Answer>();

            CreateMap<Answer, AnswerViewModel>();

            CreateMap<Answer, Answer>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}