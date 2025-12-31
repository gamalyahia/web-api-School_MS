using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.Repo
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        readonly AppDbContext context;
        public StudentRepo(AppDbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await context.Students.Include(o => o.Teachers).ThenInclude(o=>o.Subject).Include(o => o.Laptop).ToListAsync();
        }
        public async Task<Student?> GetStudentWithLaptop(int id)
        {
            return await context.Students
                .Include(s => s.Laptop)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(s => s.Id == id);
        }



    }
}
