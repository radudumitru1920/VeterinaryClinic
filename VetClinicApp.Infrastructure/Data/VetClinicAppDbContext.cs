using Microsoft.EntityFrameworkCore;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
namespace VetClinicApp.Infrastructure.Data
{
    public class VetClinicAppDbContext : DbContext
    {
        public VetClinicAppDbContext(DbContextOptions<VetClinicAppDbContext> options)
            : base(options)
        { 
        }
        public DbSet<Client> Clients {get;set;}
        public DbSet<Pet> Pets {get;set;}
        public DbSet<Appointment> Appointments {get;set;}
        public DbSet<Staff> Staffs{get;set;}
        public DbSet<AssistantRequest> AssistantRequests{get;set;}
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            {
            modelbuilder.Entity<Pet>()
            .Property(p => p.Tip)
            .HasConversion<string>();
            }
            {
              modelbuilder.Entity<Pet>()
              .HasOne(a => a.Client)
              .WithMany(b => b.Pets)
              .HasForeignKey(c => c.clientID)
              .OnDelete(DeleteBehavior.Cascade);
            }
            {
                modelbuilder.Entity<Appointment>()
                .Property(p => p.Status)
                .HasConversion<string>();
            }
            {
                modelbuilder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(b => b.Appointments)
                .OnDelete(DeleteBehavior.Cascade);
            }
            {
                modelbuilder.Entity<Staff>()
                .Property(p => p.Role)
            .HasConversion<string>();
            }
            {
                modelbuilder.Entity<AssistantRequest>()
                .HasKey(p => p.requestID);
            }
            {
                modelbuilder.Entity<AssistantRequest>()
                .Property(p => p.Status)
                .HasConversion<string>();
            }
                
            {
                modelbuilder.Entity<ClientDoctor>()
                .HasKey(p => p.staffID);
            }
            
        }
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VeterinaryClinicDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}