using Elmah.Io.AspNetCore;
using Repositorio.Common.Classes.DTO.Exeptions;
using Repositorio.Config.Dependencies;
using Repositorio.Domain.Services.Authorization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromMinutes(10));
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
    app.UseMiddleware<JwtMiddleware>();
}
else
{
    app.UseMiddleware<ExceptionMiddleware>(false);
    app.UseMiddleware<JwtMiddleware>();
}
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
