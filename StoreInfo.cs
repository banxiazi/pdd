using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.beans
{
    class StoreInfo
    {
        public int s_id { get; set; }
        public string s_username { get; set; }
        public string s_password { get; set; }
        public string s_name { get; set; }

        public string s_token { get; set; }

        public string s_refreshToken { get; set; }
        public int u_id { get; set; }
        public string s_status { get; set; }
        public string s_lable { get; set; }
    }
}
