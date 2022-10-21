using MS_API1_Users_API;
using MS_API1_Users_LogicLayer;
using MS_API1_Users_Model;
using MS_API1_Users_Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IGET_LogicLayer, GET_LogicLayer>();
builder.Services.AddScoped<IGET_AccessLayer, GET_AccessLayer>();
builder.Services.AddScoped<ICREATE_AccessLayer, CREATE_AccessLayer>();
builder.Services.AddScoped<ICREATE_LogicLayer, CREATE_LogicLayer>();
builder.Services.AddScoped<ICHECK_AccessLayer, CHECK_AccessLayer>();
builder.Services.AddScoped<IDELETE_AccessLayer, DELETE_AccessLayer>();


builder.Services.AddSwaggerGen();

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
