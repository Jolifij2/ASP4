using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр замеряет время выполнения метода
    public class TimingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["TimingStart"] = DateTime.Now;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            if (context.HttpContext.Items["TimingStart"] is DateTime start)
            {
                var ms = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Метод {controller}.{action} выполнен за {ms:F2} мс");
            }
        }
    }
}
