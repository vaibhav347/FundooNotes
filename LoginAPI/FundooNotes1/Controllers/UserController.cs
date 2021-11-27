using FundooManager.Interface;
using FundooModelJS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes1.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Result([FromBody] RegisterModel user)

        {
            try
            {
                string message = this.manager.Register(user);
                if (message.Equals("Register Successful"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }

        }




        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message = this.manager.Login(loginDetails);
                if (message.Equals("Login Successful"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        Status = false,
                        Message = message
                    });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ResetPassword")]

        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            try
            {

                bool result = this.manager.ResetPassword(resetPassword);
                if (result == true)
                {

                    return this.Ok(new { Status = true, Message = "Password Reset Successfull !" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Password Reset Unsuccessfull!. Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }




    }
}
