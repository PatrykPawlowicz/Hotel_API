using Hotel_API.Data;
using Hotel_API.Dtos.User;
using Hotel_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto req)
        {
            var response = await _authRepo.Register(
                new User { name = req.name, surname = req.surname, email = req.email }, req.password
            );
            if (!response.success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(UserLoginDto req)
        {
            var response = await _authRepo.Login(req.email, req.password);
            if (!response.success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}