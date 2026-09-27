using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр пишет лог в файл с датой в имени
    public class DailyLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string method = context.HttpContext.Request.Method;
            string path = context.HttpContext.Request.Path;
            int status = context.HttpContext.Response.StatusCode;
            string file = $"log_{DateTime.Now:yyyy-MM-dd}.txt";

            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {method} {path} -> {status}\n";
            System.IO.File.AppendAllText(file, line);
        }
    }
}
