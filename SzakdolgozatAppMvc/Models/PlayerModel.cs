﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzakdolgozatAppMvc.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int CsapatId { get; set; }
        public string Name { get; set; }
        public int? PosztId { get; set; }
        public int? Age { get; set; }
        public int? Bornyear { get; set; }
    }
}