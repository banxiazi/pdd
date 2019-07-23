using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ReqParam
    {
        //类型
        public string type { get; set; }
        //id
        public string client_id { get; set; }
        public string client_secret { get; set; }

        public string grant_type { get; set; }

        public String response_type { get; set; }

        public String redirect_uri { get; set; }
        public String code { get; set; }

        public int status { get; set; }
        //时间戳（秒）
        public string timestamp { get; set; }
        //给定签名
        public string sign { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
    }
}
