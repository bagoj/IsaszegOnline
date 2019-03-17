using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzakdolgozatAppMvc.BusinessLogic;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.Controllers
{
    public class LoginController : Controller
    {

        UserService userService = new UserService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFelhasznalo(string username, string pswd)
        {
            List<UserModel> userModels= userService.GetUser(username, pswd);
            if (userModels.Count >0)
                return new JsonResult() { Data = userModels[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            else return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}