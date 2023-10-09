using Entities;

namespace Service
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool UpdateUser(int userId,User user);
        User GetUserById(int userId);
        bool ValidateUser(int userId, string password);
        bool DeleteUser(int userId);
    }
}
