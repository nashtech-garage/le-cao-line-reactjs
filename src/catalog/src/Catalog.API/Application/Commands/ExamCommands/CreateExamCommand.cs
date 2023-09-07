using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class CreateExamCommand : IRequest<Response<ResponseDefault>>
    {
        public ExamDto Exam { get; set; } = null!;
        public string UserId { get; set; }

        //        {
        //  "exam": {
        //    "code": "EX1",
        //    "name": "EX1",
        //    "description": "EX1",
        //    "defaultQuestionNumber": 2,
        //    "questionIds": [
        //      "000db61e-8e3d-490d-9cfc-d85b18bdafe9", "01d21b02-c5ab-4568-8900-061a8a3b35fa"
        //    ],
        //    "plusScorePerQuestion": 0,
        //    "minusScorePerQuestion": 0,
        //    "viewPassQuestion": true,
        //    "viewNextQuestion": true,
        //    "showAllQuestion": false,
        //    "timePerQuestion": 0,
        //    "shufflingExams": 0,
        //    "hideResult": true,
        //    "percentageToPass": 50,
        //    "schedules": [
        //      {
        //        "code": "SCHE1",
        //        "time": 50,
        //        "startTime": "2022-11-05T05:37:15.761Z",
        //        "endTime": "2022-11-05T05:37:15.761Z"
        //      }
        //    ]
        //  }
        //}
    }
}
