using eShop.Catalog.API.Service;
using eShop.Core;
using eShop.Core.Swagger;
using eShop.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace eShop.Catalog.API
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
            services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, SwaggerGenConfigurationOptions>();
            services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, SwaggerUIConfigurationOptions>();

            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);           
            services.AddApiVersioning(o => o.ReportApiVersions = true);
            services.AddVersionedApiExplorer(option =>
            {
                option.GroupNameFormat = "'v'VVV";
                option.SubstituteApiVersionInUrl = true;
            });            
            services.AddSwaggerGen();
                       
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped(typeof(IDocumentStore<>), typeof(DocumentStore<>));
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
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("default");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
