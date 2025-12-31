
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        readonly AppDbContext appDb;
        public GenericRepo(AppDbContext dbContext)
        {
            appDb = dbContext;
        }
        public async Task Add(T entity)
        {
           await appDb.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            appDb.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await appDb.Set<T>().ToListAsync();   
        }

        public async Task<T> GetById(int id)
        {
            return await appDb.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await appDb.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            appDb.Set<T>().Update(entity);
        }
    }
}
