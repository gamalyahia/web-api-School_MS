using School_Management_System.Models;

namespace School_Management_System.Repo
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetStudentWithLaptop(int id);
    }
}
