using FundooManager.Interface;
using FundooModelJS;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public string Register(RegisterModel user)
        {
            try
            {
                user.Password = EncodePasswordToBase64(user.Password);
                return this.repository.Register(user);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public string Login(LoginModel loginDetails)
        {
            try
            {
                loginDetails.Password = EncodePasswordToBase64(loginDetails.Password);
                return this.repository.Login(loginDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                return this.repository.ResetPassword(resetPassword);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }


            }
}
