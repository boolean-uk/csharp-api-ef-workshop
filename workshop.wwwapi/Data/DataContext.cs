using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for the join table
            modelBuilder.Entity<PersonSubject>()
                .HasKey(ps => new { ps.PersonId, ps.SubjectId });

            // Relationships
            modelBuilder.Entity<PersonSubject>()
                .HasOne(ps => ps.Person)
                .WithMany(p => p.PersonSubjects)
                .HasForeignKey(ps => ps.PersonId);

            modelBuilder.Entity<PersonSubject>()
                .HasOne(ps => ps.Subject)
                .WithMany(s => s.PersonSubjects)
                .HasForeignKey(ps => ps.SubjectId);

            // Optional: Configure table names and schema
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<PersonSubject>().ToTable("PersonSubjects");
        }
        public DbSet<Calculation> Calculations { get; set; }    
        public DbSet<Person> People { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<PersonSubject> PersonSubjects { get; set; }
    }
}
