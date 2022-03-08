using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using Microsoft.Extensions.Options;
using CertiWeb.Services;

namespace CertiWeb
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
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.Configure<IngresoBancarioDatabaseSettings>(
                Configuration.GetSection(nameof(IngresoBancarioDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<IngresoBancarioDatabaseSettings>>().Value);

            services.AddSingleton<BookService>();
            services.AddSingleton<IngresoBancarioService>();
            services.AddSingleton<DispersionService>();
            services.AddSingleton<UserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CertiWeb", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("PolicyName", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CertiWeb v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
             //.AllowCredentials()
             );
        }
    }
}
