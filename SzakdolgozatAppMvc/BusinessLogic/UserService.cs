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

        public UserEditModel GetUser(int id)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var result = (from c in db.T_USER
                              where c.Id == id
                              select new UserEditModel
                              {
                                  Id = c.Id,
                                  Name = c.C_NAME,
                                  Address = c.C_ADDRESS,
                                  UserName = c.C_USERNAME,
                                  City = c.C_ISZ
                              }).FirstOrDefault(); 
                return result;
            }
        }

        public List<UserModel> GetList()
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var result = (from c in db.T_USER
                              select new UserModel
                              {
                                  Id = c.Id,
                                  Name = c.C_NAME,
                                  Address = c.C_ADDRESS,
                                  UserName = c.C_USERNAME,
                                  City = c.C_ISZ
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