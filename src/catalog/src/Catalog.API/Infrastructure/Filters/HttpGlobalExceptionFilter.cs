using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Catalog.API.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(
            IWebHostEnvironment env,
            ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception.GetType() == typeof(DomainException))
            {
                if (context.Exception.InnerException != null)
                {
                    if (context.Exception.InnerException.GetType() == typeof(FluentValidation.ValidationException))
                    {
                        List<ValidatorError> errors = new List<ValidatorError>();
                        var exception = context.Exception.InnerException as FluentValidation.ValidationException;
                        foreach (var error in exception.Errors)
                        {
                            errors.Add(new ValidatorError()
                            {
                                FieldName = error.PropertyName,
                                ErrorCode = error.ErrorCode
                            });
                        }

                        context.Result = new BadRequestObjectResult(new Response<List<ValidatorError>>()
                        {
                            State = false,
                            Message = ErrorCode.Validator,
                            Object = errors
                        });
                    }
                    else
                    {
                        context.Result = new BadRequestObjectResult(new Response<ResponseDefault>()
                        {
                            State = false,
                            Object = new ResponseDefault()
                            {
                                Data = context.Exception.InnerException.Message
                            },
                            Message = ErrorCode.BadRequest
                        });
                    }
                }
                else
                {
                    context.Result = new BadRequestObjectResult(new Response<ResponseDefault>()
                    {
                        State = false,
                        Object = new ResponseDefault()
                        {
                            Data = context.Exception.Message
                        },
                        Message = ErrorCode.BadRequest
                    });
                }

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                string message = context.Exception.InnerException != null
                    ? context.Exception.InnerException.Message
                    : context.Exception.Message;
                context.Result = new BadRequestObjectResult(new Response<ResponseDefault>()
                {
                    State = false,
                    Object = new ResponseDefault()
                    {
                        Data = message
                    },
                    Message = ErrorCode.BadRequest
                });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}