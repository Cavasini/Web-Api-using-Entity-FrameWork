using Look.Dtos;
using Look.Model;

namespace Look.Service.UsersService
{
    public interface IUsersInterface
    {
        Task<ServiceResponse<List<Users>>> GetUsers();
        Task<ServiceResponse<List<Users>>> CreateUser(CreateUserDto userDto);
        Task<ServiceResponse<bool>> CheckUserExistence(string userName, string password);


    }
}
