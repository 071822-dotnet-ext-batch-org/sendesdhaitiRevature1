//using MS.DATA;
using Microsoft.EntityFrameworkCore;
using MS.ACTIONS;
using MS.REPO;
//using MS.MODELS.DateAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Idbaccess, dbaccess>();
builder.Services.AddScoped<Imsactions, msactions>();
builder.Services.AddScoped<IDBCONNECTION, DBCONNECTION>();
builder.Services.AddScoped<Idbcheck, dbcheck>();
builder.Services.AddScoped<Idbcreate, dbcreate>();


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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

