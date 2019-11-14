using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Data;
using courseProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace courseProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlite("Filename=icap.db");
            });
            services.AddMvc();

            services.AddScoped<RolesService>();
            services.AddScoped<IRolesRepo, RolesRepo>();

            services.AddScoped<SurveysService>();
            services.AddScoped<ISurveysRepo, SurveysRepo>();

            services.AddScoped<TherapiesService>();
            services.AddScoped<ITherapiesRepo, TherapiesRepo>();

            services.AddScoped<UsersService>();
            services.AddScoped<IUsersRepo, UsersRepo>();

            services.AddScoped<VideosService>();
            services.AddScoped<IVideosRepo, VideosRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
        }
    }
}
