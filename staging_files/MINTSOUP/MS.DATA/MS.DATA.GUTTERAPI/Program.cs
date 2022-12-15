//using MS.DATA;
using Microsoft.EntityFrameworkCore;
using MS.ACTIONS;
using MS.REPO;
//using MS.MODELS.DateAccess;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Idbaccess, dbaccess>();
builder.Services.AddScoped<Imsactions, msactions>();
builder.Services.AddScoped<IDBCONNECTION, DBCONNECTION>();
//builder.Services.AddDbContext(context => { context.GetService()});
//builder.Services.AddDbContext<MSDBCONTEXT>(context =>
//{
//    context.UseNpgsql(builder.Configuration.GetConnectionString("Development"));
//});
    //.AddScoped<IMSDBCONTEXT>(provider => provider.GetService<MSDBCONTEXT>()!);
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

