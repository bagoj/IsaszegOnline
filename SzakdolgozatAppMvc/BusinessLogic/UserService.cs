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

        public bool Add(UserModel um)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                T_USER user = new T_USER();
                db.T_USER.Add(maptoEntity(um));
                db.SaveChanges();
            }
            return true;
        }

        private T_USER maptoEntity(UserModel um)
        {
            //        public int Id { get; set; }
            //public string Name { get; set; }
            //public string Address { get; set; }
            //public int? City { get; set; }
            //public string Password { get; set; }
            //public string UserName { get; set; }
            T_USER p = new T_USER();
            p.Id = Guid.NewGuid().GetHashCode();
            p.C_ADDRESS = um.Address;
            p.C_ISZ = um.City;
            p.C_NAME = um.Name;
            p.C_PASSWORD = um.Password;
            p.C_USERNAME = um.UserName;

            return p;

        }
}
}