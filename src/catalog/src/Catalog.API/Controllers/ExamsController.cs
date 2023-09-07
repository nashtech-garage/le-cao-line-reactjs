using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.API.Application.Commands.ExamCommands;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;

        public ExamsController(IMediator mediator,
            ILogger<ExamsController> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _examRepository = examRepository;
        }

        [Route("GetExams")]
        [HttpPost]
        [ProducesResponseType(typeof(ListResponse<ExamViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuestions([FromBody] GetExamsCommand command)
        {
            try
            {
                Response<PaginationResponse<ExamViewModel>> result;
                if (command == null)
                {
                    result = Response<PaginationResponse<ExamViewModel>>.Fail(ErrorCode.BadRequest);
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

        [Route("CreateExam")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamCommand command)
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

        [Route("GetExamById")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ExamViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ExamViewModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExamById([FromBody] GetExamByIdCommand command)
        {
            Response<ExamViewModel> result;
            if (command == null)
            {
                result = Response<ExamViewModel>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }


        [Route("UpdateExam")]
        [HttpPut]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateExam([FromBody] UpdateExamCommand command)
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

        [Route("RemoveExam")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveExam([FromBody] RemoveExamCommand command)
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

        [Route("TakeExam")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TakeExam([FromBody] TakeExamCommand command)
        {
            Response<ExamViewModel> result;
            if (command == null)
            {
                result = Response<ExamViewModel>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }

        [Route("SubmitExam")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ResponseDefault>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubmitExam([FromBody] SubmitExamCommand command)
        {
            Response<ExamResultViewModel> result;
            if (command == null)
            {
                result = Response<ExamResultViewModel>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }

        [Route("GetExamResults")]
        [HttpPost]
        [ProducesResponseType(typeof(ListResponse<ExamResultViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExamResults([FromBody] GetExamResultsCommand command)
        {
            try
            {
                Response<PaginationResponse<ExamResultViewModel>> result;
                if (command == null)
                {
                    result = Response<PaginationResponse<ExamResultViewModel>>.Fail(ErrorCode.BadRequest);
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

        [Route("GetExamResultById")]
        [HttpPost]
        [ProducesResponseType(typeof(Response<ExamResultViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ExamResultViewModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExamResultById([FromBody] GetExamResultByIdCommand command)
        {
            Response<ExamResultViewModel> result;
            if (command == null)
            {
                result = Response<ExamResultViewModel>.Fail(ErrorCode.BadRequest);
                return BadRequest(result);
            }

            result = await _mediator.Send(command);

            return result.State
                ? StatusCode(StatusCodes.Status200OK, result)
                : StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
