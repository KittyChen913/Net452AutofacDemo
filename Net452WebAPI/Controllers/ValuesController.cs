using Net452Library;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Net452WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IValuesService valuesService;

        public ValuesController(IValuesService valuesService)
        {
            this.valuesService = valuesService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            logger.Debug("我是Debug");
            logger.Info("我是Info");
            logger.Error("我是Error");

            return valuesService.GetValueList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
