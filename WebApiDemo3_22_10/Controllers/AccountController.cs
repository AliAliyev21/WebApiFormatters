using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApiDemo3_22_10.Dtos;
using WebApiDemo3_22_10.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo3_22_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public AccountController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // POST api/<AccountController>
        [HttpPost("SignIn")]
        public async Task<string> Post([FromBody] SignInDto dto)
        {
            var student = await _studentService.Get(x => x.Username == dto.Username && x.Password == dto.Password);
            if (student != null)
            {
                var token = student.Username + ":" + student.Password;
                var returnedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
                return returnedToken;
            }
            return "";
        }

    }
}
