using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Mid_Exe.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMid
    {
        private readonly RequestDelegate _next;

        public CustomMid(RequestDelegate next)
        {
            _next = next;
        }
        public void display()
        {
            Console.WriteLine("I am the 1st middleware to be executed");
        }
        public Task Invoke(HttpContext httpContext)
        {
            display();
            return _next(httpContext);
        }
    }

    public class CustomMid2
    {
        private readonly RequestDelegate _next;

        public CustomMid2(RequestDelegate next)
        {
            _next = next;
        }

        public void display()
        {
            Console.WriteLine("I am the 2nd middleware to be executed");
        }

        public Task Invoke(HttpContext httpContext)
        {
            display();
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMidExtensions
    {
        public static IApplicationBuilder UseCustomMid(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMid>().UseMiddleware<CustomMid2>();
        }
    }
}
