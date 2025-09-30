using AspNetCore_Authentication.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankTransactionController:ControllerBase
    {
        IJwtAuthenticationService _authenticationService;
        public BankTransactionController(IJwtAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("BankTransaction")]
        //https://localhost:7024/api/BankTransaction/BankTransactionDetails
        public IActionResult BankTransactionDetails([FromHeader] string Token )
        {
            var _message = "Customes can see this transaction";
            return Ok(new { Message = _message });
        }
    }
}
