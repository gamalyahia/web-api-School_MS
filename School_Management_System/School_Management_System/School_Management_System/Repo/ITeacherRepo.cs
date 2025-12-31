using School_Management_System.Models;

namespace School_Management_System.Repo
{
    public interface ITeacherRepo:IGenericRepo<Teacher>
    {
        Task<Teacher> GetTeacherWithId(int id);
    }
}
