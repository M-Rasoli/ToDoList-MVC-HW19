using App.Domain.Core._common.Entities;
using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.Contracts
{
    public interface IUserAppService
    {
        Result<LoginUserDto> Login(string userName, string password);
        Result<bool> Register(RegisterUserDto user);
        Result<GetUserTasksDto> GetUserTasks(int userId);
    }
}
