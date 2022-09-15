using Application.UseCases.Authentication;
using Domains.Entities.Users;
using MEDFES.EHR.API.Controllers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEDFES.EHR.API.Controllers.Authentication
{
    [ApiController]
    [Route("[controller]")]
   
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationUsecase _iAuthenticationUsecase;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationUsecase iAuthenticationUsecase)
        {
            _logger = logger;
            _iAuthenticationUsecase = iAuthenticationUsecase;
        }
        //[HttpPost]
        //[Route("login")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginParameterDto userLoginParameterDto)
        {

            if (userLoginParameterDto == null || string.IsNullOrEmpty(userLoginParameterDto.UserName) || string.IsNullOrEmpty(userLoginParameterDto.Password))
            {
                return BadRequest();
            }
            UserLoginEntity userLoginEntity = await _iAuthenticationUsecase.Login(userLoginParameterDto.UserName, userLoginParameterDto.Password);


            return Ok(userLoginEntity ?? new UserLoginEntity());
        }
    }
    
}

