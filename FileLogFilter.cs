using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр пишет логи в файл logs.txt
    public class FileLogFilter : IActionFilter
    {
        private readonly string _logPath = "logs.txt";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] START {controller}.{action}\n";
            System.IO.File.AppendAllText(_logPath, logMessage);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] END {controller}.{action}\n";
            System.IO.File.AppendAllText(_logPath, logMessage);
        }
    }
}
