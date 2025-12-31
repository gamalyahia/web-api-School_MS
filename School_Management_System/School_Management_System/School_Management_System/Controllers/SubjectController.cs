using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTO;
using School_Management_System.Models;
using School_Management_System.Repo;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        readonly IGenericRepo<Subject> repo;
        public SubjectController(IGenericRepo<Subject> repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult>CreateSubject(CreateSubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var sub = new Subject
            {
                Name = subjectDTO.Name,
                Description = subjectDTO.Description
            };
            await repo.Add(sub);
            await repo.Save();
            return Created();

        }
    }
}
