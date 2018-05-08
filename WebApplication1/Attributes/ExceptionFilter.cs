using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Filters;

namespace WebApplication1.Attributes
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;
            log.Error(ex);
        }
    }
}