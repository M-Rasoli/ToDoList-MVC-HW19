using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;

namespace App.Domain.AppService.UserAgg
{
    public class UserAppService(IUserService userService) : IUserAppService
    {
        public Result<GetUserTasksDto> GetUserTasks(int userId)
        {
            var result = userService.GetUserTasks(userId);
            if (result is not null)
            {
                return Result<GetUserTasksDto>.Success(message: "", result);
            }
            else
            {
                return Result<GetUserTasksDto>.Failure(message: "لیست کار های شما خالی است.");
            }
        }

        public Result<LoginUserDto> Login(string userName, string password)
        {
            var user = userService.Login(userName);
            if (user is null)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }

            if (user.Password != password)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<LoginUserDto>.Success(message: "خوش آمدید", user);
            }
        }

        public Result<bool> Register(RegisterUserDto user)
        {
            if (user.UserName == null ||
                user.Password == null)
            {
                return Result<bool>.Failure(message: "فیلد های اجباری باید کامل شوند.");
            }
            if (userService.IsUserNameExist(user.UserName))
            {
                return Result<bool>.Failure(message: "نام کاربری قبلا استفاده شده است.");
            }

            if (user.Password.Length < 3)
            {
                return Result<bool>.Failure(message: "رمز عبور حداقل باید شامل 3 کاراکتر باشد.");
            }

            var result = userService.Register(user);
            if (result > 0)
            {
                return Result<bool>.Success(message: "ثبت نام با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده لحظاتی بعد تلاش کنید.");
            }
        }
    }
}
