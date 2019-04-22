using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.BusinessLogic
{
    public class PlayerService
    {
        public T_PLAYER maptoEntity(PlayerModel pm, bool id = true)
        {
            T_PLAYER p = new T_PLAYER();
            if (id)
                p.Id = Guid.NewGuid().GetHashCode();
            p.C_AGE = pm.Age;
            p.C_BORNYEAR = pm.Bornyear;
            p.C_CSAPATID = pm.CsapatId;
            p.C_NAME = pm.Name;
            p.C_POSZTID = pm.PosztId.Value;

            return p;
        }

        public List<PlayerModel> GetPlayer(int csapatId)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var result = (from c in db.T_PLAYER
                              where c.C_CSAPATID == csapatId
                              select new PlayerModel
                              {
                                  Id = c.Id,
                                  Name = c.C_NAME,
                                  CsapatId = c.C_CSAPATID,
                                  Bornyear = c.C_BORNYEAR,
                                  Age = c.C_AGE,
                                  PosztId = c.C_POSZTID
                              }).ToList();
                return result;
            }
        }

        public PlayerModel Get(int? id)
        {
            try
            {
                using (IsaszegDB db = new IsaszegDB())
                {
                    var result = (from c in db.T_PLAYER
                                  where c.Id == id
                                  select new PlayerModel
                                  {
                                      Id = c.Id,
                                      Name = c.C_NAME,
                                      CsapatId = c.C_CSAPATID,
                                      Bornyear = c.C_BORNYEAR,
                                      Age = c.C_AGE,
                                      PosztId = c.C_POSZTID
                                  }).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public bool Add(PlayerModel pm)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                T_PLAYER t_PLAYER = new T_PLAYER();
                db.T_PLAYER.Add(maptoEntity(pm));
                db.SaveChanges();
            }
            return true;
        }

        public bool Edit(PlayerModel pm)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var result = db.T_PLAYER.Where(b => b.Id == pm.Id).First(); //db.Departments.Where(d => d.Name == "Accounts").First();
                if (result != null)
                {
                    try
                    {

                        result.C_AGE = pm.Age;
                        result.C_BORNYEAR = pm.Bornyear;
                        result.C_CSAPATID = pm.CsapatId;
                        result.C_NAME = pm.Name;
                        result.C_POSZTID = pm.PosztId.Value;
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return true;
        }

        public bool Delete(int? id)
        {
            using (IsaszegDB db = new IsaszegDB())
            {
                var player= db.T_PLAYER.SingleOrDefault(x => x.Id == id);
                
                db.T_PLAYER.Attach(player);
                db.T_PLAYER.Remove(player);
                db.SaveChanges();
            }
            return true;
        }
    }
}