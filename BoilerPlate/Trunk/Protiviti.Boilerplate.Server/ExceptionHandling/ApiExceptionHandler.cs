using System.Text;
using System.Web.Http.ExceptionHandling;
using Protiviti.Boilerplate.Server.Exceptions;
using Protiviti.Boilerplate.Server.Results;

namespace Protiviti.Boilerplate.Server.ExceptionHandling
{
    public class ApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var baseException = context.Exception.GetBaseException();
            var apiException = baseException as ApiException;
            
            if (apiException != null)
            {
                context.Result = new BadRequestCustomApiResult(
                    apiException, 
                    Encoding.UTF8, 
                    context.Request);
            }
            else
            {
                context.Result = new InternalServerErrorResult(
                    "An unhandled exception occurred; check the log for more information.",
                    Encoding.UTF8, 
                    context.Request);
            }
        }
    }
}