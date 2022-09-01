using Mapster;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Models;

namespace MapsterTest.Api.Extensions;

public class CodeGenerationConfig : ICodeGenerationRegister
{
    public void Register(Mapster.CodeGenerationConfig config)
    {
        config.AdaptTo("[name]")
            .ForType<User>()
            .ForType<UserResponse>();
    }
}