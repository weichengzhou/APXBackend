
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


using AutoMapper;

// Use APX Context
using APX.Models.Context;
using APX.Repositories;
using APX.Services;
using APX.Services.UnitOfWork;
using APX.Controllers.Converter.JSON;

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
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICodeKindRepository, CodeKindRepository>();
            services.AddScoped<ICodeRepository, CodeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            // DI Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // DI Service
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICodeKindService, CodeKindService>();
            services.AddScoped<ICodeService, CodeService>();
            // DI DbContext
            services.AddScoped<DbContext, APXContext>();
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseMvc();
        }
    }
}
