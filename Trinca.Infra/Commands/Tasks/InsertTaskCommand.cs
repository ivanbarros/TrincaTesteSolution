using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Trinca.Domain.Entities.Base;

namespace Trinca.Infra.Commands.Tasks
{
    public class InsertTaskCommand : IRequest<InsertTaskCommandResponse>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime End { get; set; }

        [JsonPropertyName("idUser")]
        public Guid IdUser { get; set; }
    }
}
