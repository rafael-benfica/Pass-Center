using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers {
    public class OiController : ApiController {
        /// <summary>
        /// olá tudo bem?
        /// </summary>
        /// <returns>oioioi</returns>
        public IEnumerable<string> Post() {

            User usr = new User();

            usr.login = "rafa";
            usr.senha = "oi123";

            if(UserDB.Insert(usr) == 0) {
                return new string[] { "ok", "ok" };

            } else {
                return new string[] { "fu", "fu" };
            }


        }

    }
}
