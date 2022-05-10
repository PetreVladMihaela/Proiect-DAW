using Microsoft.OpenApi.Models;
using backend_proiect.Entities;
using Microsoft.EntityFrameworkCore;
using backend_proiect.Repositories;
using backend_proiect.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace backend_proiect
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_allowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "proiect", Version = "v1" });

            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
            //          Enter 'Bearer' [space] and then your token in the text input below.
            //          \r\n\r\nExample: 'Bearer 12345abcdef'",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header
            //            },
            //            new List<string>()
            //        }
            //    });
            });

            //Edit here Connection String after creating a new local Database
            //This Connection String will not work on your PCs
            //services.AddDbContext<backend_proiectContext>(options => options.UseSqlServer(@"Server=(localdb)\ProjectModels;Initial Catalog=backend_proiect;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddDbContext<backend_proiectContext>(options => options.UseSqlServer(@"Server=(localdb)\ProjectModels;Initial Catalog=backend_proiect;"));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //         .AddEntityFrameworkStores<backend_proiectContext>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer("AuthScheme", options =>
            //{
            //    options.SaveToken = true;
            //    var secret = Configuration.GetSection("Jwt").GetSection("SecretKey").Get<String>();
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        RequireExpirationTime = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

            //services.AddAuthorization(opt =>
            //{
            //    opt.AddPolicy("User", policy => policy.RequireRole("User").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            //    opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            //});


            //Install Microsoft.AspNetCore.Mvc.NewtonsoftJson
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            /*services.AddTransient - new instance of the service for each class that injects it
              services.AddScoped - same instance of the service for the entire duration of the request
              services.AddSingleton - one single instance in the entire app
            */

            services.AddTransient<ICountriesRepository, CountriesRepository>();
            services.AddTransient<ICountriesManager, CountriesManager>();

            services.AddTransient<ILandmarksRepository, LandmarksRepository>();
            services.AddTransient<ILandmarksManager, LandmarksManager>();

            services.AddTransient<ILocationsRepository, LocationsRepository>();
            services.AddTransient<ILocationsManager, LocationsManager>();

            services.AddTransient<IVisitorsRepository, VisitorsRepository>();
            services.AddTransient<IVisitorsManager, VisitorsManager>();

            //services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            //services.AddTransient<ITokenManager, TokenManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "proiect v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("_allowSpecificOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
