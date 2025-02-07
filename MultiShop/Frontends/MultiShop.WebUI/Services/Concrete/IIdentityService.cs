using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Concrete
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
    }
}
