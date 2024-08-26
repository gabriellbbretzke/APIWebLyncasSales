using MediatR;
using Microsoft.AspNetCore.Hosting;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.Context.Context;
using VendasLyncas.Infra.Context.Repositories;
using VendasLyncas.Infra.Data.Repositories;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Início");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationContext>();
        builder.Services.AddCors(options => options.AddPolicy("Cors",
            builder =>
            {
                builder.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            }));


        //Setup do projeto
        var assemblyDomain = AppDomain.CurrentDomain.Load("VendasLyncas.Domain");
        builder.Services.AddMediatR(assemblyDomain);
        builder.Services.AddTransient<IRepositoryCliente, RepositoryCliente>();
        builder.Services.AddTransient<IRepositoryVenda, RepositoryVenda>();
        builder.Services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();


        //EX: services.AddControllers();
        //services.AddMediatR(typeof(Startup));
        //services.AddSingleton<IRepository<Pessoa>, PessoaRepository>();

        //ApplicationBuild
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("Cors");

        app.MapControllers();

        app.Run();
        Console.WriteLine("Fim");
    }

    public static void IniciaSwagger(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(typeof(Program).Assembly);

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