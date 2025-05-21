using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeesApp.Web
{
    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // När någon försöker komma in på en sida
            Console.WriteLine("Åtgärd påväg: " + context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // När någon har besökt en sida
            Console.WriteLine("Åtgärd utförd: " + context.ActionDescriptor.DisplayName);
        }
    }

}