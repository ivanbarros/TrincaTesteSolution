using MediatR;
using Microsoft.Extensions.Logging;
using Trinca.Domain.Interfaces.Services;
using Trinca.Infra.Queries.Task;

namespace Trinca.Infra.Handlers.Tasks
{
    public class GetTaskAllQueryHandler : IRequestHandler<GetTaskAllQuery, IEnumerable<GetTaskQueryResponse>>
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<GetTaskAllQueryHandler> _logger;

        public GetTaskAllQueryHandler(ITaskService taskService, ILogger<GetTaskAllQueryHandler> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        public async Task<IEnumerable<GetTaskQueryResponse>> Handle(GetTaskAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<GetTaskQueryResponse> listResult = new List<GetTaskQueryResponse>();
                var result = await _taskService.GetAll();
                foreach (var item in result)
                {
                    GetTaskQueryResponse response = new GetTaskQueryResponse
                    {
                        End = item.End,
                        Start = item.Start,
                        IdUser = item.IdUser
                    };
                    listResult.Add(response);
                }
                _logger.LogInformation("Request realizado com sucesso");
                return listResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no request");
                throw;
            }

        }
    }
}
