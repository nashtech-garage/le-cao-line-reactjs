using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.QuestionCommands.CopyQuestion
{
    public class CopyQuestionCommandHandler : IRequestHandler<CopyQuestionCommand, Response<ResponseDefault>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public CopyQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResponseDefault>> Handle(CopyQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var question = await _questionRepository.Questions.FirstOrDefaultAsync(x => x.Id == request.QuestionId);

            if (question is null)
            {
                return Response<ResponseDefault>.Fail(ErrorCode.NotFound);
            }

            var answers = _questionRepository.Answers.Where(x => x.QuestionId == question.Id).ToList();

            if (answers.Any())
            {
                var cloneQuestion = _mapper.Map<Question>(question);
                cloneQuestion.Id = Guid.NewGuid().ToString();

                _questionRepository.Add(cloneQuestion);

                await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                var cloneAnswers = SetCloneAnswers(answers, cloneQuestion.Id);

                _questionRepository.AddRange(cloneAnswers);

                var saveStatus = await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                return Response<ResponseDefault>.Success(ErrorCode.Success, new ResponseDefault()
                {
                    Data = cloneQuestion.Id.ToString()
                });
            }

            return Response<ResponseDefault>.Fail(ErrorCode.NotFound);
        }

        private List<Answer> SetCloneAnswers(List<Answer> answers, string cloneQuestionId)
        {
            var cloneAnswers = _mapper.Map<List<Answer>>(answers);
            cloneAnswers.ForEach(x =>
            {
                x.QuestionId = cloneQuestionId;
                x.Id = Guid.NewGuid().ToString();
            });

            return cloneAnswers;
        }
    }
}