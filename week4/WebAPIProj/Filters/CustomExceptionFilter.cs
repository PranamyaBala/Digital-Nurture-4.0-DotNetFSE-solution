using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace WebAPIProj.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Capture the exception message
            var exception = context.Exception;

            // Log the exception to a file
            var logMessage = $"[{DateTime.Now}] {exception.Message}\n{exception.StackTrace}\n\n";

            File.AppendAllText("exceptions.txt", logMessage);

            context.Result = new ObjectResult("Something went wrong. Please contact support.")
            {
                StatusCode = 500
            };
        }
    }
}
