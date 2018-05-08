using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseResponse
    {
        public string RspNo { get; set; }
        public string RspMsg { get; set; }

        public string Xm { get; set; }

        public string Sfzh { get; set; }

        public string Xh { get; set; }
    }

    public class SearchStudentResponse : BaseResponse
    {
        public string Pycc { get; set; }
    }

    public class ChargeResponse : BaseResponse {
        public List<Arrearage> SfqjList { get; set; }
    }

    public class Arrearage {
        public string Sfqj { get; set; }
        public decimal Yjzje { get; set; }
        public decimal Sjzje { get; set; }
        public decimal Qfzje { get; set; }

        public List<ArrearageDetail> MxData { get; set; }
    }

    public class ArrearageDetail
    {
        public string Xmmc { get; set; }
        public decimal Xmyjje { get; set; }
        public decimal Xmsjje { get; set; }
        public decimal Xmqfje { get; set; }
    }

    public class ChargeResultResponse
    {
        public string RspNo { get; set; }

        public string RspMsg { get; set; }

        public string Lsh { get; set; }
    }
}