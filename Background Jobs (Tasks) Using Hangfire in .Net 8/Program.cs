
using Background_Jobs__Tasks__Using_Hangfire_in_.Net_8.Model;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace Background_Jobs__Tasks__Using_Hangfire_in_.Net_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("appconnetion")));
            builder.Services.AddHangfireServer();

            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("appconnetion"))
         );
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();
            app.UseHangfireDashboard("/dashboard");

            app.MapControllers();

            app.Run();
        }
    }
}
