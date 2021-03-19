using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.EFRespositories;
using TestWebApi.IRespositories;
using TestWebApi.IServices;
using TestWebApi.Services;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace TestWebApi
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
            services.AddMemoryCache();
            services.AddSingleton(Configuration);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRespository, UserRepository>();
            services.AddTransient<IDemoService, DemoService>();
            services.AddTransient<IDemoRespository, DemoRepository>();
            // 数据库连接
            services.AddTransient<IDbConnection>((provider) =>
                new SqlConnection(Configuration["ConnectionStrings:ZgDB"]));
            services.AddSwaggerGen(c => c.SwaggerDoc("1.0", new OpenApiInfo { Title = "zzzz", Version = "1.0" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
