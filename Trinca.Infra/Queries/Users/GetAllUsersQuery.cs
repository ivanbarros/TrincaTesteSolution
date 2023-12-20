using MediatR;

namespace Trinca.Infra.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersQueryResponse>>
    {
    }
}
