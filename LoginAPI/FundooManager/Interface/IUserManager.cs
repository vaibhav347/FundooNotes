using FundooModelJS;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel user);
        string Login(LoginModel loginDetails);
        bool ResetPassword(ResetPasswordModel resetPassword);
       // string EncodePasswordToBase64(string password);
    }
}
