
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using AutoMapper;

// Use APX Context
using APX.Models.Context;
using APX.Models.Context.Creator;
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
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
