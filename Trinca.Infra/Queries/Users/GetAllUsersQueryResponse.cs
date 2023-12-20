using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinca.Infra.Queries.Users
{
    public class GetAllUsersQueryResponse
    {
        public DateTime DtBirth { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
    }
}
