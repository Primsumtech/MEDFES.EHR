using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application;
using Application.UseCases.Authentication;
using MEDFES.EHR.API.Controllers.Dtos;
using Domains.Entities.Users;
using Application.UseCases.User;
using Application.DTO.User;

namespace MEDFES.EHR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;
        private readonly IAuthenticationUsecase _authenticationUsecase;
        private readonly IUserUsecase _userUsecase;

        public UsersController(ILogger<UsersController> logger,IUserRepository userRepository, IAuthenticationUsecase authenticationUsecase , IUserUsecase userUsecase)
        {
            _logger = logger;
            _userRepository = userRepository;
            _authenticationUsecase = authenticationUsecase;
            _userUsecase = userUsecase;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {

            _logger.LogDebug("inside get method"); 
            var s=await _userRepository.GetAllAsync();
            _logger.LogInformation("Log data:", s);
            return  Ok(s);
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginParameterDto parametets)
        {

            if (parametets == null || string.IsNullOrEmpty(parametets.UserName) || string.IsNullOrEmpty(parametets.Password))
            {
                return BadRequest();
            }
            UserLoginEntity userLoginEntity = await _authenticationUsecase.Login(parametets.UserName, parametets.Password);


            return Ok(userLoginEntity ?? new UserLoginEntity());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserParameterDto parametets)
        {

            if (parametets==null)
            {
                return BadRequest();
            }

            var result = await _userUsecase.AddUserAsync(parametets);


            return Ok(result);
        }
    }
}