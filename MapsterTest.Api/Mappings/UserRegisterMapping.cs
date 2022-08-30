using Mapster;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Models;

namespace MapsterTest.Api.Mappings;

public class UserRegisterMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResponse>()
            .RequireDestinationMemberSource(true);
    }
}