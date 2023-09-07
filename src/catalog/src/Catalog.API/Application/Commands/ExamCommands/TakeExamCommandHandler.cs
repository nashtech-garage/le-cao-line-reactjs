using AutoMapper;
using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class TakeExamCommandHandler : IRequestHandler<TakeExamCommand, Response<ExamViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public TakeExamCommandHandler(ILogger<TakeExamCommand> logger,
            IExamRepository examRepository,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ExamViewModel>> Handle(TakeExamCommand request,
            CancellationToken cancellationToken)
        {
            var examResult = request.ExamId switch
            {
                FixedExam.A1Id => GetExamA1(),
                FixedExam.A2Id => GetExamA2(),
                FixedExam.A3Id => GetExamA3(),
                FixedExam.A4Id => GetExamA4(),
                FixedExam.B1Id => GetExamB1(),
                FixedExam.B2Id => GetExamB2(),
                FixedExam.CId => GetExamC(),
                FixedExam.DId => GetExamD(),
                FixedExam.EId => GetExamE(),
                FixedExam.FId => GetExamF(),
                _ => await GetExam(request.ExamId)
            };
            
            if (examResult is null)
                return Response<ExamViewModel>.Fail(ErrorCode.InternalError);

            examResult.Questions.ForEach(x => x.Answers.ForEach(x => x.AnswerValue = "false"));

            return Response<ExamViewModel>.Success(ErrorCode.Success, examResult);
        }

        private async Task<ExamViewModel> GetExam(string id)
        {
            var exam = await _examRepository.Exams
                .Where(x => (string.IsNullOrEmpty(id) || x.Id == id)
                            && x.Deleted != true)
                .Include(x => x.Schedules)
                .Include(x => x.QuestionExams)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x => x.Answers)
                .SingleOrDefaultAsync();
            return _mapper.Map<ExamViewModel>(exam);
        }

        private ExamViewModel GetExamA1()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.A1Id),
                Name = "Level A1 Driving Test",
                Description = "Level A1 Driving Test",
                DefaultQuestionNumber = 25,
            };

            Random rand = new Random();
            var get4 = rand.Next(0, 2) == 0;
            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, get4 ? 1 : 0 },
                { QuestionTag.Tag5Id, get4 ? 0 : 1 },
                { QuestionTag.Tag6Id, 7 },
                { QuestionTag.Tag7Id, 7 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 6 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };
            
            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamA2()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.A2Id),
                Name = "Level A2 Driving Test",
                Description = "Level A2 Driving Test",
                DefaultQuestionNumber = 25,
            };

            Random rand = new Random();
            var get4 = rand.Next(0, 2) == 0;
            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, get4 ? 1 : 0 },
                { QuestionTag.Tag5Id, get4 ? 0 : 1 },
                { QuestionTag.Tag6Id, 7 },
                { QuestionTag.Tag7Id, 7 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 6 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamA3()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.A3Id),
                Name = "Level A3 Driving Test",
                Description = "Level A3 Driving Test",
                DefaultQuestionNumber = 25,
            };

            Random rand = new Random();
            var get4 = rand.Next(0, 2) == 0;
            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, get4 ? 1 : 0 },
                { QuestionTag.Tag5Id, get4 ? 0 : 1 },
                { QuestionTag.Tag6Id, 7 },
                { QuestionTag.Tag7Id, 7 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 6 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamA4()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.A4Id),
                Name = "Level A4 Driving Test",
                Description = "Level A4 Driving Test",
                DefaultQuestionNumber = 25,
            };

            Random rand = new Random();
            var get4 = rand.Next(0, 2) == 0;
            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, get4 ? 1 : 0 },
                { QuestionTag.Tag5Id, get4 ? 0 : 1 },
                { QuestionTag.Tag6Id, 7 },
                { QuestionTag.Tag7Id, 7 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 6 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamB1()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.B1Id),
                Name = "Level B1 Driving Test",
                Description = "Level B1 Driving Test",
                DefaultQuestionNumber = 30,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 1 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 9 },
                { QuestionTag.Tag7Id, 9 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 6 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamB2()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.B2Id),
                Name = "Level B2 Driving Test",
                Description = "Level B2 Driving Test",
                DefaultQuestionNumber = 35,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag2Id, 1 },
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 2 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 10 },
                { QuestionTag.Tag7Id, 10 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 7 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamC()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.CId),
                Name = "Level C Driving Test",
                Description = "Level C Driving Test",
                DefaultQuestionNumber = 40,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag2Id, 1 },
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 2 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 14 },
                { QuestionTag.Tag7Id, 11 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 7 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamD()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.DId),
                Name = "Level D Driving Test",
                Description = "Level D Driving Test",
                DefaultQuestionNumber = 40,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag2Id, 1 },
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 2 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 16 },
                { QuestionTag.Tag7Id, 14 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 7 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamE()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.EId),
                Name = "Level E Driving Test",
                Description = "Level E Driving Test",
                DefaultQuestionNumber = 40,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag2Id, 1 },
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 2 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 16 },
                { QuestionTag.Tag7Id, 14 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 7 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private ExamViewModel GetExamF()
        {
            var exam = new ExamViewModel
            {
                PercentageToPass = ExamGetValue.GetPercent(FixedExam.FId),
                Name = "Level F Driving Test",
                Description = "Level F Driving Test",
                DefaultQuestionNumber = 40,
            };

            var questionDictionary = new Dictionary<string, int>()
            {
                { QuestionTag.Tag2Id, 1 },
                { QuestionTag.Tag3Id, 1 },
                { QuestionTag.Tag4Id, 2 },
                { QuestionTag.Tag5Id, 1 },
                { QuestionTag.Tag6Id, 16 },
                { QuestionTag.Tag7Id, 14 },
                { QuestionTag.Tag8Id, 1 },
                { QuestionTag.Tag9Id, 7 },
                { QuestionTag.Tag10Id, 1 },
                { QuestionTag.Tag11Id, 1 },
            };

            exam.Questions = GetQuestionByExam(questionDictionary);

            return exam;
        }

        private List<QuestionViewModel> GetQuestionByExam(IDictionary<string, int> questionDictionary)
        {
            Random rand = new Random();
            var selectedQuestions = new List<Question>();
            var allQuestions = _questionRepository.Questions
                .Include(x => x.Answers)
                .Include(x => x.TagQuestions).ThenInclude(x => x.Tag);
            questionDictionary.ToList().ForEach(d =>
            {
                if (d.Value != 0)
                {
                    var questions = allQuestions.Where(x => x.TagQuestions.Where(x => x.TagId == d.Key).Any());
                    if (questions.Any())
                    {
                        var selectQuestions = questions.Skip(rand.Next() % questions.Count()).Take(d.Value).ToList();
                        selectedQuestions.AddRange(selectQuestions);
                    }
                }
            });

            return _mapper.Map<List<QuestionViewModel>>(selectedQuestions);
        }
    }
}
