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
        public DbSet<User> Users  {get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Staff> Staffs{ get; set; }
        public DbSet<AssistantRequest> AssistantRequests{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            {
            modelbuilder.Entity<User>()
            .HasIndex(c => c.Email)
            .IsUnique();
            }
            {
                modelbuilder.Entity<Appointment>()
                .Property(p => p.Time)
                .HasColumnType("time(0)");
            }

            {
             modelbuilder.Entity<Appointment>()
            .Property(p => p.Status)
            .HasConversion<string>();
            }

          //  {
           //     modelbuilder.Entity<Appointment>()
           //     .HasOne(a => a.User)
            //    .WithMany(b => b.Appointments)
           //     .OnDelete(DeleteBehavior.Cascade);
           // }

            {
                modelbuilder.Entity<Staff>()
                .Property(p => p.Role)
            .HasConversion<string>();
            }

            {
                modelbuilder.Entity<AssistantRequest>()
                .HasKey(p => p.RequestId);
            }

            {
                modelbuilder.Entity<AssistantRequest>()
                .Property(p => p.Status)
                .HasConversion<string>();
            }
                
            
        }
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VetClinicDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}