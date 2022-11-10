using System.Text.Encodings.Web;
using MINTSOUP.TokenAPI;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Iuserservice, userservice>();
builder.Services.AddScoped<IMSAlgos, MSAlgos>();
//builder.Services.AddSingleton<JavaScriptEncoder>();
//builder.Services.AddSingleton<UrlEncoder>();
//builder.Services.AddCors();
            //.WithOrigins("http://127.0.0.1:7215/", "http://127.0.0.1:4200/")
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

//builder.Services.AddCors(options => options.AddDefaultPolicy(
//    builder =>
//    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
//    //.AllowAnyOrigin()
//    .WithOrigins("https://*mint-soup.token", "https://*.token", "https://localhost:4200/*" , "https://localhost:4200/mint-soup.token/*")

//      .AllowAnyMethod()
//      .AllowCredentials()
//      .AllowAnyHeader()
//    )
//);


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

//app.UseCors("MyAllowAllOrigins");
//app.UseCors(_builder =>
//{
//    _builder
//    .AllowCredentials()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//});
app.UseAuthorization();

app.MapControllers();

app.Run();

