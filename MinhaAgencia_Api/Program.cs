using Microsoft.EntityFrameworkCore;
using MinhaAgencia_Api.Data;
using MinhaAgencia_Api.Repositorios;
using MinhaAgencia_Api.Repositorios.Interfaces;

namespace MinhaAgencia_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<MinhaAgencia_ApiDBContext>(
               Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
             );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IViagensRepositorio, ViagensRepositorio>();



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

        private static void AddDbContext<T>(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
