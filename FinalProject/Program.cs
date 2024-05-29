using MyProject.Repository.Interfaces;
using MyProject.Service.Services;
using MyProject.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using DataContext11;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddDbContext<IContext,Db>();

//builder.Services.Configure<IISServerOptions>(options =>
//options.AllowSynchronousIO = true
//) ;
builder.Services.Configure<FormOptions>(option =>
{

    option.ValueLengthLimit = int.MaxValue;
    option.MultipartBodyLengthLimit = int.MaxValue;
    //   // option.MultipartBodyLengthLimit = long.MaxValue;
    //    option.MultipartBodyLengthLimit = 50 * 1024 * 1024;

    //    option.MemoryBufferThreshold = int.MaxValue;
    //    option.ValueCountLimit = int.MaxValue;
});
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 100_000_000_000;
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://www.contoso.com").AllowAnyHeader().AllowAnyMethod();
    }
        );
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

