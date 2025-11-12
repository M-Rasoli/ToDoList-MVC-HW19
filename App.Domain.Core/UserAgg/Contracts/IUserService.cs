using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;

namespace App.Domain.Core.UserAgg.Contracts
{
    public interface IUserService
    {
        LoginUserDto Login(string userName);
        int Register(RegisterUserDto user);
        //GetUserTasksDto GetUserTasks(int userId);
        bool IsUserNameExist(string userName);
    }
}
