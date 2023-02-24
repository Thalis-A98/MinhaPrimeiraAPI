using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinhaPrimeiraAPI.Data;
using MinhaPrimeiraAPI.Repository;
using MinhaPrimeiraAPI.Repository.Interfaces;

namespace MinhaPrimeiraAPI
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

            string conexaoMySQL = builder.Configuration.GetConnectionString("Database");
            builder.Services.AddDbContext<SistemadeCadastroDBContext>(options => options.UseMySql(conexaoMySQL, MySqlServerVersion.AutoDetect(conexaoMySQL)));

            builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();

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