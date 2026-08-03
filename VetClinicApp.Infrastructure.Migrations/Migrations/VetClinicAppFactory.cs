using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VetClinicApp.Infrastructure.Data;

namespace VetClinicApp.Infrastructure.Migrations;

public class VetClinicAppDbContextFactory : IDesignTimeDbContextFactory<VetClinicAppDbContext>
{
    public VetClinicAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VetClinicAppDbContext>();
        
        // Configurăm conexiunea către SQL Server Express local
        optionsBuilder.UseSqlServer(
            "Server=.\\SQLEXPRESS;Database=VetClinicDb;Trusted_Connection=True;TrustServerCertificate=True;",
            b => b.MigrationsAssembly(typeof(VetClinicAppDbContextFactory).Assembly.FullName)
        );

        return new VetClinicAppDbContext(optionsBuilder.Options);
    }
}