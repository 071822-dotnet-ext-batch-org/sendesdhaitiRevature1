// using BusinessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;

// using MS_API1_Users_API;
using MS_API1_Users_LogicLayer;
using MS_API.Models;
// using MS_API1_Users_Model;
using MS_API1_Users_Repo;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IDBCONNECTION, DBCONNECTION>();
builder.Services.AddScoped<IDB_ACCESS, DB_Access>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Autorization header using the Bearer scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowAllOrigins",
    builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//valid if the issuer is the action server that created the token
            ValidateAudience = true,//the reciever of the token is a valid recipient
            ValidateLifetime = true,//the token is not expired
            ValidateIssuerSigningKey = true,//the signing key is valide and translated by the server

            ValidIssuer = "http://localhost:7215",
            ValidAudience = "http://localhost:7215",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"MINTSOUP|BY|SENDES"))
        };
    });

builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme);

    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyAllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
