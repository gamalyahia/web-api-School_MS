using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTO;
using School_Management_System.Models;
using School_Management_System.Repo;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly IGenericRepo<Subject> repo1;
        readonly ITeacherRepo repo;
        public TeacherController(ITeacherRepo repo,IGenericRepo<Subject> genericRepo)
        {
            this.repo = repo;
            repo1 = genericRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDTO teacherDTO)
        {
            var subjects = await repo1.GetAll();
            var subjectID = await repo1.GetById(teacherDTO.SubjectId);
            if (subjectID == null)
            {
                return NotFound("The subject ID is not found");
            }
            var techer = new Teacher
            {
                Name = teacherDTO.Name,
                Email = teacherDTO.Email,
                phone = teacherDTO.phone,
                SubjectId = teacherDTO.SubjectId
            };
            await repo.Add(techer);
            await repo.Save();
            return Created();
 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetTeacher(int id)
        {
            var teacher = await repo.GetTeacherWithId(id);
            if (teacher == null)
            {
                return NotFound();                
            }
            var tech = new ReadTeacherDTO
            {
                Name = teacher.Name,
                Email = teacher.Email,
                phone = teacher.phone,
                SubjectName = teacher.Subject.Name
            };
            return Ok(tech);
        }
    }
}
