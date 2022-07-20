using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Repositorio.Common.Classes.DTO.Exeptions;
using Repositorio.Config.Dependencies;
using Repositorio.Domain.Services.Local;
using Repositorio.Infraestructura.Repositories.Database.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromMinutes(10));


builder.Services.AddCors(options => options.AddPolicy(name: "SuperHeroOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));


builder.Services.Configure<ElmahIoOptions>(builder.Configuration.GetSection("ElmahIo"));

builder.Services.AddElmahIo();

Local.Register(builder.Services, builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionMiddleware>(true);
}
else
{
    app.UseMiddleware<ExceptionMiddleware>(false);
}
app.UseCors("SuperHeroOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
