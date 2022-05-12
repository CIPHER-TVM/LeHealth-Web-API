using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LeHealth.Core;
using LeHealth.Core.DataManager;
using LeHealth.Core.Interface;
using LeHealth.Service;
using Microsoft.AspNetCore.Authentication;

using LeHealth.Service.ServiceInterface;
using LeHealth.Service.Service;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace LeHealth.Catalogue.API
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
            /* services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });*/
            //services.AddCors(c =>
            // {
            //     c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            // });

            //Authenticating JWT token and validating token
            //var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x => {
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = false;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});
            //         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["ApplicationSettings:Issuer"],
            //        ValidAudience = Configuration["ApplicationSettings:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"]))
            //    };
            //});
            services.ConfigureCors();
            services.AddControllers();
            // services.AddAutoMapper(typeof(AutoMapping));

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen();

            // adding the service dependencies injection
            services.AddScoped<IHospitalsService, HospitalsService>();
            services.AddScoped<IHospitalsManager, HospitalsManager>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
            services.AddScoped<IUserPermissionManager, UserPermissionManager>();
            services.AddScoped<ITodaysPatientService, TodaysPatientService>();
            services.AddScoped<ITodaysPatientManager, TodaysPatientManager>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountManager, AccountManager>();

            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IRegistrationManager, RegistrationManager>();


            services.AddScoped<IFormValidationService, FormValidationService>();
            services.AddScoped<IFormValidationManager, FormValidationManager>();

            services.AddScoped<IMasterDataService, MasterDataService>();
            services.AddScoped<IMasterDataManager, MasterDataManager>();

            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<IServiceOrderManager, ServiceOrderManager>();

            services.AddScoped<IMenuSubmenuManager, MenuSubmenuManager>();
            services.AddScoped<IMenuSubmenuService, MenuSubmenuService>();
            //
            services.AddScoped<IFileUploadService, FileUploadService>();


            services.AddScoped<IConsultantService, ConsultantService>();
            services.AddScoped<IConsultantManager, ConsultantManager>();

            //services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});
            app.UseStaticFiles(
                new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
                          "Origin, X-Requested-With, Content-Type, Accept");
                    },
                }
                );

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            //});
        }
    }
}
