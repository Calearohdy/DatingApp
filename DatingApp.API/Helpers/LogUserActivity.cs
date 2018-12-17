using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();
            // Grabbing user id from the token
            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            // Grabbing users from the Dating repo
            var repo = resultContext.HttpContext.RequestServices.GetService<IDatingRepository>();
            // retrieving the correct user
            var user = await repo.GetUser(userId);
            // updating last active on login
            user.LastActive = DateTime.Now;

            await repo.SaveAll();
        }
    }
}