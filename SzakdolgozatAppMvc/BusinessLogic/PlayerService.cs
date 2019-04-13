using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.BusinessLogic
{
    public class PlayerService
    {
        public List<PlayerModel> GetPlayer (int csapatId)
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
                                  PosztId =c.C_POSZTID
                              }).ToList();
                return result ;
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
    }
}