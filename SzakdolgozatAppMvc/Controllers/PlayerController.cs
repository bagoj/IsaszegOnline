using System;
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
                pgmList.Add((PlayerGridModel)x);
            }
            return pgmList;
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            PlayerModel pm = ps.Get(id);
            PlayerGridModel pgm = (PlayerGridModel)pm;
            ViewBag.Title = pgm.Name + " szerkesztése";
            ViewBag.ReadOnly = false;
            pgm.Age = DateTime.Now.Year - pgm.Bornyear;
            return View(pgm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            PlayerModel pm = ps.Get(id);
            PlayerGridModel pgm = (PlayerGridModel)pm;
            ViewBag.Title = pgm.Name + " szerkesztése";
            ViewBag.ReadOnly = true;
            pgm.Age = DateTime.Now.Year - pgm.Bornyear;
            return View("Edit",pgm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            //DELETE
            return View();
        }

        public ActionResult Add()
        {
            //DELETE
            return View();
        }
    }
}