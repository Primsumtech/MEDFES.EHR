using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Patient;
namespace MEDFES.EHR.Controllers
{
    [ApiController]
    [Route("patients")]
    public class PateintsController : ControllerBase
    {
        
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PateintsController> _logger;

        public PateintsController(ILogger<PateintsController> logger, IPatientRepository patientRepository)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        [HttpGet("getallpatients")]
        public async Task<IActionResult> GetPatients()
        {

            _logger.LogDebug("inside get method");
            var s=await _patientRepository.GetAllPatients();
            _logger.LogInformation("Log data:", s);
            return  Ok(s);
            
        }
    }
}