using KUFM8A_HFT_2021221.Data;
using KUFM8A_HFT_2021221.Logic;
using KUFM8A_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KUFM8A_HFT_2021221.Endpoint
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IMobileLogic, MobileLogic>();
            services.AddTransient<ICpuLogic, CpuLogic>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IMobileRepository, MobileRepository>();
            services.AddTransient<ICpuRepository, CpuRepository>();
            services.AddTransient<MobileDbContext, MobileDbContext>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
