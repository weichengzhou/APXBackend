
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

using AutoMapper;

// Use APX Context
using APX.Models.Context;
using APX.Repositories;
using APX.Services;
using APX.Services.UnitOfWork;
using APX.Controllers.Converter.JSON;
using APX.Swagger.Example;

namespace APXBackend
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
            var connection = this.Configuration.GetConnectionString("DefaultConnection");
            // DI Repository
            this.AddRepositories(services);
            // DI Unit Of Work
            this.AddUnitOfWork(services);
            // DI Service
            this.AddServices(services);
            // DI DbContext
            this.AddDbContext(services);
            services.AddDbContext<APXContext>(
                options => options.UseSqlServer(connection));
            // Change DateTime convert format
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));
            });
            // Add AutoMapper : Mapping DTO and Entities
            // dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(typeof(Startup));
            this.AddSwagger(services);
            this.DisableModelValidation(services);
        }


        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICodeKindRepository, CodeKindRepository>();
            services.AddScoped<ICodeRepository, CodeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
        }


        private void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICodeKindService, CodeKindService>();
            services.AddScoped<ICodeService, CodeService>();
        }


        private void AddDbContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, APXContext>();
        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                // Use swagger example.
                c.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerExamplesFromAssemblyOf<ErrorResponseExample>();
            this.AddSwaggerCodeExample(services);
            this.AddSwaggerCodeKindExample(services);
        }


        private void AddSwaggerCodeExample(IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblyOf<CreateCodeResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<GetCodesResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<GetCodeResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<UpdateCodeResponseExample>();
        }


        private void AddSwaggerCodeKindExample(IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblyOf<CreateCodeKindResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<GetCodeKindsResponseExample>();
        }


        private void DisableModelValidation(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "APX API");
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
