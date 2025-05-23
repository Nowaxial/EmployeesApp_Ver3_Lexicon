﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeesApp.Web
{
    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // När någon försöker komma in på en sida
            Console.WriteLine("Åtgärd påväg (någon försöker komma in på en sida): " + context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // När någon har besökt en sida
            Console.WriteLine("Åtgärd utförd (någon har besökt en sida): " + context.ActionDescriptor.DisplayName);
        }
    }

}