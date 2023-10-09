using System;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    public class UserServ : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServ(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public bool DeleteUser(int userId)
        {
            // Check if the user exists
            var existingUser = _userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with ID {userId} not found.");
            }

            // Call the repository to delete the user
            return _userRepository.DeleteUser(userId);
        }

        public User GetUserById(int userId)
        {
            // Call the repository to get the user by ID
            return _userRepository.GetUserById(userId);
        }

        public bool RegisterUser(User user)
        {
            // Business logic and validation (if needed)
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            // Call the repository to register the user
            return _userRepository.RegisterUser(user);
        }

        public bool UpdateUser(int userId, User user)
        {
            // Check if the user exists
            var existingUser = _userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with ID {userId} not found.");
            }

           

            return _userRepository.UpdateUser(user);
        }

        public bool ValidateUser(int userId, string password)
        {
            
            return _userRepository.ValidateUser(userId, password);
        }
    }
}
