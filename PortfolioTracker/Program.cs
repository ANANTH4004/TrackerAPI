using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortfolioTracker.Models;
using System.Text;

string CORSOpenPolicy = "OpenCORSPolicy";
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

// Add services to the container.

builder.Services.AddDbContext<TrackerContext>(opions => opions.UseSqlServer(
    builder.Configuration.GetConnectionString("Tracker") ?? throw new InvalidOperationException("Connection string 'Tracker Connection String' not found.")));

//To use the AppSettings section in Json File
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("ApplicationSettings")
    );
//Adding JWT in the form of Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApplicationSettings:Secret"])),
        ValidateIssuer =false,
        ValidateAudience= false

    };
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
app.UseCors(CORSOpenPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
