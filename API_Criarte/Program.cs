
using API_Criarte.Application.Interfaces;
using API_Criarte.Application.Mappings;
using API_Criarte.Application.Services;
using API_Criarte.Application.Services.Gateway;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Infra.Data.Context;
using API_Criarte.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_Criarte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            string LocalString = Environment.GetEnvironmentVariable("LocalString");

            builder.Services.AddDbContext<dbContext>(options =>
            options.UseNpgsql(LocalString));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Respository
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IProponenteRepository, ProponenteRepository>();
            builder.Services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
            builder.Services.AddScoped<IEditalRepository, EditalRepository>();

            //Services
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IProponenteService, ProponenteService>();
            builder.Services.AddScoped<IModalidadeService, ModalidadeService>();
            builder.Services.AddScoped<IEditalService, EditalService>();

            builder.Services.AddScoped<ISendMailGateway, SendMailGateway>();


            builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("corsapp");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}