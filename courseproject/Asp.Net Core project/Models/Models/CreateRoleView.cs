﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core_project.Models
{

    public class CreateRoleViewModel
    {
        [Required]
        public string Role { get; set; }
    }
}
