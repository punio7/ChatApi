using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatApi.Models;

namespace ChatApi.Controllers
{
    public class TvGryController : ApiController
    {
        public static HashSet<string> Powiedzonka { get; set; } = new HashSet<string>();

        // GET: api/TvGry
        public HttpResponseMessage Get()
        {
            Random random = new Random();
            var itemsArray = Powiedzonka.ToArray();
            int item1 = random.Next(1, 20);
            int item2 = random.Next(0, itemsArray.Length);
            int item3 = random.Next(0, itemsArray.Length);
            while (item3 == item2 && itemsArray.Length > 1)
            {
                item3 = random.Next(0, itemsArray.Length);
            }
            return Text(string.Format("{0} {1} {2}", item1, itemsArray[item2], itemsArray[item3]));
        }

        // GET: api/TvGry/string
        public HttpResponseMessage Get(string data)
        {
            if (string.IsNullOrEmpty(data) || Powiedzonka.Contains(data))
            {
                return Text("Już posiadam takie powiedzonko!");
            }
            if (data.Length > 25)
            {
                return Text("Kruci! Nie zapamiętam takiego długiego!");
            }

            using (var db = new DbContext())
            {
                db.TvGryPowiedzonka.Add(new Powiedzonko()
                {
                    Wartosc = data,
                });
                db.SaveChanges();
            }
            Powiedzonka.Add(data);
            return Text("Dodano powiedzonko " + data);
        }

        private HttpResponseMessage Text(string text)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(text, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }
    }
}
