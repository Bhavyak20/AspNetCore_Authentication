using AspNetCore_Authentication.Services;
using Microsoft.AspNetCore.Mvc;
using static AspNetCore_Authentication.Controllers.LoginController;

namespace AspNetCore_Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        IJwtAuthenticationService _authenticationService;
        public LoginController(IJwtAuthenticationService authenticationService)
        {
            _authenticationService= authenticationService;
        }

        [HttpPost]
        [Route("LoginUser")]
        //https://localhost:7024/api/Login/LoginUser
        public IActionResult LoginUser([FromBody] CustomerDTO customerdto)
        {
            if(customerdto.UserName=="Bhavya" && customerdto.Password == "Bhavya@123")
            {
                var token = _authenticationService.GenerateToken(customerdto.UserName, "Customer");
                return Ok(token);

            }
            else if(string.IsNullOrEmpty(customerdto.UserName) || string.IsNullOrEmpty(customerdto.Password))
            {
                return BadRequest("Username or Password cannot be empty");
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }

        public class CustomerDTO
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
