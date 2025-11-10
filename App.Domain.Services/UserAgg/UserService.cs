using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using Readify.Domain._common.Entities;

namespace App.Domain.Services.UserAgg
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public Result<bool> Login(string userName, string password)
        {
            var user = userRepository.Login(userName);
            if (user is null)
            {
                return Result<bool>.Failure(message:"نام کاربری یا رمز عبور اشتباه است.");
            }

            if (user.Password != password)
            {
                return Result<bool>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<bool>.Success(message:"خوش آمدید");
            }
                
        }

        public Result<bool> Register(RegisterUserDto user)
        {
            if (user.UserName == null ||
                user.Password == null)
            {
                return Result<bool>.Failure(message:"فیلد های اجباری باید کامل شوند.");
            }
            if (userRepository.IsUserNameExist(user.UserName))
            {
                return Result<bool>.Failure(message:"نام کاربری قبلا استفاده شده است.");
            }

            if (user.Password.Length < 3)
            {
                return Result<bool>.Failure(message:"رمز عبور حداقل باید شامل 3 کاراکتر باشد.");
            }

            var result = userRepository.Register(user);
            if (result > 0)
            {
                return Result<bool>.Success(message:"ثبت نام با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure(message:"مشکلی پیش آمده لحظاتی بعد تلاش کنید.");
            }

        }
    }
}
