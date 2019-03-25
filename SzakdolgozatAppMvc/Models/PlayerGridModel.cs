using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SzakdolgozatAppMvc.BusinessLogic;

namespace SzakdolgozatAppMvc.Models
{
    public class PlayerGridModel
    {
        public int Id { get; set; }
        public int CsapatId { get; set; }
        public string Name { get; set; }
        public string Poszt { get; set; }
        public int? Age { get; set; }
        public int? Bornyear { get; set; }

        public static explicit operator PlayerGridModel(PlayerModel x)
        {
            PlayerGridModel pgm = new PlayerGridModel();
            pgm.Id = x.Id;
            pgm.Age = x.Age;
            switch (x.PosztId)
            {
                case (int)Enums.Enums.Position.Kapus:
                    pgm.Poszt = "Kapus";
                    break;
                case (int)Enums.Enums.Position.Védő:
                    pgm.Poszt = "Védő";
                    break;
                case (int)Enums.Enums.Position.Középpályás:
                    pgm.Poszt = "Középpályás";
                    break;
                case (int)Enums.Enums.Position.Csatár:
                    pgm.Poszt = "Csatár";
                    break;
            }
            pgm.Name = x.Name;
            pgm.Bornyear = x.Bornyear;
            pgm.Age = x.Age;

            return pgm;
        }
    }
}