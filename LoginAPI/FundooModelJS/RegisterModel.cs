using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModelJS
{
    public class RegisterModel
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        //[RegularExpression("",ErrorMessage="E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
