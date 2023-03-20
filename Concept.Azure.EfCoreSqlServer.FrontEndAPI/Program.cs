using Concept.Azure.EfCoreSqlServer.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Concept.Azure.EfCoreSqlServer.FrontEndAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Entity Framework Initialization
            builder.Services.AddDbContext<BisonDataContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("BisonDataContext") ?? throw new InvalidOperationException("Connection string 'BisonDataContext' not found."),
               x => x.MigrationsAssembly("Concept.Azure.EfCoreSqlServer.DataAccess"))); // Assembly of Data Context

            // Add services to the container.

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


            app.MapControllers();

            app.Run();
        }
    }
}