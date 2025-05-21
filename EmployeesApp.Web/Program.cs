using EmployeesApp.Web.Services;
using EmployeesApp.Web.Services.Interfaces;

namespace EmployeesApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<LoggingFilter>();
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();

            //Hej Från Alberto!
        }
    }
}