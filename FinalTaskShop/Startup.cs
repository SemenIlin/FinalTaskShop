using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLShop.WEB.Interfaces;
using BLShop.WEB.Services;
using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using DAShop.WEB.Models.ForGood;
using DAShop.WEB.Models.ForRentalSpaces;
using DAShop.WEB.Repositories;
using DAShop.WEB.Repositories.ForEmployee;
using DAShop.WEB.Repositories.ForGood;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalTaskShop
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
            services.AddRazorPages();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connection));

            services.AddScoped<DbContext, ShopContext>();

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<BonusOrFine>, BonusOrFineRepository>();
            services.AddScoped<IRepository<Position>, PositionRepository>();
            services.AddScoped<IRepository<SickLeave>, SickLeaveRepository>();
            services.AddScoped<IRepository<Departament>, DepartamentRepository>();
            services.AddScoped<IRepository<PaymentAccount>, PaymentAccountRepository>();

            services.AddScoped<IRepository<Good>, GoodRepository>();
            services.AddScoped<IRepository<ReportOfSale>, ReportOfSaleRepository>();
            services.AddScoped<IRepository<Repair>, RepairRepository>();
            services.AddScoped<IRepository<Transportation>, TransportationRepository>();

            services.AddScoped<IRepository<RentalSpace>, RentalSpaceRepository>();

            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IReportOfSaleService, ReportOfSaleService>();
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IRentalSpaceService, RentalSpaceService>();
            services.AddScoped<IPaymentAccountService, PaymentAccountService>();

            services.AddMvc();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); 
            }); 
        }
    }
}
