using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.UserAgg.Dtos;

namespace App.Domain.Core.UserAgg.Contracts
{
    public interface IUserRepository
    {
        LoginUserDto Login(string userName);
        int Register(RegisterUserDto user);
        bool IsUserNameExist(string userName);
        GetUserTasksDto GetUserTasks(int userId);
    }
}
