using Microsoft.AspNetCore.Mvc;

namespace SupportPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoiceController : ControllerBase
    {
        [HttpPost("convert")]
        public IActionResult ConvertAccent([FromBody] string inputText)
        {
            // Simulate accent conversion logic
            string converted = inputText.Replace("r", "rr"); // dummy accent change
            return Ok(new { original = inputText, converted });
        }
    }
}