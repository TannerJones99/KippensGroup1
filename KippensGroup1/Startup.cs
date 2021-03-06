using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KippensGroup1
{
    public class Startup
    {
        private string uid; // go to data files and change your mysql login
        private string pwd;
        private string connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            uid = MysqlLogins.getMySqlUser();
            pwd = MysqlLogins.getMySqlPass();
            connectionString ="server=localhost; uid=" + uid + "; pwd=" + pwd + ";";
            
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            DBHandler dbHander = new DBHandler(connectionString);
            if (!dbHander.checkIfDBExist())
            {
                dbHander.createDB();
            }
            CurrentLogged.logout();
            services.AddTransient<DBHandler>(_ => new DBHandler(connectionString));
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        
    }
}
