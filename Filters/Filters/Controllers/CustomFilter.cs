using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Controllers
{
    //now this can be used as attribute 
    public class CustomFilter : Attribute, IActionFilter
    {
        private readonly string _name;

        public CustomFilter(string name)
        {
            _name = name;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted + {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
        }
    }
}
