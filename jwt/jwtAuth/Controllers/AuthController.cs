using jwtAuth.Models;
using jwtAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuth.Controllers
{

    [Route("Api/Controller")]
    [ApiController]

    public class AuthController : ControllerBase
    { 

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }


        [HttpPost("token")]
        
        public async Task<IActionResult>loginAsync(TokenRequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var getToken= await _authService.GetTokenAsync(model);

            if (!getToken.IsAuthenticated)
                return BadRequest(getToken.Message);
            return Ok(getToken);

        }





        [HttpPost("role")]

        public async Task<IActionResult> AddroleAsync(AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AddingRole = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(AddingRole))
                return BadRequest(AddingRole);

            return Ok(AddingRole);

        }


    }
            
            
            


    
}
