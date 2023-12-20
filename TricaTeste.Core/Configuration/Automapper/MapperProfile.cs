using AutoMapper;
using Trinca.Domain.Entities;
using Trinca.Infra.Commands.Tasks;
using Trinca.Infra.Commands.Users;

namespace Trinca.Core.Configuration.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<InsertTaskCommand, InsertTaskCommandResponse>().ReverseMap();
            CreateMap<TaskEntity, InsertTaskCommand>().ReverseMap();
            CreateMap<UserEntity, InsertUserCommand>().ReverseMap();
        }
    }
}
