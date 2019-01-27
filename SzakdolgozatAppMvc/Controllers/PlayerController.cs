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
            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ifjusagi()
        {
            var result = ps.GetPlayer((int)Enums.Enums.CsapatAzon.Ifjusagi);
            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Noi()
        {
            var result = ps.GetPlayer((int)Enums.Enums.CsapatAzon.Noi);
            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }


    }
}