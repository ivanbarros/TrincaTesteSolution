using MediatR;
using Microsoft.Extensions.Logging;
using Trinca.Domain.Interfaces.Services;
using Trinca.Infra.Queries.Users;

namespace Trinca.Infra.Handlers.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryResponse>>
    {
        private readonly IUserService _service;
        private readonly ILogger<GetAllUsersHandler> _logger;

        public GetAllUsersHandler(IUserService service, ILogger<GetAllUsersHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IEnumerable<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<GetAllUsersQueryResponse> list = new List<GetAllUsersQueryResponse>();
            var users = await _service.GetAll();
            foreach (var user in users) 
            {
                GetAllUsersQueryResponse queryResponse = new GetAllUsersQueryResponse 
                {
                    Document = user.Document,
                    DtBirth = user.DtBirth,
                    Email = user.Email,
                    Name = user.Name,
                    Pwd = user.Pwd
                };
                list.Add(queryResponse);
            }
            return list;
        }
    }
}
