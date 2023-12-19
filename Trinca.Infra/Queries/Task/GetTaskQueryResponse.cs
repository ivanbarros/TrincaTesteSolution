using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinca.Infra.Queries.Task
{
    public class GetTaskQueryResponse
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid IdUser { get; set; }
    }
}
