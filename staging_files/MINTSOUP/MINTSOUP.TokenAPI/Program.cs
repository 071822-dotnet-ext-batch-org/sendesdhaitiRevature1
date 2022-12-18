using System.Text.Encodings.Web;
using MINTSOUP.TokenAPI;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Iuserservice, userservice>();
builder.Services.AddScoped<IMSAlgos, MSAlgos>();

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

            ValidIssuer = "https://localhost:7215",
            ValidAudience = "https://localhost:7215",
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

