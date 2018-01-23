using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatApi.Controllers;
using ChatApi.Models;

namespace ChatApi
{
    public static class DbCacheLoad
    {
        public static void LoadDbCache()
        {
            using (DbContext db = new DbContext())
            {
                TvGryController.Powiedzonka = new HashSet<string>(db.TvGryPowiedzonka.Select(p => p.Wartosc));
            }
        }
    }
}