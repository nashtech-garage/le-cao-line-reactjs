using AutoMapper;
using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using Catalog.Domain.DtoModel;

namespace Catalog.API.Application.MapperConfigurations
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionViewModel, Question>();

            CreateMap<Question, QuestionViewModel>()
                .ForMember(des => des.Level, opt => opt
                    .MapFrom(src => src.Level.Name))
                .ForMember(des => des.QuestionType, opt => opt
                    .MapFrom(src => src.QuestionType.Name))
                .ForMember(des => des.TagQuestions, opt => opt
                    .MapFrom(src => src.TagQuestions.Select(x => x.Tag.Name)));

            CreateMap<Domain.AggregatesModel.QuestionAggregate.QuestionType, QuestionTypesViewModel>();

            CreateMap<Level, QuestionLevelsViewModel>();

            CreateMap<Question, Question>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}