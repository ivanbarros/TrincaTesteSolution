using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Services;
using Trinca.Domain.Notifications;
using Trinca.Infra.Commands.Tasks;

namespace Trinca.Infra.Handlers.Tasks
{
    public class InsertTaskCommandHandler : IRequestHandler<InsertTaskCommand, InsertTaskCommandResponse>
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<InsertTaskCommandHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public InsertTaskCommandHandler(ITaskService taskService, ILogger<InsertTaskCommandHandler> logger, IMediator mediator, IMapper mapper)
        {
            _taskService = taskService;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<InsertTaskCommandResponse> Handle(InsertTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<TaskEntity>(request);
                
                var result = await _taskService.Insert(entity);
                
                var response = _mapper.Map<InsertTaskCommandResponse>(request);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                throw;
            }
        }
    }
    public sealed class TaskCommandValidator : AbstractValidator<InsertTaskCommand>
    {
        public TaskCommandValidator()
        {
            RuleFor(c => c).NotEmpty();
            RuleFor(c => c.Start).NotEmpty();
            RuleFor(c => c.End).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
