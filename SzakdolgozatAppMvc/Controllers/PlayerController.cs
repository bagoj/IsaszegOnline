using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SzakdolgozatAppMvc.BusinessLogic;
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
            UserService userService = new UserService();
            List<UserModel> userModels = userService.GetList();
            return Json(new { rows = userModels }, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult Edit(PlayerModel pm)
        {
            ps.Edit(pm);
            return View("FelnottIndex");
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
            ps.Delete(id);
            //DELETE
            return RedirectToAction("Home/Index");
        }

        public ActionResult Add(int id)
        {
            PlayerGridModel playerModel = new PlayerGridModel();
            playerModel.CsapatId = id;
            return View("Add",playerModel);
        }
        [HttpPost]
        public bool Add(PlayerModel model)
        {
            ps.Add(model);
            return true;
        }
    }
}