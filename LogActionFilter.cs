using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр логирования времени выполнения
    public class LogActionFilter : IActionFilter
    {
        // Выполняется до метода действия
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            // Сохраняем время начала
            context.HttpContext.Items["StartTime"] = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[START] {controller}.{action} начат в {DateTime.Now:HH:mm:ss.fff}");
            Console.ResetColor();
        }

        // Выполняется после метода действия
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            // Считаем время выполнения
            if (context.HttpContext.Items["StartTime"] is DateTime startTime)
            {
                var duration = DateTime.Now - startTime;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[END] {controller}.{action} завершен за {duration.TotalMilliseconds:F2} мс");
                Console.ResetColor();
            }
        }
    }
}
