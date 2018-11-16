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
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

    }
}
