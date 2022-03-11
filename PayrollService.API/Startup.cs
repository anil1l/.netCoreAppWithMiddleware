using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PayrollService.Business.PayrollGeneration;
using PayrollService.Business.PayrollGeneration.Concretes;
using PayrollService.Core.PayrollDatabaseRepositories;
using PayrollService.Business.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;

namespace PayrollService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataAccess.Contexts.PayrollDatabaseContext>(options =>
                                            options.UseSqlServer(Configuration.GetConnectionString("PayrollService")), ServiceLifetime.Transient);

            services.AddTransient<IPayrollGenerationService, PayrollGenerationService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeSalaryDetailsRepository, EmployeeSalaryDetailsRepository>();
            services.AddTransient<IEmployeeWorkingActivitiesRepository, EmployeeWorkingActivitiesRepository>();

            services.AddTransient<BasicSalaryCalculator>();
            services.AddTransient<OvertimeSalaryCalculator>();
            services.AddTransient<DailySalaryCalculator>();
            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
