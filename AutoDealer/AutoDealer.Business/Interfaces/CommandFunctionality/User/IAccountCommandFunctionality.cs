﻿using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.User;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.User
{
    public interface IAccountCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<UserCreateCommand>
    {
        Task UpdateAsync(UserUpdateCommand command);
        Task UpdateActiveStatusAsync(UserUpdateActiveStatusCommand command);
        Task ResetPasswordAsync(UserResetPasswordCommand command);
        Task UpdatePasswordAsync(UserUpdatePasswordCommand command);
    }
}
