using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InterviewTest.Lib
{
  [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
  public class ApiKeyAuthAttribute: Attribute, IAsyncActionFilter
  {
    private const string API_KEY_HEADER_NAME = "ApiKey";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey)) {
        context.Result = new UnauthorizedResult();
        return;
      }

      var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

      if(!config.GetValue<string>("ApiKey").Equals(extractedApiKey))
      {
        context.Result = new UnauthorizedResult();
        return;
      }

      await next();

    }
  }
}
