using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAH_FIMS.Data1;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;
using DAH_FIMS.Services;
using Syncfusion.Blazor;
using Radzen;


namespace DAH_FIMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSyncfusionBlazor();
            services.AddScoped<IFileUpload, FileUpload>();
            

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            services.AddDbContext<DahFIMSDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<EmployeeService>();
            services.AddScoped<FacultyService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<SchoolService>();
            services.AddScoped<PositionService>();
            services.AddScoped<OfficesService>();
            services.AddScoped<RequestsService>();
            services.AddScoped<ResourcesService>();
            services.AddScoped<WorkloadService>();
            services.AddScoped<CourseService>();
            services.AddScoped<TAService>();
            services.AddScoped<FCService>();

            services.AddSingleton<AppDataService>();
            services.AddScoped<AppDataService>();







        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzc3NDAwQDMxMzgyZTM0MmUzME0wa1JWb0JGb3QwZ1lUaDFvQWdJQjRnVy91Q0g3TWJUdm9WOWU0TkFDeWs9");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
