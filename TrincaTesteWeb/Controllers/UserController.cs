using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Trinca.Domain.Interfaces.Services;
using Trinca.Infra.Commands.Users;

namespace TrincaTesteWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("usuarios")]
        [Authorize]
        [SwaggerOperation(
            Summary = "Seleciona todos os usuarios"
        )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get([FromServices] IUserService service)
        {
            var result = await service.GetAll();
            return Ok();
        }

        [HttpPost]
        [Route("usuarios")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Cadastro de novo usuário"
        )]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromServices] IMediator mediator, [FromBody] InsertUserCommand command)
        {
            try
            {
                var result = mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
