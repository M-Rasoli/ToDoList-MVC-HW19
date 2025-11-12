using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;

namespace App.Domain.Services.UserAgg
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        //public GetUserTasksDto GetUserTasks(int userId)
        //{
        //    return userRepository.GetUserTasks(userId);
        //}

        public bool IsUserNameExist(string userName)
        {
            return userRepository.IsUserNameExist(userName);
        }

        public LoginUserDto Login(string userName)
        {
            return userRepository.Login(userName);
        }

        public int Register(RegisterUserDto user)
        {
            return userRepository.Register(user);
        }
    }
}
