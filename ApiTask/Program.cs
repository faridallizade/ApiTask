using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Implementatitons;
using ApiTask.Repositories.Interfaces;
using ApiTask.Services.Implementations;
using ApiTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IBrandRepo,BrandRepo>();
            builder.Services.AddScoped<IBrandService,BrandServices>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(opt=>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });


            var app = builder.Build();

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