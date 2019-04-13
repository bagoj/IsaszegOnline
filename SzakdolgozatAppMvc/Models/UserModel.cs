﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzakdolgozatAppMvc.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? City { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}