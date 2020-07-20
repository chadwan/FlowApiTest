using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using System.Web.Script.Serialization;
using FlowApi.Models;
using FlowApi.LINQ;
using System.Collections.Generic;

namespace FlowApi.Controllers
{
    [RoutePrefix("api/flow")]
    public class FlowController : ApiController
    {
        [HttpGet]
        [Route("")]
        public JObject get()
        {
            var jss = new JavaScriptSerializer();
            jss.MaxJsonLength = 500000000;
            string jsonNull = jss.Serialize(null);
            string success = jss.Serialize("true");
            string message = jss.Serialize("success");
            string flows = jss.Serialize(new List<Flow>());

            try
            {
                flows = jss.Serialize(FlowModel.getFlow());
            }
            catch (Exception ex)
            {
                success = jss.Serialize("false");
                message = jss.Serialize(ex.ToString());
            }
            return JObject.Parse("{success : " + success + ", message : " + message + ", flows : " + flows + "}");
        }

        [HttpGet]
        [Route("")]
        public JObject get(string q)
        {
            var jss = new JavaScriptSerializer();
            jss.MaxJsonLength = 500000000;
            string jsonNull = jss.Serialize(null);
            string success = jss.Serialize("true");
            string message = jss.Serialize("success");
            string flows = jss.Serialize(new List<Flow>());

            try
            {
                flows = jss.Serialize(FlowModel.getFlow(q));
            }
            catch (Exception ex)
            {
                success = jss.Serialize("false");
                message = jss.Serialize(ex.ToString());
            }
            return JObject.Parse("{success : " + success + ", message : " + message + ", flows : " + flows + "}");
        }

        [HttpGet]
        [Route("")]
        public JObject get(string q, int page, int pageSize)
        {
            var jss = new JavaScriptSerializer();
            jss.MaxJsonLength = 500000000;
            string jsonNull = jss.Serialize(null);
            string success = jss.Serialize("true");
            string message = jss.Serialize("success");
            string flows = jss.Serialize(new List<Flow>());

            try
            {
                flows = jss.Serialize(FlowModel.getFlow(q, page, pageSize));
            }
            catch (Exception ex)
            {
                success = jss.Serialize("false");
                message = jss.Serialize(ex.ToString());
            }
            return JObject.Parse("{success : " + success + ", message : " + message + ", flows : " + flows + "}");
        }
    }
}
