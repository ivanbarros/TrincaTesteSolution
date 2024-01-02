using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Trinca.Domain.Entities;
using Trinca.Infra.Commands.Tasks;
using Trinca.Infra.Commands.Users;

namespace Trinca.Core.Configuration.Automapper
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());
        }
    }
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
