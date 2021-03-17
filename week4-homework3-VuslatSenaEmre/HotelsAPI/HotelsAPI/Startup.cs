using System;
using System.Text;
using System.Linq;
using System.Transactions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hotels.API.Filters;
using Hotels.API.Models;
using Hotels.API.Services;
using Hotels.API.Contexts;
using Hotels.API.Controllers;
using Hotels.API.Infrastructure;
using Hotels.API.Models.Derived;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true); 
            services.AddSwaggerDocument();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new MediaTypeApiVersionReader();

                /* Versiyonlama stratejileri 3 şekildedir. Derste MediaTypeApiVersionReader için olanını gördük. */

                //2- QueryStringApiVersionReader() 
                //Postman : Url'e versiyon bilgisi ekleyip GET işlemini sağlayabiliriz.
                //options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                //https://localhost:44359/test?api-version=2.0 bu şekilde yazarsak versiyona göre metotlar tetiklenecetir.

                //3-HeaderApiVersionReader. 
                //‘HeaderApiVersionReader’ nesnesine verilen ‘api-version’ deðeri, header’da sürüm bilgisini taşıyacak olan key’e karşılık geliyor.
                //Postman: GET yaparken header kısmında key alanına gidip api-version, value kısmında versiyonu yazarsak ilgili metotlar tetikleniyor.
                //options.ApiVersionReader = new HeaderApiVersionReader("api-version");

                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
                options.Conventions.Controller<TestController>()
                       .HasDeprecatedApiVersion(1, 0)
                       .HasApiVersion(1, 1)
                       .HasApiVersion(2, 0)
                       .Action(a => a.GetCustomers()).MapToApiVersion(1, 1)
                       .Action(a => a.GetCustomerV2()).MapToApiVersion(2, 0);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3();
                app.UseOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    //Bu Kısım derste yaptığımı yer
   /* public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<HotelInfo>(
                Configuration.GetSection("HotelInfo")
            );

            services.AddDbContext<HotelApiDbContext>(options => 
            {
                options.UseInMemoryDatabase("HotelDB");
            });

            services.AddControllers(options => 
            {
                options.Filters.Add(typeof(JsonExceptionFilters));
                options.Filters.Add<AllowOnlyRequireHttps>();
            });

            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(option => option.AddProfile<MappingProfile>());
            services.AddScoped<IRoomService,RoomService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddSession()


            string key  = Configuration.GetValue<string>("JwtTokenKey");
            byte[] keyValue = Encoding.UTF8.GetBytes(key);

            services.AddAuthentication(auth => 
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                // development sürecinde false olarak set edilebilir.
                jwt.RequireHttpsMetadata = true;
               // jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyValue),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ClockSkew = 
                };
            });

            services.AddHostedService<RoomWorkerService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerDocument();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();

                /*
                    options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                    options.ApiVersionReader = new QueryStringApiVersionReader("v");
                */
/*

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector  = new CurrentImplementationApiVersionSelector(options);
                

                options.Conventions.Controller<TestController>()
                        .HasDeprecatedApiVersion(1,0)
                        .HasApiVersion(1,1)
                        .HasApiVersion(2,0)
                        .Action(a => a.GetCustomers()).MapToApiVersion(1,1)
                        .Action(a => a.GetCustomerV2()).MapToApiVersion(2,0);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3();
                app.UseOpenApi();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }*/
}