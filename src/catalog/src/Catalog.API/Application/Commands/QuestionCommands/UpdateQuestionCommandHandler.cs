using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(ILogger<UpdateQuestionCommand> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResponseDefault>> Handle(UpdateQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var question = await _questionRepository.Questions
                .Where(q => q.Id == request.Id)
                .Include(x => x.Answers)
                .FirstOrDefaultAsync();

            if (question is null)
            {
                return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
            }

            question.QuestionContent = request.QuestionContent;
            question.LevelId = request.LevelId;
            question.ShuffleAnswers = request.ShuffleAnswers;

            var removedAnswerIds = new List<string>();

            // Udpate or remove existing answer
            if (question.Answers != null)
            {
                question.Answers.ForEach(x =>
                {
                    var updatedAnswer = request.Answers.FirstOrDefault(y => x.Id == y.Id);
                    if (updatedAnswer is null)
                    {
                        removedAnswerIds.Add(x.Id);
                    }
                    else
                    {
                        x.AnswerValue = updatedAnswer.AnswerValue;
                        x.AnswerContent = updatedAnswer.AnswerContent;
                        x.AllowShuffle = updatedAnswer.AllowShuffle;
                        x.MatchingPosition = updatedAnswer.MatchingPosition;
                    }
                });

                var removedAnswers = question.Answers.Where(x => removedAnswerIds.Contains(x.Id)).ToList();
                removedAnswers.ForEach(x => question.Answers.Remove(x));
            }

            _questionRepository.Update(question);

            // Create new answer
            var answers = _mapper.Map<IEnumerable<AnswerDto>, List<Answer>>(request.Answers.Where(x=> string.IsNullOrEmpty(x.Id)), opts =>
                    opts.Items["questionId"] = question.Id);
            _questionRepository.AddRange(answers);

            // Save change
            var questionResult = await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (questionResult)
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