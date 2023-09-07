﻿using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(ILogger<CreateQuestionCommand> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResponseDefault>> Handle(CreateQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var question = new Question
            {
                QuestionContent = request.QuestionContent,
                QuestionTypeId = request.QuestionTypeId,
                LevelId = request.LevelId,
                UserId = request.UserId,
                CreatedBy = request.UserId
            };

            _questionRepository.Add(question);

            var questionResult = await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (questionResult)
            {
                // Save questionTag
                var tagQuestions = new List<TagQuestion>();
                if (request.TagNames != null && request.TagNames.Any())
                {
                    request.TagNames.ToList().ForEach(x =>
                    {
                        var tag = _questionRepository.Tags.FirstOrDefault(y => y.Name == x);

                        if (tag is null)
                        {
                            tag = new Tag
                            {
                                Name = x,
                                Description = x,
                            };
                            _questionRepository.Add(tag);
                            _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                        }

                        var tagQuestion = new TagQuestion
                        {
                            QuestionId = question.Id,
                            TagId = tag.Id
                        };
                        tagQuestions.Add(tagQuestion);
                    });
                    _questionRepository.AddRange(tagQuestions);
                }

                // Save answer
                var answers = _mapper.Map<IEnumerable<AnswerDto>, List<Answer>>(request.Answers, opts =>
                    opts.Items["questionId"] = question.Id);
                _questionRepository.AddRange(answers);
            }

            var answerResult = await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (questionResult && answerResult)
            {
                return Response<ResponseDefault>.Success(ErrorCode.Success, new ResponseDefault()
                {
                    Data = question.Id.ToString()
                });
            }

            return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
        }
    }
}