using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application;
namespace MEDFES.EHR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger,IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {

            _logger.LogDebug("inside get method");
            var s=await _userRepository.GetAllAsync();
            _logger.LogInformation("Log data:", s);
            return  Ok(s);
            
        }
    }
}