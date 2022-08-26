using Dojo.Bakery.BuildingBlocks.CustomExceptions;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Dojo.Bakery.BuildingBlocks.WebCommons
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    ILogger<Exception> logger = context?.RequestServices?.GetService<ILogger<Exception>>();
                    IExceptionHandlerFeature contextFeature = context?.Features?.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger?.LogError(contextFeature.Error, "General Exception");
                        KeyValuePair<HttpStatusCode, Response> errorDetail = contextFeature.CreateErrorDetail();
                        context.Response.StatusCode = (int)errorDetail.Key;
                        await context.Response.WriteExceptionAsync(errorDetail.Value);
                    }
                });
            });
        }

        private static KeyValuePair<HttpStatusCode, Response> CreateErrorDetail<T>(this T handlerFeature) where T : IExceptionHandlerFeature
        {
            switch (handlerFeature.Error)
            {
                case ArgumentException ae:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.BadRequest, Message = ae.Message });
                case ItemNotFoundException ie:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.NotFound, Message = ie.Message });
                //case ModelBindingException mbe:
                    //return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.BadRequest, Message = mbe.Message });
                case DatabaseUpdateException db:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.BadRequest, Message = "An error trying to save the changes to the database, the data is not in the correct format" });
                case ValidationException ve:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.NotAcceptable, new ErrorDetail { Data = HttpStatusCode.BadRequest, Message = ve.Message });
                case BusinessException be:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.BadRequest, Message = be.Message });
                case SecurityException se:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.Unauthorized, new ErrorDetail { Data = HttpStatusCode.Unauthorized, Message = se.Message });
                default:
                    return new KeyValuePair<HttpStatusCode, Response>(HttpStatusCode.BadRequest, new ErrorDetail { Data = HttpStatusCode.InternalServerError, Message = "The server has encountered a situation it doesn't know how to handle" });
            }
        }

        private static async Task WriteExceptionAsync<T>(this HttpResponse response, T errorDetail, CancellationToken cancellationToken = default)
            where T : Response
        {
            await response.WriteAsync(errorDetail.ToString(), cancellationToken);
        }
    }
}
