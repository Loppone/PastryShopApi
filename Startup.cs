using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Concrete;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.DAL.Concrete;
using PastryShopApi.ModelPastryShop;
using System;

namespace PastryShopApi
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
            services.AddCors(o =>
            {
                o.AddPolicy(
                    "CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PastryShopApi", Version = "v1" });
            });

            services.AddScoped<IAuth, AuthManager>();
            services.AddScoped<IRepoAuth, RepositoryAuthentication>();
            services.AddScoped<IVetrina, VetrinaOperations>();
            services.AddScoped(typeof(IReader<DolciInVenditum>), typeof(RepositoryVetrinaReader));
            services.AddScoped(typeof(IReader<Dolce>), typeof(RepositoryDolceReader));
            services.AddScoped<IVetrinaDolciWriter, RepositoryVetrinaWriter>();
            services.AddScoped<ICalcolatorePrezzo, CalcolatorePrezzo>();
            services.AddScoped<IDolce, DolceOperations>();
            services.AddScoped<IDolciWriter, RepositoryDolceWriter>();


            services.AddDbContext<ModelPastryShop.PastryShopContext>(opt =>
            opt.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "PastryShopApi v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
