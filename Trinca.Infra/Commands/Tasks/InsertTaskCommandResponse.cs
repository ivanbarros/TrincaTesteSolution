using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Domain.Entities.Base;

namespace Trinca.Infra.Commands.Tasks
{
    public class InsertTaskCommandResponse : BaseEntity
    {
       
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
