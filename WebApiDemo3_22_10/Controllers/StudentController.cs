using Microsoft.AspNetCore.Mvc;
using WebApiDemo3_22_10.Dtos;
using WebApiDemo3_22_10.Entities;
using WebApiDemo3_22_10.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo3_22_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            var items = await _studentService.GetAll();
            var dataToReturn = items.Select(s =>
            {
                return new StudentDto
                {
                    Id = s.Id,
                    Age = s.Age,
                    Fullname = s.Fullname,
                    Score = s.Score,
                    SeriaNo = s.SeriaNo,
                };
            });
            return dataToReturn;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _studentService.Get(s => s.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            var dto = new StudentDto
            {
                Id = item.Id,
                Score = item.Score,
                Age = item.Age,
                Fullname = item.Fullname,
                SeriaNo = item.SeriaNo
            };
            return Ok(dto);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentAddDto dto)
        {
            var entity = new Student
            {
                Age = dto.Age,
                Fullname = dto.Fullname,
                Score = dto.Score,
                SeriaNo = dto.SeriaNo
            };
            await _studentService.Add(entity);
            return Ok(dto);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
