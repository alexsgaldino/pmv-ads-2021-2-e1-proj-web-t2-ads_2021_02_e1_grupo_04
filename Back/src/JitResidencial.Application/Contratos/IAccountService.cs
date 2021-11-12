using System.Threading.Tasks;
using JitResidencial.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace JitResidencial.Application.Contratos
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string passwor);
        Task<UserDto> CreateAccountAsync(UserDto userDto);
        Task<UserUpdateDto> UpdateAccountAsync(UserUpdateDto userUpdateDto);
    }

}