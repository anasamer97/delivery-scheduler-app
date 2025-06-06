
using CallCenterAPI.Classes;
using CallCenterAPI.Context;
using CallCenterAPI.Enum;
using CallCenterAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<ApplicatinDBContext>(options =>
	        options.UseSqlServer("Server=.;Database=CallCenterAPI;Trusted_Connection=True;TrustServerCertificate=true"));
            

			// Add services to the container.
			

           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
			builder.Services.AddCors();
			builder.Services.AddScoped<DeliveryService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
			app.UseCors(policy => policy
	            .WithOrigins("http://localhost:5173") // or wherever your frontend runs
	            .AllowAnyHeader()
	            .AllowAnyMethod()
            );



			app.MapControllers();

            app.Run();

        }
    }
}
