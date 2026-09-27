using FiltersApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Глобальный фильтр логирования в файл по дате
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new DailyLogFilter());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
