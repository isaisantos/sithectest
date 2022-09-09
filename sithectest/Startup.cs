using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sithectest.Models;
using System;
using Microsoft.OpenApi.Models;
using System.IO;

namespace sithectest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            /// Activa la herramienta Sweagger para documentación y pruebas
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"SITHEC Test {groupName}",
                    Version = groupName,
                    Description = "Reclutamiento .Net",
                    Contact = new OpenApiContact
                    {
                        Name = "Sithec",
                        Email = string.Empty,
                        Url = new Uri("https://sithec.com.mx/Home/index"),
                    }
                });

                /// Establece el archivo XML de comentarios para la documetación 
                var basePath = AppContext.BaseDirectory;
                var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
                var xmlPath = Path.Combine(basePath, fileName);
                options.IncludeXmlComments(xmlPath);
            });


            services.AddControllers();

            services.AddDbContext<sithec_testContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("sithectestContext")));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SITHEC Test V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
