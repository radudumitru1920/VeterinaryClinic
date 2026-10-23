using Microsoft.EntityFrameworkCore;
using VetClinicApp.Infrastructure.Data;
using VetClinicApp.Infrastructure.Services;
using VetClinicApp.Application.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<VetClinicAppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection"),
sqlServerOptions => sqlServerOptions.MigrationsAssembly("VetClinicApp.Infrastructure.Migrations")
));
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VetClinic API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        
    });

    options.AddSecurityRequirement(document =>
    {
        var requirement = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecuritySchemeReference("Bearer", document, null),
                new List<string>()
            }
        };

        return requirement;
    });
});



//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("JwtAuthentication");

            logger.LogInformation(
                "JWT request {Path}; authorization header present: {HasHeader}; token extracted: {HasToken}",
                context.HttpContext.Request.Path,
                context.Request.Headers.ContainsKey("Authorization"),
                !string.IsNullOrWhiteSpace(context.Token));

            return Task.CompletedTask;
        },
       
            OnAuthenticationFailed = context =>
        {
        
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[JWT ERROR]: {context.Exception.Message}");
            Console.ResetColor();
            return Task.CompletedTask;
        },
        
        OnChallenge = context =>
        {
            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("JwtAuthentication");

            logger.LogWarning(
                "JWT challenge for {Path}; authorization header present: {HasHeader}; error: {Error}; description: {Description}",
                context.HttpContext.Request.Path,
                context.Request.Headers.ContainsKey("Authorization"),
                context.Error,
                context.ErrorDescription);
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
       
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero

    };
   
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();



