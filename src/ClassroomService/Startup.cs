using ClassroomService.Data;
using ClassroomService.Data.Implementations;
using ClassroomService.Data.Interfaces;
using ClassroomService.EventProcessor;

using Microsoft.EntityFrameworkCore;

namespace ClassroomService
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddHostedService<MessageBusSubscriber.MessageBusSubscriber>();
            services.AddSingleton<IEventProcessor, EventProcessor.EventProcessor>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
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
