using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swapcode.IdentityServer.ForDevs.InMemory;

namespace Swapcode.IdentityServer.ForDevs
{
    // IdentityServer links:
    // https://identityserver4.readthedocs.io/en/release/quickstarts/0_overview.html
    // https://github.com/IdentityServer/IdentityServer4.Quickstart.UI

    public class Startup
    {
        // TODO: move the localhost address to single place and use that so that we don't need to write it to a million places

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add MVC
            services.AddMvc();
            // CORS
            services.AddCors();

            // setup IdentityServer to use the in memory configurations
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityResourcesConfig.GetIdentityResources())
                .AddInMemoryClients(ClientsConfig.GetClients())
                .AddTestUsers(UsersConfig.GetUsers());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:12345"); // this is your site(s) addresses
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}
