using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaziappzMobileWebAPI.TaxiModels;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.DALayer;

namespace TaziappzMobileWebAPI
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //  c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Core API",  Description = "Swagger Core API" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Core API",
                    Description = "Swagger Core API"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                       {
                         new OpenApiSecurityScheme
                         {
                           Reference = new OpenApiReference
                           {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                           }
                          },
                          new string[] { }
                        }
                      });
                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"TaziappzMobileWebAPI.xml";
                c.IncludeXmlComments(xmlPath);
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.RequireHttpsMetadata = false;
       options.SaveToken = true;
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"), //"https://localhost:44374/", 
           ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),  //https://localhost:44374/"
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:SecretKey"))), // new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nplustechnologies")),
           ClockSkew = TimeSpan.Zero
       };
   });
            services.AddDbContext<TaxiAppzDBContext>(
         //Options => Options.UseSqlServer(Configuration.GetConnectionString("TaxiAppzDB")).UseLazyLoadingProxies());
         Options => Options.UseSqlServer(Configuration.GetConnectionString("TaxiAppzDB")));
            services.AddControllersWithViews()
     .AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );
            services.Configure<JWT>(Configuration.GetSection("Jwt"));
            services.AddScoped<IToken, Token>();
            services.AddScoped<ISign, DASign>();
            services.AddScoped<IValidate, DADriverValidate>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            });
        }
    }
}
