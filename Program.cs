using GradeBook.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<JsonDataService>(); // Add your data service

        builder.Services.AddControllersWithViews(); // Add MVC controllers and views

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Change the default route to point to StudentsController and Index action
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Students}/{action=Index}/{id?}"); // <-- Modify this line

        app.Run();
    }
}
