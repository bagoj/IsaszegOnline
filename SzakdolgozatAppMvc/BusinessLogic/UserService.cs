using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.BusinessLogic
{
    public class UserService
    {
        public List<UserModel> GetUser(string UserName, string Pswd)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var result = (from c in db.T_USER
                              where c.C_USERNAME == UserName 
                              && c.C_PASSWORD == Pswd
                              select new UserModel
                              {
                                  Id = c.Id,
                                  Name = c.C_NAME,
                                  Address = c.C_ADDRESS
                              }).ToList();
                return result;
            }
        }
    }
}