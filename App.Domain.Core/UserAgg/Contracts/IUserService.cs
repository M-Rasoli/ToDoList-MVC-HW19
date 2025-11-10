using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Readify.Domain._common.Entities;

namespace App.Domain.Core.UserAgg.Contracts
{
    public interface IUserService
    {
        Result<bool> Login(string userName, string password);
        Result<bool> Register(RegisterUserDto user);
    }
}
