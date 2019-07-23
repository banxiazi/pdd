using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.beans
{
    class UserInfor {
        public string uname { get; set; }
        public string upwd { get; set; }
    }
    class TokenJson
    {       
            /// <summary>
            /// 
            /// </summary>
            public List<string> scope { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string access_token { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int expires_in { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string refresh_token { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string owner_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string owner_name { get; set; }
        
    }
}
