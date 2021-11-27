using FundooModelJS;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        string Register(RegisterModel user);
        string Login(LoginModel loginDetails);
        bool ResetPassword(ResetPasswordModel resetPassword);
       // string EncodePasswordToBase64(string password);
    }
}
