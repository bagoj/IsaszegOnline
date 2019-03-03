using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SzakdolgozatAppMvc.BusinessLogic;
using SzakdolgozatAppMvc.Datamodel;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.Controllers
{
    public class PlayerController : Controller
    {
        PlayerService ps = new PlayerService();
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FelnottIndex()
        {
            return View();
        }

        public ActionResult IfjusagiIndex()
        {
            return View();
        }

        public ActionResult NoiIndex()
        {
            return View();
        }

        public ActionResult GetPlayer()
        { 
            using (DataModel db = new DataModel())
            {
                var result = (from c in db.T_USER
                              select new UserModel
                              {
                                  Id = c.Id,
                                  Name = c.C_NAME,
                                  Address = c.C_ADRESS,
                                  City = c.C_CITY
                              }).ToList();
                return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Felnott()
        {
            var result = ps.GetPlayer((int)Enums.Enums.CsapatAzon.Felnott);
            List<PlayerGridModel> pgmList = GetPlayersList(result);
            return Json(new { rows = pgmList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ifjusagi()
        {
            var result = ps.GetPlayer((int)Enums.Enums.CsapatAzon.Ifjusagi);
            List<PlayerGridModel> pgmList = GetPlayersList(result);
            return Json(new { rows = pgmList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Noi()
        {
            var result = ps.GetPlayer((int)Enums.Enums.CsapatAzon.Noi);
            List<PlayerGridModel> pgmList = GetPlayersList(result);
            return Json(new { rows = pgmList }, JsonRequestBehavior.AllowGet);
        }

        public List<PlayerGridModel> GetPlayersList(List<PlayerModel> pm)
        {
            List<PlayerGridModel> pgmList = new List<PlayerGridModel>();
            foreach (var x in pm)
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
                pgmList.Add(pgm);
            }
            return pgmList;
        }

    }
}