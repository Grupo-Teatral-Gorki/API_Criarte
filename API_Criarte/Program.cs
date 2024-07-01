
using API_Criarte.Application.DTOs;
using API_Criarte.Application.Gateway;
using API_Criarte.Application.Interfaces;
using API_Criarte.Application.Interfaces.Gateway;
using API_Criarte.Application.Mappings;
using API_Criarte.Application.Services;
using API_Criarte.Application.Services.Gateway;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Infra.Data.Context;
using API_Criarte.Infra.Data.Repositories;
using API_Criarte.Infra.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddInfrasctructureSwagger();

            //Respository
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IProponenteRepository, ProponenteRepository>();
            builder.Services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
            builder.Services.AddScoped<IEditalRepository, EditalRepository>();
            builder.Services.AddScoped<ISegmentoRepository, SegmentoRepository>();
            builder.Services.AddScoped<IDespesasRepository, DespesasRepository>();
            builder.Services.AddScoped<IDetentoresRepository, DetentoresRepository>();
            builder.Services.AddScoped<IFontesFinanciamentoRepository, FontesFinanciamentoRepository>();
            builder.Services.AddScoped<IFonteFinanciamentoRepository, FonteFinanciamentoRepository>();
            builder.Services.AddScoped<IGrupoDespesasRepository, GrupoDespesasRepository>();
            builder.Services.AddScoped<IIntegrantesRepository, IntegrantesRepository>();
            builder.Services.AddScoped<ILocaisRepository, LocaisRepository>();
            builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
            builder.Services.AddScoped<IResponsaveisTecnicosRepository, ResponsaveisTecnicosRepository>();
            builder.Services.AddScoped<IRubricaRepository, RubricaRepository>();
            builder.Services.AddScoped<ITipoUnidadeRepository, TipoUnidadeRepository>();
            builder.Services.AddScoped<IDocumentosProjetoRepository, DocumentosProjetoRepository>();
            builder.Services.AddScoped<IDocumentosProponenteRepository, DocumentosProponenteRepository>();

            //Services
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IProponenteService, ProponenteService>();
            builder.Services.AddScoped<IModalidadeService, ModalidadeService>();
            builder.Services.AddScoped<IEditalService, EditalService>();
            builder.Services.AddScoped<ISegmentoService, SegmentoService>();
            builder.Services.AddScoped<IProjetoService, ProjetoService>();
            builder.Services.AddScoped<IAmazonS3Service, AmazonS3Service>();
            builder.Services.AddScoped<IDocumentosProjetoService, DocumentosProjetoService>();
            builder.Services.AddScoped<IDocumentosProponenteService, DocumentosProponenteService>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ISendMailGateway, SendMailGateway>();
            builder.Services.AddScoped<IAmazonS3Gateway, AmazonS3Gateway>();


            builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            string AwsBucketName = Environment.GetEnvironmentVariable("CriarteBucket");
            string AwsKeyID = Environment.GetEnvironmentVariable("CriarteKeyID");
            string AwsKeySecret = Environment.GetEnvironmentVariable("CriarteSecret");

            builder.Services.Configure<AwsVariablesDTO>(options =>
            {
                options.bucketName = AwsBucketName ?? "";
                options.AwsKeyID = AwsKeyID ?? "";
                options.AwsKeySecret = AwsKeySecret ?? "";
            });

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