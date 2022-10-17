using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using MS_API1_Users_API;
using MS_API1_Users_Model;
using MS_API1_Users_Repo;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

// Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(options =>
// {
//     options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//     {
//         Description = "Standard Autorization header using the Bearer scheme(\"bearer {token}\")",
//         In = ParameterLocation.Header,
//         Name = "Authorization",
//         Type = SecuritySchemeType.ApiKey
//     });
//     options.OperationFilter<SecurityRequirementsOperationFilter>();
// });

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: "MyAllowAllOrigins",
//     builder =>
//     {
//         builder.AllowAnyOrigin()
//             .AllowAnyHeader()
//             .AllowAnyMethod();
//     });
// });

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.Authority = builder.Configuration["Auth0:Domain"];
//     options.Audience = builder.Configuration["Auth0:Audience"];
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         NameClaimType = ClaimTypes.NameIdentifier
//     };
// });
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("weatherForecast: read-write", p =>
//         p.RequireAuthenticatedUser());
//     // .RequireClaim("permissions", "weatherforecast: read-write"));
// });

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
