using DevTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevTest.DAL
{
    public class DevTestContext : DbContext
    {
        private readonly string _connectionString;

        public DevTestContext()
        {

        }

        public DevTestContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevTestDatabase");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<SocialSkill> SocialSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<SocialSkill>().HasKey(s => s.SkillId);
            modelBuilder.Entity<SocialSkill>().Property(s => s.Description).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<SocialSkill>().HasOne(s => s.Person).WithMany(p => p.SocialSkills)
                .HasForeignKey(s => s.PersonId);

            modelBuilder.Entity<SocialAccount>().HasKey(s => s.AccountId);
            modelBuilder.Entity<SocialAccount>().Property(s => s.Type).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<SocialAccount>().Property(s => s.Address).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<SocialAccount>().HasOne(s => s.Person).WithMany(p => p.SocialAccounts)
                .HasForeignKey(s => s.PersonId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
