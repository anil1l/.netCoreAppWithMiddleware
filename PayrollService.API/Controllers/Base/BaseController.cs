using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PayrollService.Model.Exceptions;
using PayrollService.Model.Messages.Response;
using System.Net;

namespace PayrollService.API.Controllers.Base
{
    public class BaseController : Controller
    {

        /// <summary>
        /// Global exception handling and logging
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {


                if (context.Exception.GetType() == typeof(DefaultException))
                {
                    var excetpion = (DefaultException)context.Exception;

                    while (context.Exception.InnerException != null)
                    {
                        context.Exception = context.Exception.InnerException;
                    }

                    //TODO:LOG IT HERE!!

                }
                else
                {
                    while (context.Exception.InnerException != null)
                    {
                        context.Exception = context.Exception.InnerException;
                    }

                    //TODO:LOG IT HERE!!
                }

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject($"An error occured: {context.Exception.Message}")).Wait();

            }
            else
            {
                if (context.Result != null)
                {
                    ObjectResult objectResult = context.Result as ObjectResult;
                    APIResponse apiResponse = new APIResponse()
                    {
                        ResponseCode = 200,
                        ResponseMessage = "SUCCESS!",
                        ResponseData = objectResult.Value
                    };
                    ObjectResult result = new ObjectResult(apiResponse);
                    context.Result = result;
                }
            }
        }
    }
}
