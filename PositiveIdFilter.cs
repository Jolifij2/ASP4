using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApp.Filters
{
    // Фильтр проверяет, что id > 0
    public class PositiveIdFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                int id = (int)context.ActionArguments["id"];
                if (id <= 0)
                    context.Result = new BadRequestObjectResult("ID должен быть положительным");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
