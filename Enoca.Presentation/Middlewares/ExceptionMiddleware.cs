using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Text;
using Enoca.ApplicationLayer.Wrappers;
using Enoca.ApplicationLayer.Exceptions;

using FluentValidation;

namespace Enoca.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                string req = null;
                if (context.Request.Method != "GET")
                {
                    req = await GetRawBodyAsync(context.Request);
                }

                var messageId = Guid.NewGuid();
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response(false, $"Bir hata ile karsilasildi. (Error Code:{messageId})");


                switch (error)
                {
                    case FluentValidation.ValidationException e:
                        // custom application error
                        StringBuilder errorMessages = new StringBuilder();
                        var errors = e.Errors.Select(x => new Dictionary<string, string> { { x.PropertyName, x.ErrorMessage } }).ToList();

                        foreach (var errorDictionary in errors)
                        {
                            foreach (var errorKeyValue in errorDictionary)
                            {
                                errorMessages.AppendLine($"{errorKeyValue.Key}: {errorKeyValue.Value}");
                            }
                        }

                        responseModel.Message = errorMessages.ToString();
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;


                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case BusinessException exception:
                        // business rule error
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.Message = error.Message;
                        break;


                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var message = GetErrorMessage(error);
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }

        }
        private async Task<string> GetRawBodyAsync(HttpRequest request, Encoding encoding = null)
        {
            var bodyStream = request.Body;

            bodyStream.Seek(0, SeekOrigin.Begin);

            using var bufferReader = new StreamReader(bodyStream, encoding ?? Encoding.UTF8);
            return await bufferReader.ReadToEndAsync();
        }

        private string GetErrorMessage(Exception ex)
        {
            var sb = new StringBuilder();
            sb.Append(ex.Message);
            sb.Append(ex.StackTrace);
            if (ex.InnerException != null)
                sb.Append(GetErrorMessage(ex.InnerException));
            return sb.ToString();
        }
    }
}
