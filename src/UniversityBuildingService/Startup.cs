using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using UniversityBuildingService.Data;
using UniversityBuildingService.MessageBusClient;

namespace UniversityBuildingService
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"));
            });
            services.AddScoped<IUniversityBuildingRepository, UniversityBuildingRepository>();
            services.AddSingleton<IMessageBusClient, MessageBusClient.MessageBusClient>();
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(["http://localhost:4200", "http://localhost:8080"])
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
