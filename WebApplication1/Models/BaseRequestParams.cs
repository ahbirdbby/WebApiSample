using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseRequestParams
    {
        public string Sfzh { get; set; }
        public string Xm { get; set; }
    }

    public class ChargeResultParams : BaseRequestParams
    {
        public string Lsh { get; set; }

        public List<ChargeDetail> SfqjList { get; set; }
    }

    public class ChargeDetail
    {
        public string Sfqj { get; set; }
        public decimal Sjzje { get; set; }

        public DateTime Jfsj { get; set; }

        public List<ChargeItemDetail> MxData { get; set; }
    }

    public class ChargeItemDetail
    {
        public string Xmmc { get; set; }
        public decimal Xmsjje { get; set; }
    }
}