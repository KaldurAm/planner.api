using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Planner.BLL.Interfaces;
using Planner.BLL.Services;
using Planner.BLL.Services.Auth;
using Planner.BLL.Services.GetInfo;
using Planner.BLL.Util;
using Planner.DAL.Tables;
using Serilog;

namespace Planner.API
{
    public class Startup
    {
        private const string CORS_POLICY = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Planner API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                var allowedOrigins = Configuration.GetSection("AllowedHosts").Value.Split(';');
                options.AddPolicy(name: CORS_POLICY, policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDatabaseConfiguration(Configuration);
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IObjectService, ObjectService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IHistoryService<TaskHistory>, HistoryService<TaskHistory>>();
            services.AddScoped<IHistoryService<ObjectHistory>, HistoryService<ObjectHistory>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORS_POLICY);

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner API Version 1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
