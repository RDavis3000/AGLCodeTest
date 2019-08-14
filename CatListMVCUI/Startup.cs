using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatListMVCUI.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetOwnerService;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;

namespace CatListMVCUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var catListMVCConfig = Configuration.GetSection("CatListMVCConfig").Get<CatListMVCConfig>();

            services.AddSingleton<IReadPetOwners, WebApiPetOwnerReader>(di => new WebApiPetOwnerReader(catListMVCConfig.ApiEndpoint, di.GetRequiredService<ILogger<WebApiPetOwnerReader>>()));
            services.AddSingleton<IMapCatToOwnersGender, CatToOwnersGenderMapper>();
            services.AddSingleton<IGetCatMapService,GetCatMapService>(di => new GetCatMapService(di.GetRequiredService<IReadPetOwners>(),di.GetRequiredService<IMapCatToOwnersGender>(),di.GetRequiredService<ILogger<GetCatMapService>>()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=CatList}/{id?}");
            });
        }
    }
}
