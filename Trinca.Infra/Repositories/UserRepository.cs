using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Repoisitories;
using Trinca.Infra.Data;
using Trinca.Infra.Repositories.Base;

namespace Trinca.Infra.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(EFContext context) : base(context)
        {
        }

        
    }
}
