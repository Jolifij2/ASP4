using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр пропускает только с параметром ?admin=true
    public class AdminOnlyFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isAdmin = context.HttpContext.Request.Query["admin"] == "true";

            if (!isAdmin)
            {
                // Возвращаем 403 и прерываем выполнение
                context.Result = new ContentResult
                {
                    Content = "Доступ запрещён. Только для администраторов. Добавьте ?admin=true в URL.",
                    StatusCode = 403
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
