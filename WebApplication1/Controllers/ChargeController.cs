using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ChargeController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected ChargeRepository repository = new ChargeRepository();

        [HttpPost]
        [Route("sfgl/interface/getCharge.do")]
        public ChargeResponse GetCharge(BaseRequestParams parameters) {
            ChargeResponse response = new ChargeResponse() { Xm = parameters.Xm, Sfzh = parameters.Sfzh };
            return response;
        }

        [HttpPost]
        [Route("sfgl/interface/getNotice.do")]
        public ChargeResultResponse ChargeResult(ChargeResultParams parameters)
        {
            ChargeResultResponse response = new ChargeResultResponse();
            response.Lsh = parameters.Lsh;

            try {
                repository.SaveCharge(parameters);
                response.RspNo = "000000";
                response.RspMsg = "success";               
            }
            catch (Exception ex) {
                log.Error("Got error when save charge: ", ex);
                response.RspNo = "111111";
                response.RspMsg = ex.Message;
            }

            return response;
        }
    }
}
