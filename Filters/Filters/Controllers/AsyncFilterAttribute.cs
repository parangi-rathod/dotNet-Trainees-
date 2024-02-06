using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Controllers
{
    
    public class AsyncFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public AsyncFilterAttribute(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before execution of Async filter ${_name}");
            await next();
            Console.WriteLine($"After execution of Async filter ${_name}");
        }
    }
}
