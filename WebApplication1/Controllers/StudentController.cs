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
    public class StudentController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected StudentRepository studentRepository = new StudentRepository();

        [HttpPost]
        [Route("sfgl/interface/searchStu.do")]
        public SearchStudentResponse SearchStudent(BaseRequestParams parameters) {

            SearchStudentResponse response = new SearchStudentResponse();
            try {
                response = studentRepository.GetStudent(parameters.Sfzh, parameters.Xm);
                if (response != null)
                {
                    response.RspNo = "000000";
                    response.RspMsg = "1";
                }
                else {
                    response.RspNo = "111111";
                    response.RspNo = "0";
                }
            } catch (Exception ex) {
                log.Error(ex);
                response.RspNo = "111111";
                response.RspNo = "0";
            }
            return response;
        }
    }
}
