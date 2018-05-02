using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using VSfirstdotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace VSfirstdotnet
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
                 
            services.AddDbContext<LinkContext>(options => options.UseSqlite(Configuration.GetConnectionString("LinkConnection")));
            services.AddTransient<ILinkRepo, LinkRepo>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
 
            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/")
                .MapRoute("unshorten", "{controller=Unshorten}/{action=Index}/{id}")
                .MapRoute("Del", "{controller=LinkApi}/{action=Delete}/{id}")
                .MapRoute("GetLink", "{controller=LinkApi}/{action=GetLink}/{shortLink}")
                .MapRoute("AddLink", "{controller=LinkApi}/{action=AddLink}/{longLink}")
                .MapRoute("EditLink", "{controller=LinkApi}/{action=EditLink}/{longLink}")
                .MapRoute("GetOneLink", "{controller=LinkApi}/{action=GetOneLink}/{id}")
                .MapRoute("linkApi", "{controller=LinkApi}/{action=Read}/{page}");

            });
        }
    }
}
