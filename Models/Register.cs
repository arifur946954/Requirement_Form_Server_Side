﻿using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Register
    {
        public decimal RegisterId { get; set; }
        public string? Mobilenumber { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? Refreshtoken { get; set; }
        public DateTime? Refreshtokenexpirytime { get; set; }
    }
}
