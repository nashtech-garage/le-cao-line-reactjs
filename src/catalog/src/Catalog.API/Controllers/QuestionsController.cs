using AutoMapper;
using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Application.Commands.QuestionCommands.CopyQuestion;
using Catalog.API.Application.Queries;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using Catalog.Domain.DtoModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IMediator mediator,
            ILogger<QuestionsController> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _questionRepository = questionRepository;
        }

        [Route("GetQuestions")]
        [HttpPost]
        [ProducesResponseType(typeof(ListResponse<QuestionViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuestions([FromBody] GetQuestionsCommand command)
        {
            try
            {
                Response<PaginationResponse<QuestionViewModel>> result;
                if (command == null)
                {
                    result = Response<PaginationResponse<QuestionViewModel>>.Fail(ErrorCode.BadRequest);
                    return BadRequest(result);
                }

                result = await _mediator.Send(command);
                return result.State ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("CreateQuestion")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
        {
            Response<ResponseDefault> result;
            if (command == null)
            {
                result = Response<ResponseDefault>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status201Created, result)
                : BadRequest(result);
        }

        [Route("GetQuestionById")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<QuestionViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<QuestionViewModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestionById([FromBody] GetQuestionByIdCommand command)
        {
            Response<QuestionViewModel> result;
            if (command == null)
            {
                result = Response<QuestionViewModel>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }


        [Route("UpdateQuestion")]
        [HttpPut]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommand command)
        {
            Response<ResponseDefault> result;
            if (command == null)
            {
                result = Response<ResponseDefault>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status201Created, result)
                : BadRequest(result);
        }

        [Route("RemoveQuestion")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveQuestion([FromBody] RemoveQuestionCommand command)
        {
            Response<ResponseDefault> result;
            if (command == null)
            {
                result = Response<ResponseDefault>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status201Created, result)
                : BadRequest(result);
        }

        [Route("CopyQuestion")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CopyQuestion([FromBody] CopyQuestionCommand command)
        {
            Response<ResponseDefault> result;
            if (command == null)
            {
                result = Response<ResponseDefault>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status201Created, result)
                : BadRequest(result);
        }

        [Route("GetQuestionTypes")]
        [HttpGet]
        [ProducesResponseType(typeof(Response<List<QuestionTypesViewModel>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<List<QuestionTypesViewModel>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestionTypes()
        {
            Response<List<QuestionTypesViewModel>> result;

            result = await _mediator.Send(new GetQuestionTypesQuery());

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }

        [Route("GetQuestionLevels")]
        [HttpGet]
        [ProducesResponseType(typeof(Response<List<QuestionLevelsViewModel>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<List<QuestionLevelsViewModel>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestionLevels()
        {
            Response<List<QuestionLevelsViewModel>> result;

            result = await _mediator.Send(new GetQuestionLevelsQuery());

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }

        //[Route("GenericQuestions")]
        //[HttpGet]
        //[ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GenericQuestions()
        //{
        //    // Deserialize data from json
        //    string dataFilePath = $"C:\\Users\\quock\\Downloads\\data.json";

        //    string fileContent = null;

        //    try
        //    {
        //        fileContent = System.IO.File.ReadAllText(dataFilePath);
        //    }
        //    catch
        //    {
        //        if (string.IsNullOrEmpty(fileContent))
        //        {
        //            fileContent = System.IO.File.ReadAllText(dataFilePath);
        //        }
        //    }

        //    var questionDataJson = JsonConvert.DeserializeObject<List<QuestionJson>>(fileContent);

        //    var command = new CreateQuestionsCommand();
        //    var questions = new List<CreateQuestionCommand>();

        //    if (questionDataJson != null)
        //    {
        //        questionDataJson.ForEach(x =>
        //        {
        //            var question = new CreateQuestionCommand();

        //            // mapping question

        //            question.QuestionContent = x.QuestionContent;
        //            question.TagNames = new List<string> { x.CategoryId.ToString() };

        //            // mapping answers
        //            var answers = new List<AnswerDto>();
        //            var answerData = x.Answers.ToList();
        //            answerData.ForEach(answerItem =>
        //            {
        //                var answer = new AnswerDto();
        //                answer.AnswerContent = answerItem.Content;
        //                answer.AnswerValue = answerItem.IsTrue.ToString();

        //                answers.Add(answer);
        //            });
        //            question.Answers = answers;

        //            questions.Add(question);
        //        });
        //        command.CreateQuestionCommands = questions;

        //        await _mediator.Send(command);
        //    }

        //    return StatusCode(StatusCodes.Status201Created);
        //}
    }

    public class AnswerJson
    {
        public int SortOrder { get; set; }
        public string Content { get; set; }
        public bool IsRandom { get; set; }
        public bool IsTrue { get; set; }
    }

    public class QuestionJson
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public IList<string> Tags { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }
        public string Image { get; set; }
        public string NameUrl { get; set; }
        public IList<AnswerJson> Answers { get; set; }
    }
}