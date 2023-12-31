﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Trinca.Domain.Interfaces.Services;
using Trinca.Infra.Commands.Tasks;
using Trinca.Infra.Queries.Task;

namespace TrincaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {

        [HttpGet]
        [Route("tarefas")]
        [SwaggerOperation(
            Summary = "Seleciona todas as tarefas"
        )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetTaskAllQuery());
            return Ok();
        }

        [HttpPost]
        [Route("tarefas")]
        [SwaggerOperation(
            Summary = "Inserção das tarefas"
        )]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromServices] IMediator mediator, [FromBody] InsertTaskCommand command)
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
