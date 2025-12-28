using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace AspSampleChangeLanguage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");

            // Add services to the container.
            builder.Services
                .AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            var app = builder.Build();




            var supportedCultures = new[]
            {
                new CultureInfo("ru"),
                new CultureInfo("en")
            };
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            localizationOptions.RequestCultureProviders.Insert(0,
                new CookieRequestCultureProvider());
            app.UseRequestLocalization(localizationOptions);





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
