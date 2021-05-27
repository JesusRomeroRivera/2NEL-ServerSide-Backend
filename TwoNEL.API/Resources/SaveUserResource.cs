﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoNEL.API.Resources
{
    public class SaveUserResource
    {
        public SaveEntrepreneurResource Profile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        public SaveCreditCardResource CreditCard { get; set; }
    }
}
