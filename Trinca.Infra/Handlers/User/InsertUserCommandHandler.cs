using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Infra.Commands.Users;

namespace Trinca.Infra.Handlers.User
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, InsertUserCommandResponse>
    {
        public Task<InsertUserCommandResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
