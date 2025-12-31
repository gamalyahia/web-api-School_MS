using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.Repo
{
    public class TeacherRepo : GenericRepo<Teacher>, ITeacherRepo
    {
        readonly AppDbContext appDb;
        public TeacherRepo(AppDbContext dbContext) : base(dbContext)
        {
            appDb = dbContext;
        }

        public async Task<Teacher> GetTeacherWithId(int id)
        {
            return await appDb.Teachers.Include(o => o.Subject).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
