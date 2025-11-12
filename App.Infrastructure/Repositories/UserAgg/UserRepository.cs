using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.TodoListAgg.Entities;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;
using App.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.UserAgg
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public bool IsUserNameExist(string userName)
        {
            return _context.Users.Any(u => u.UserName.ToLower() == userName);
        }

        public LoginUserDto Login(string userName)
        {
            return _context.Users.Where(u => u.UserName.ToLower() == userName)
                .Select(x => new LoginUserDto()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password

                }).FirstOrDefault();
        }

        public int Register(RegisterUserDto user)
        {
            User newUser = new User()
            {
                UserName = user.UserName,
                Password = user.Password
            };

            _context.Users.Add(newUser);
            return _context.SaveChanges();
        }

    }
}
