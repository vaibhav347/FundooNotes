﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModelJS
{
   public class ResetPasswordModel
    {
        [Required]

        public string Email { get; set; }

        public string Password { get; set; }
    
    }
}
