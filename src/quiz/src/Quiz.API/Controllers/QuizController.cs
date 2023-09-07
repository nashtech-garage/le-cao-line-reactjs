using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Commands;
using MediatR;
using Quiz.Application.Queries;

namespace Quiz.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<bool> CreateQuiz([FromBody] CreateQuizCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<Domain.Models.Quiz> GetQuizzById(string id)
        {
            return await _mediator.Send(new GetQuizByIdQuery { Id = id});
        }
        [HttpGet]
        public async Task<List<Domain.Models.Quiz>> GetAllQuizzes()
        {
            return await _mediator.Send(new GetAllQuizzesQuery());
        }
    }
}
