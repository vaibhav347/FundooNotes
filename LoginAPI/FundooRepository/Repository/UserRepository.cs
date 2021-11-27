using FundooModelJS;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
      


        public UserRepository(UserContext context)
        {
            this.context = context;
        }
        public string Register(RegisterModel user)
        {
            try
            {
                var ifExist = this.context.Users.Where(x => x.Email == user.Email).SingleOrDefault();
                if (ifExist == null)
                {
                    this.context.Users.Add(user);
                    this.context.SaveChanges();
                    return "Register Successful";

                }
                return "Email already exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public string Login(LoginModel loginDetails)
        {
            try
            {
                var ifEmailExist = this.context.Users.Where(x => x.Email == loginDetails.Email && x.Password == loginDetails.Password).SingleOrDefault();
                if (ifEmailExist != null)
                {
                    return "Login Successful";
                }
                return "Email not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public bool ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                var userPassword = this.context.Users.Where(x => x.Email == resetPassword.Email).FirstOrDefault();
                // resetPassword.Password = repository.EncodePasswordToBase64(resetPassword.Password);

                if (userPassword != null)
                {
                    this.context.Update(userPassword);
                    this.context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

        }

        public string EncodePasswordToBase64(string password)
        {
            throw new NotImplementedException();
        }
    }
}
