using Microsoft.EntityFrameworkCore;
using VetClinicApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<VetClinicAppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection"),
sqlServerOptions => sqlServerOptions.MigrationsAssembly("VetClinicApp.Infrastructure.Migrations")
));


var app = builder.Build();


app.Run();



