using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Extention.configuration = Configuration;
           
        }

        public IConfiguration Configuration { get;  }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            //tblerror.Description = "Started";
            //_context.TblErrorlog.Add(tblerror);
            //_context.SaveChanges();
            try
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
                    var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"TaxiAppsWebAPICore.xml";
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
                services.AddAuthorization(config =>
                {
                    config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                    config.AddPolicy(Policies.superAdmin, Policies.superAdminPolicy());
                    config.AddPolicy(Policies.User, Policies.UserPolicy());
                });
                services.AddDbContext<TaxiAppzDBContext>(
                       //Options => Options.UseSqlServer(Configuration.GetConnectionString("TaxiAppzDB")).UseLazyLoadingProxies());
                       Options => Options.UseSqlServer(Configuration.GetConnectionString("TaxiAppzDB")));
                services.AddControllersWithViews()
         .AddNewtonsoftJson(options =>
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );
                //var cors = EnableCor(Configuration);

                //services.AddCors(addcor => {
                //    addcor.AddPolicy("AllowAll",
                //        sample => sample.WithOrigins(cors).AllowAnyMethod().AllowAnyHeader().
                //        AllowCredentials().WithExposedHeaders("Content-Disposition"));
                //});
                //services.AddCors(options =>
                //{
                //    options.AddPolicy("AllowAll", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                //        // Apply CORS policy for any type of origin  
                //        .AllowAnyMethod()
                //        // Apply CORS policy for any type of http methods  
                //        .AllowAnyHeader());
                //        // Apply CORS policy for any headers  
                //   //     .AllowCredentials()); 
                //   // Apply CORS policy for all users  
                //});
                //services.AddMvc(option => option.EnableEndpointRouting = false);
                //services.AddOptions();
                //services.AddMvc();
                //services.AddCors(options => options.AddPolicy("AllowAll", p => p.WithOrigins("http://localhost:4200")
                //                                                // .AllowAnyMethod()
                //                                                .WithMethods("GET", "PUT", "POST", "DELETE")
                //                                                 // .AllowAnyHeader()));
                //                                                 .WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header")));
            }
            catch (Exception ex)
            {
                TaxiAppzDBContext _context = new TaxiAppzDBContext();
                TblErrorlog tblerror = new TblErrorlog();
                tblerror.FunctionName = "ConfigureServices";
                tblerror.CreatedBy = "Startup.cs";
                tblerror.Description = ex.Message;
                _context.TblErrorlog.Add(tblerror);
                _context.SaveChanges();
            }
        }
        public string EnableCor(IConfiguration appSettings)
        {
            var serverName = System.Environment.MachineName;
            var fqhn = System.Net.Dns.GetHostEntry(serverName).HostName;
            var finalcors = "";
            List<string> corsPaths = new List<string>();
            corsPaths.AddRange(appSettings["CorsOrigins"].Split(',', StringSplitOptions.RemoveEmptyEntries));

            if (!string.IsNullOrEmpty(fqhn))
            {
                //if (Convert.ToBoolean(appSettings["UseHttps"]))
                //    corsPaths.Add($"https://{fqhn}:{appSettings["Port"]}");

                //if (Convert.ToBoolean(appSettings["UseMutualTls"]))
                //    corsPaths.Add($"https://{fqhn}:{appSettings["MutualTlsPort"]}");

                //if (Convert.ToBoolean(appSettings["UseHttp"]))
                //    corsPaths.Add($"http://{fqhn}:{appSettings["HttpPort"]}");

                for (int index = 0; index < corsPaths.Count; index++)
                {
                    var content = corsPaths[index];
                    content = content.Replace("{{Port}}", appSettings["Port"].ToString());
                    content = content.Replace("{{HttpPort}}", appSettings["HttpPort"].ToString());
                    content = content.Replace("{{DevPort}}", appSettings["DevPort"].ToString());
                    corsPaths[index] = content;

                }
            }

            return string.Join(",", corsPaths.ToArray());

            //return null;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                //app.UseMvc();
                //app.UseCors("AllowAll");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
                });

            }
            catch (Exception ex)
            {
                TaxiAppzDBContext _context = new TaxiAppzDBContext();
                TblErrorlog tblerror = new TblErrorlog();
                tblerror.FunctionName = "Configure";
                tblerror.CreatedBy = "Startup.cs";
                tblerror.Description = ex.Message;
                _context.TblErrorlog.Add(tblerror);
                _context.SaveChanges();

            }
        }
    }
}
