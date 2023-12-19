using Microsoft.AspNetCore.Mvc;
using TrincaTeste.Domain.Interfaces.Services;

namespace TrincaTesteWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("tarefas")]
        public async Task<IActionResult> Get() 
        {
            var result = await _service.GetAll();
            return Ok();
        }
    }
}
