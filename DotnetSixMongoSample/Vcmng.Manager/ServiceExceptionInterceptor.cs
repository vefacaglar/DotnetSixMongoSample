using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Vcmng.Infrastructure.Response;

namespace Vcmng.Manager
{
    public class ServiceExceptionInterceptor : ExceptionFilterAttribute, IAsyncExceptionFilter
    {
        async Task IAsyncExceptionFilter.OnExceptionAsync(ExceptionContext context)
        {
            // do some error logs

            var error = new BaseResponse<object>
            {
                Message = "application error",
            };

            context.Result = new JsonResult(error);
            context.HttpContext.Response.StatusCode = 500;
        }
    }
}
