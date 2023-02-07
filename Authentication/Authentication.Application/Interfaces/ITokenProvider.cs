using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Interfaces;
public interface ITokenGenerator
{
    string Generate(IdentityUser user);
}