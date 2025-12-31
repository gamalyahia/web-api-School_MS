using Microsoft.EntityFrameworkCore;

namespace School_Management_System.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(o => o.Teachers).WithMany(i => i.Students);
            modelBuilder.Entity<Teacher>().HasOne(o => o.Subject).WithMany(i => i.Teachers).HasForeignKey(i => i.SubjectId);
            modelBuilder.Entity<Laptop>().HasOne(e => e.Student).WithOne(o => o.Laptop).HasForeignKey<Laptop>(o => o.StudentId);
        }
    }
}
