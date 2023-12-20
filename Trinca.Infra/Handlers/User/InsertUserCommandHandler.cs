using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Services;
using Trinca.Domain.Notifications;
using Trinca.Infra.Commands.Users;

namespace Trinca.Infra.Handlers.User
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, InsertUserCommandResponse>
    {
        private readonly IUserService _service;
        private readonly ILogger<InsertUserCommandHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InsertUserCommandHandler(IUserService service, ILogger<InsertUserCommandHandler> logger, IMediator mediator, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<InsertUserCommandResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<UserEntity>(request);
                var result = _service.Insert(entity);
                var response = _mapper.Map<InsertUserCommandResponse>(result);
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
    public sealed class UserCommandValidator : AbstractValidator<InsertUserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.DtBirth).NotEmpty();
            RuleFor(c => c.Pwd).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
