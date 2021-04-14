﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdvert.Web.Models.Accounts
{
    public class ConfirmModel
    {
        [Required(ErrorMessage = "E-Mail is required")]
        [Display(Name ="E-Mail")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
    }
}
