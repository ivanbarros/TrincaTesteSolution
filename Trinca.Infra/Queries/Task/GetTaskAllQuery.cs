using MediatR;

namespace Trinca.Infra.Queries.Task
{
    public class GetTaskAllQuery : IRequest<IEnumerable<GetTaskQueryResponse>>
    {
    }
}
