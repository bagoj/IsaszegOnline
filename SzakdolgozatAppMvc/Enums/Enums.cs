using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzakdolgozatAppMvc.Enums
{
    public class Enums
    {
        public enum Position
        {
            Kapus = 0,
            Védő = 1,
            Középpályás = 2,
            Csatár = 3
        }   

        public enum CsapatAzon
        {
            Felnott = 0,
            Ifjusagi = 1,
            Noi = 2
        }

        public enum Roles
        {
            Admin = 0,
            Belepett = 1,
            Megtekinto = 2
        }
    }
}