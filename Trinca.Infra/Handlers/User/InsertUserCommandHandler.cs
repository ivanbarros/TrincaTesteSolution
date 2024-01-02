using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinca.Domain.Dtos;
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
        private readonly ILoginService _loginService;

        public InsertUserCommandHandler(IUserService service, ILogger<InsertUserCommandHandler> logger, IMediator mediator, IMapper mapper, ILoginService loginService)
        {
            _service = service;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _loginService = loginService;
        }

        public async Task<InsertUserCommandResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<UserEntity>(request);
                var result = await _service.Insert(entity);
                var dto = new LoginDto { Email = request.Email,Password = request.Pwd };
                var token = await _loginService.FindByLogin(dto);
                var response = new InsertUserCommandResponse();
                response.Token = token;
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
