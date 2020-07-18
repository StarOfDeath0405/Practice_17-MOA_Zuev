using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using practice.Models;

namespace practice
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
            services.AddDbContext<GroupsContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection")
                )
            );
            services.AddDbContext<StudentsContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    //public class Startup1
    //{
    //    public Startup1(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddDbContext<LibraryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
    //        services.AddScoped<IDataRepository<Authors, AuthorsDTO>, AuthorsDataManager>();
    //        services.AddSingleton<IConfiguration>(Configuration);
    //        services.AddMvc()
    //            .AddJsonOptions(
    //                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    //            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

    //        AppDomain.CurrentDomain.GetAssemblies();

    //        services.AddAuthentication
    //            (c =>
    //            {
    //                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //            }
    //            ).AddJwtBearer
    //            (cfg =>
    //            {
    //                cfg.RequireHttpsMetadata = false;
    //                cfg.SaveToken = true;
    //                cfg.TokenValidationParameters = new TokenValidationParameters()
    //                {
    //                    ValidateIssuer = false,
    //                    ValidateAudience = false,
    //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
    //                };
    //            }
    //             );
    //    }
    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }
    //        else
    //        {
    //            app.UseHsts();
    //        }

    //        app.UseHttpsRedirection();
    //        app.UseAuthentication(); //Seguridad
    //        app.UseMvc();
    //    }
    //}


}
