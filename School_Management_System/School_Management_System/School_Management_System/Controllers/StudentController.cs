    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using School_Management_System.DTO;
    using School_Management_System.Models;
    using School_Management_System.Repo;
    using System.Linq;

    namespace School_Management_System.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly ITeacherRepo teacherRepo;
        readonly IStudentRepo repo;
        public StudentController(IStudentRepo repo, ITeacherRepo teacherRepo)
        {
            this.repo = repo;
            this.teacherRepo = teacherRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO studentDTO)
        {
            var teachers = await teacherRepo.GetAll();
            var techs = teachers.Where(o => studentDTO.TeachersIDS.Contains(o.Id)).ToList();
            if (!techs.Any())
            {
                return NotFound();
            }

            var student = new Student
            {
                Name = studentDTO.Name,
                Email = studentDTO.Email,
                Teachers = techs,
                Laptop = new Laptop
                {
                    model = studentDTO.LaptopModel
                }
            };
            await repo.Add(student);
            await repo.Save();
            return Created();



        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await repo.GetAll();
            var teachers = await teacherRepo.GetAll();
            var st = students.Select(o => new ReadStudentDTO
            {
                Name = o.Name,
                Email = o.Email,
                Teachers = o.Teachers.Select(o => new ReadTeacherDTO
                {
                    Name = o.Name,
                    Email = o.Email,
                    phone = o.phone,
                    SubjectName = o.Subject.Name
                }).ToList()
            }).ToList();
            return Ok(st);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateStudentDTO studentDTO)
        {
            
            var student = await repo.GetStudentWithLaptop(id);
            if (student == null)
            {
                return NotFound();
            }
            var teachers = await teacherRepo.GetAll();
            var techs = teachers.Where(o => studentDTO.TeachersIDS.Contains(o.Id)).ToList();
            if (!techs.Any())
            {
                return NotFound();
            }
            student.Name = studentDTO.Name;
            student.Email = studentDTO.Email;
            if (student.Laptop == null)
            {
                student.Laptop = new Laptop
                {
                    model = studentDTO.LaptopModel
                };
            }
            else
            {
                student.Laptop.model = studentDTO.LaptopModel;
            }
            student.Teachers = techs;
             repo.Update(student);
            await repo.Save();
            var result = new ReadStudentDTO
            {
                Name = student.Name,
                Email = student.Email,
                LaptopModel = student.Laptop?.model,
                Teachers = student.Teachers.Select(t => new ReadTeacherDTO
                {
                    Name = t.Name,
                    Email = t.Email,
                    SubjectName = t.Subject?.Name,
                    phone = t.phone
                }).ToList()
            };
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Remove(int id)
        {
            var student = await repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            repo.Delete(student);
            await repo.Save();
            return Ok($"Student with ID:{student.Id} Removed");
        }
        }
    }
