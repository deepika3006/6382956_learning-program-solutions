using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string logPath = "ExceptionLog.txt";
            File.AppendAllText(logPath,
                $"[{DateTime.Now}] {context.Exception.Message}\n{context.Exception.StackTrace}\n\n");

            context.Result = new ObjectResult("An error occurred")
            {
                StatusCode = 500
            };
        }
    }
}
