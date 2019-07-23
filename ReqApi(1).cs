using MallInfoCrawler.Helpers;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.beans;

namespace WindowsFormsApp1
{
    class ReqApi
    {
       // private static MysqlHelper mysqlHelper = new MysqlHelper();

        //public String GetCode()
        //{
        //    ReqParam loginParam = new ReqParam
        //    {
        //        response_type = "code",
        //        client_id = "0c0ad2da4fbf43d69a930f44dc5a6800",
        //        //回调地址
        //        redirect_uri = "http://www.kanghonge.cn/pdd/open",
        //        status = 1212
        //    };
        //   return this.Send(loginParam, "https://mms.pinduoduo.com/open.html");
        //}

        public static  TokenJson GetToken(String code)
        {
            ReqParam param = new ReqParam
            {
                client_id = "0c0ad2da4fbf43d69a930f44dc5a6800",
                client_secret = "f9ab58883ba3797328e125c76580c181dbb113c2",
                grant_type = "authorization_code",
                code = code,
                redirect_uri = "http://www.kanghonge.cn/pdd/open",
                status = 1212
            };
            string s = getResult(param, "http://open-api.pinduoduo.com/oauth/token");
            return JsonHelper.DeserializeJsonToObject<TokenJson>(s);
                
        }

    

        public static  TokenJson RefreshToken(string refresh_token)
        {
            ReqParam param = new ReqParam
            {
                client_id = "0c0ad2da4fbf43d69a930f44dc5a6800",
                client_secret = "f9ab58883ba3797328e125c76580c181dbb113c2",
                grant_type = "refresh_token",
                refresh_token = refresh_token,
                redirect_uri = "http://www.kanghonge.cn/pdd/open",
                status = 1212
            };
            return JsonHelper.DeserializeJsonToObject<TokenJson>(getResult(param, "http://open-api.pinduoduo.com/oauth/token"));
           
        }
        //发送getcode
        public String Send(ReqParam param,String uri)
        {
            String sJson = "";



            Stream cResponseStream = null;
            HttpClient cHttpClient = null;
            HttpContent cHttpContent = null;
            StreamReader cStreamReader = null;
            HttpResponseMessage cResponse = null;
            HttpClientHandler cHttpHandler = null;

           // string sHttpUrl = "https://mms.pinduoduo.com/open.html";
           // string testUrl = "http://192.168.23.129:8080/sydatapro/okko";
            try
            {

                cHttpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                cHttpClient = new HttpClient(cHttpHandler);
                cHttpClient.Timeout = new TimeSpan(0, 0, 10);
                sJson = JsonConvert.SerializeObject(param);

                cHttpContent = new StringContent(sJson);
                cHttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                cHttpContent.Headers.ContentLength = (Encoding.UTF8.GetBytes(sJson)).Length;

                Task<HttpResponseMessage> cResponseTask = cHttpClient.PostAsync(uri, cHttpContent);
                cResponseTask.Wait();
                if (cResponseTask.Result != null)
                {
                    cResponse = cResponseTask.Result;
                    if (cResponse.IsSuccessStatusCode)
                    {
                        Task<Stream> cResponseStreamTask = cResponseTask.Result.Content.ReadAsStreamAsync();
                        cResponseStreamTask.Wait();

                        if (cResponseStreamTask.Result != null)
                        {
                            cResponseStream = cResponseStreamTask.Result;
                            cStreamReader = new StreamReader(cResponseStream, Encoding.UTF8);
                            var Result = cStreamReader.ReadToEnd();
                            Console.WriteLine(Result);                            
                            return Result;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (cResponseStream != null)
                {
                    cResponseStream.Close();
                    cResponseStream.Dispose();
                }
                if (cStreamReader != null)
                {
                    cStreamReader.Close();
                    cStreamReader.Dispose();
                }
                if (cResponse != null) cResponse.Dispose();
                if (cHttpHandler != null) cHttpHandler.Dispose();
                if (cHttpClient != null) cHttpClient.Dispose();
            }
            return "";
        }


        //获取所有售后接口
        //public static  BindingList<RefundInfo> getAllRefunds(long date,StoreInfo token)
        //{
        //    BindingList<RefundInfo> list = new BindingList<RefundInfo>();
        //    long times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            
        //   // Console.WriteLine(times);
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
        //    dic.Add("access_token", token.s_token);
        //    dic.Add("data_type", "JSON");
        //    dic.Add("timestamp", times);
        //    dic.Add("type", "pdd.refund.list.increment.get");
        //    dic.Add("after_sales_status", 1);//全部
        //    dic.Add("after_sales_type", 1);//全部
        //   dic.Add("start_updated_at", date - 30 * 60);
        //    dic.Add("end_updated_at", date);
        //    dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
        //    RefundRoot refund = JsonHelper.DeserializeJsonToObject<RefundRoot>(GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router"));
        //    Console.WriteLine(refund);
        //    foreach (Refund_listItem item in refund.refund_increment_get_response.refund_list)
        //    {
                
        //        RefundInfo info = new RefundInfo
        //        {
        //            store_name = token.s_name,
        //            order_sn = item.order_sn,
        //            refund_sn = item.id,
        //            goods_name = item.goods_name,
        //            order_amount = item.order_amount,
        //            refund_amount = item.refund_amount,
        //            confirm_time = item.confirm_time,
        //            create_time = item.confirm_time,
        //            after_sale_status = (item.after_sales_status == 2)?"买家申请退款，待商家处理": (item.after_sales_status == 6) ?"驳回退款，待买家处理":"其他",
        //            invalid_time = item.updated_time
        //        };
        //    }
        //    return list;
        //}

        public static  String getOrderInfo(string order_id, StoreInfo token)
        {

            String times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
            Console.WriteLine(times);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
            dic.Add("access_token", token.s_token);
            dic.Add("data_type", "JSON");
            dic.Add("timestamp", times);
            dic.Add("type", "pdd.order.information.get");
            dic.Add("order_sn", order_id);
            dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));

            return GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router");
        }

        //public BindingList<LaterOrder> getLaterOrders(StoreInfo token)
        //{
        //    BindingList<LaterOrder> list = new BindingList<LaterOrder>();
        //    String times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    dic.Add("order_status", 1);
        //    dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
        //    dic.Add("access_token", token.s_token);
        //    dic.Add("data_type", "JSON");
        //    dic.Add("page", 1);
        //    dic.Add("timestamp", times);
        //    dic.Add("type", "pdd.order.number.list.get");
        //    dic.Add("page_size", 20);
        //    dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
        //    OrderSnRoot orderSnRoot = JsonHelper.DeserializeJsonToObject<OrderSnRoot>(GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router"));

        //    foreach (Order_sn_listItem item in orderSnRoot.order_sn_list_get_response.order_sn_list)
        //    {
        //        string s = getOrderInfo(item.order_sn, token);
        //        OrderRoot orderRoot = JsonHelper.DeserializeJsonToObject<OrderRoot>(s);
        //        OInfo info = orderRoot.order_info_get_response.order_info;
        //        Goods good = info.item_list[0];
        //        DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
        //        dtFormat.ShortDatePattern = "yyyy/MM/dd";
        //        if (Convert.ToInt64(( Convert.ToDateTime(info.last_ship_time, dtFormat) - DateTime.UtcNow).TotalSeconds) < 12*3600)
        //        {
        //            LaterOrder oinfo = new LaterOrder
        //            {                        
        //                store_name = token.s_name,
        //                comfirm_time = info.confirm_time,
        //                order_sn = info.order_sn,
        //                goods_name = info.item_list[0].goods_name,
        //                goods_spec = good.goods_spec,
        //                goods_count = good.goods_count,
        //                goods_amount = info.goods_amount,
        //                address = info.address,
        //                receiver_name = info.receiver_name,
        //                receiver_phone = info.receiver_phone,
                        
        //                last_ship_time = info.last_ship_time,
        //                order_status = (info.order_status == 1) ? "待发货" : (info.order_status == 2) ? "已发货待签收" : "已签收"
        //            };
        //            list.Add(oinfo);
        //        }
        //    }
        //    return list;
        //}


        //public static BindingList<OrderInfo>   getOrders(StoreInfo token)
        //{
        //    BindingList<OrderInfo> list = new BindingList<OrderInfo>();
        //    String times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        //    Console.WriteLine(times);         
        //    Dictionary<string,object> dic = new Dictionary<string, object>();
        //    dic.Add("order_status", 1);
        //    dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
        //    dic.Add("access_token", token.s_token);
        //    dic.Add("data_type", "JSON");
        //    dic.Add("page", 1);
        //    dic.Add("timestamp", times);       
        //    dic.Add("type", "pdd.order.number.list.get");
        //    dic.Add("page_size", 20);
        //    dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
        //    OrderSnRoot orderSnRoot = JsonHelper.DeserializeJsonToObject<OrderSnRoot>(GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router"));
        //    if(orderSnRoot.order_sn_list_get_response != null)
        //    {
        //        foreach (Order_sn_listItem item in orderSnRoot.order_sn_list_get_response.order_sn_list)
        //        {
        //            Console.WriteLine("ssssss0" + item.order_sn);
        //            string s = getOrderInfo(item.order_sn, token);
        //            Console.WriteLine("ssssss" + s);
        //            OrderRoot orderRoot = JsonHelper.DeserializeJsonToObject<OrderRoot>(s);
        //            //Console.WriteLine(orderRoot.order_info_get_response.order_info.address);
        //            OInfo info = orderRoot.order_info_get_response.order_info;
        //            Goods good = info.item_list[0];
        //            OrderInfo oinfo = new OrderInfo
        //            {
        //                s_id = token.s_id,
        //                store_name = token.s_name,
        //                comfirm_time = info.confirm_time,
        //                order_sn = info.order_sn,
        //                goods_name = info.item_list[0].goods_name,
        //                goods_spec = good.goods_spec,
        //                goods_count = good.goods_count,
        //                goods_amount = info.goods_amount,
        //                pay_amount = info.pay_amount,
        //                receiver_name = info.receiver_name,
        //                receiver_phone = info.receiver_phone,
        //                province = info.province,
        //                city = info.city,
        //                towm = info.town,
        //                address = info.address,
        //                last_ship_time = info.last_ship_time
        //            };
        //            list.Add(oinfo);
        //        }
        //    }
        //    else
        //    {
        //        MySqlParameter[] ps = new MySqlParameter[] { new MySqlParameter("@s_status","已失效") , new MySqlParameter("@s_id", token.s_id) };
        //        mysqlHelper.Update("update t_store set s_status = @s_status where s_id = @s_id", ps);
        //    }        
        //        return list;
        //}

        //public BindingList<OrderInfo> getOrdersByDate(string date, StoreInfo token)
        //{
        //    BindingList<OrderInfo> list = new BindingList<OrderInfo>();
        //    String times = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        //    Console.WriteLine(times);
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    dic.Add("order_status", 1);
        //    dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
        //    dic.Add("access_token", token.s_token);
        //    dic.Add("data_type", "JSON");
        //    dic.Add("timestamp", times);
        //    dic.Add("type", "pdd.order.number.list.get");
        //    dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
        //    OrderSnRoot orderSnRoot = JsonHelper.DeserializeJsonToObject<OrderSnRoot>(GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router"));

        //    foreach (Order_sn_listItem item in orderSnRoot.order_sn_list_get_response.order_sn_list)
        //    {
        //        string s = getOrderInfo(item.order_sn,token);
        //        OrderRoot orderRoot = JsonHelper.DeserializeJsonToObject<OrderRoot>(s);

        //        OInfo info = orderRoot.order_info_get_response.order_info;
        //        Goods good = info.item_list[0];              
        //        DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
        //        dtFormat.ShortDatePattern = "yyyy/MM/dd";
        //        DateTimeFormatInfo dtFormat2 = new System.Globalization.DateTimeFormatInfo();
        //        dtFormat2.ShortDatePattern = "yyyy-MM-dd";
        //        DateTime dt = Convert.ToDateTime(info.confirm_time, dtFormat);
        //        DateTime dt2 = Convert.ToDateTime(date, dtFormat);
        //        Console.WriteLine(dt.ToString());
        //        Console.WriteLine(dt2.ToString());
        //        if (dt.Date == dt2.Date)
        //        {
        //            OrderInfo oinfo = new OrderInfo
        //            {
        //                s_id = token.s_id,
        //                store_name = token.s_name,
        //                comfirm_time = info.confirm_time,
        //                order_sn = info.order_sn,
        //                goods_name = info.item_list[0].goods_name,
        //                goods_spec = good.goods_spec,
        //                goods_count = good.goods_count,
        //                goods_amount = info.goods_amount,
        //                pay_amount = info.pay_amount,
        //                receiver_name = info.receiver_name,
        //                receiver_phone = info.receiver_phone,
        //                province = info.province,
        //                city = info.city,
        //                towm = info.town,
        //                address = info.address
        //            };
        //            list.Add(oinfo);
        //        }
        //    }
        //    return list;
        //}

        public static string getsign(Dictionary<string,object> dic,string client_secret)
        {
            Dictionary<string, object> dic1Asc = dic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder sb = new StringBuilder(client_secret);
            foreach (KeyValuePair<string, object> k in dic1Asc)
            {
                sb.Append(k.Key);
                sb.Append(k.Value.ToString());
            }
            sb.Append(client_secret);
            Console.WriteLine(sb.ToString());
            byte[] b = new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
            string sTemp = "";
            for (int i = 0; i < b.Length; i++)
            {
                sTemp += b[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp.ToUpper();
        }

        public static String GetOrderJson(Dictionary<string,object> param, String uri)
        {
            String sJson = "";


            JObject jo = null;
            Stream cResponseStream = null;
            HttpClient cHttpClient = null;
            HttpContent cHttpContent = null;
            StreamReader cStreamReader = null;
            HttpResponseMessage cResponse = null;
            HttpClientHandler cHttpHandler = null;
            try
            {

                cHttpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                cHttpClient = new HttpClient(cHttpHandler);
                cHttpClient.Timeout = new TimeSpan(0, 0, 10);
                sJson = JsonConvert.SerializeObject(param);

                cHttpContent = new StringContent(sJson);
                cHttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                cHttpContent.Headers.ContentLength = (Encoding.UTF8.GetBytes(sJson)).Length;
                Console.WriteLine(cHttpContent.ToString());
                Console.WriteLine(sJson);
                Task<HttpResponseMessage> cResponseTask = cHttpClient.PostAsync(uri, cHttpContent);
                cResponseTask.Wait();
                if (cResponseTask.Result != null)
                {
                    cResponse = cResponseTask.Result;
                    if (cResponse.IsSuccessStatusCode)
                    {
                        Task<Stream> cResponseStreamTask = cResponseTask.Result.Content.ReadAsStreamAsync();
                        cResponseStreamTask.Wait();

                        if (cResponseStreamTask.Result != null)
                        {
                            cResponseStream = cResponseStreamTask.Result;
                            cStreamReader = new StreamReader(cResponseStream, Encoding.UTF8);
                            var Result = cStreamReader.ReadToEnd();
                            Console.WriteLine(Result);
                            jo = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(Result);
                            if (jo.ContainsKey("error_code"))
                            {
                                return jo.Value<string>("error_msg");
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (cResponseStream != null)
                {
                    cResponseStream.Close();
                    cResponseStream.Dispose();
                }
                if (cStreamReader != null)
                {
                    cStreamReader.Close();
                    cStreamReader.Dispose();
                }
                if (cResponse != null) cResponse.Dispose();
                if (cHttpHandler != null) cHttpHandler.Dispose();
                if (cHttpClient != null) cHttpClient.Dispose();
            }
            return jo.ToString();
        }

        public static string getResult(ReqParam param, String uri)
        {
            String sJson = "";

            Stream cResponseStream = null;
            HttpClient cHttpClient = null;
            HttpContent cHttpContent = null;
            StreamReader cStreamReader = null;
            HttpResponseMessage cResponse = null;
            HttpClientHandler cHttpHandler = null;
                string t = null;

         //   string sHttpUrl = "https://mms.pinduoduo.com/open.html";
           // string testUrl = "http://192.168.23.129:8080/sydatapro/okko";
            try
            {

                cHttpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                cHttpClient = new HttpClient(cHttpHandler);
                cHttpClient.Timeout = new TimeSpan(0, 0, 10);
                sJson = JsonConvert.SerializeObject(param);
                cHttpContent = new StringContent(sJson);
                cHttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                cHttpContent.Headers.ContentLength = (Encoding.UTF8.GetBytes(sJson)).Length;
                Task<HttpResponseMessage> cResponseTask = cHttpClient.PostAsync(uri, cHttpContent);
                cResponseTask.Wait();
                if (cResponseTask.Result != null)
                {
                    cResponse = cResponseTask.Result;
                    if (cResponse.IsSuccessStatusCode)
                    {
                        Task<Stream> cResponseStreamTask = cResponseTask.Result.Content.ReadAsStreamAsync();
                        cResponseStreamTask.Wait();

                        if (cResponseStreamTask.Result != null)
                        {
                            cResponseStream = cResponseStreamTask.Result;
                            cStreamReader = new StreamReader(cResponseStream, Encoding.UTF8);
                            t = cStreamReader.ReadToEnd();
                            Console.WriteLine(t);
                           
                            
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (cResponseStream != null)
                {
                    cResponseStream.Close();
                    cResponseStream.Dispose();
                }
                if (cStreamReader != null)
                {
                    cStreamReader.Close();
                    cStreamReader.Dispose();
                }
                if (cResponse != null) cResponse.Dispose();
                if (cHttpHandler != null) cHttpHandler.Dispose();
                if (cHttpClient != null) cHttpClient.Dispose();
            }
            return t;
        }

        //public static List<KdPriceItem> getKdPrices()
        //{
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    string guid = Guid.NewGuid().ToString();
        //    dic.Add("sid", guid);
        //    dic.Add("sign", kbSign(guid));
        //    dic.Add("username", "hetmly");
        //    Kds kds = JsonHelper.DeserializeJsonToObject<Kds>(GetOrderJson(dic, "http://www.huoyingkb.com/API/GetKd"));
        //    Console.WriteLine(kds);
        //    List<KdPriceItem> list = new List<KdPriceItem>();
        //    foreach(KdPriceItem k in kds.kdPrice)
        //    {
        //        if (k.kdName.Contains("(拼多多-专用)"))
        //        {
        //            k.kdName = k.kdName.Replace("(拼多多-专用)", "") ;
        //            k.message = k.kdName + " : " + k.apiPrice + "元/个";
        //            list.Add(k);
        //        }
        //        if (k.kdName.Contains("(拼多多-专用)"))
        //        {
        //            k.kdName = k.kdName.Replace("(拼多多-电子)", "");
        //            k.message = k.kdName + " : " + k.apiPrice + "元/个";
        //            list.Add(k);
        //        }
                
        //    }
        //    return list;
        //}

        public static String kbSign(string sid)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //将密码16位md5加密
            string md516 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes("qq23210321")), 4, 8);
            md516 = md516.Replace("-", "");
            md516 = md516.ToLower();
            String str = "hetmly" + md516 + sid;
            string result = "";
            //MD5 md52 = MD5.Create();//实例化一个md5对像
            //// 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            //byte[] s = md52.ComputeHash(Encoding.UTF8.GetBytes(str));
            //// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            //for (int i = 0; i < s.Length; i++)
            //{
            //    // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

            //    result = result + s[i].ToString("X");

            //}
            //return result.ToLower();
            byte[] b = new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(str.ToString()));
            string sTemp = "";
            for (int i = 0; i < b.Length; i++)
            {
                sTemp += b[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        //public static KddhRespon  buyKddh(Dictionary<string,object> postAddItem,int kdid,string kg,int num,List<Dictionary<string,object>> items)
        //{
        //    Dictionary<string, object> root = new Dictionary<string, object>();
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    string guid = Guid.NewGuid().ToString();
        //    dic.Add("sid", guid);
        //    dic.Add("sign", kbSign(guid));
        //    dic.Add("username", "hetmly");
        //    root.Add("info", dic);
        //    root.Add("kdid", kdid);
        //    root.Add("postAddrItem", postAddItem);
        //    root.Add("kg", kg);
        //    root.Add("num", num);
        //    root.Add("items", items);
        //    return JsonHelper.DeserializeJsonToObject<KddhRespon>(GetOrderJson(root, "http://www.huoyingkb.com/API/BuyKddh"));     
        //}


        public static string sendKB(string order_sn,long logistics_id,string tracking_number,StoreInfo store)
        {
            String times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
            Console.WriteLine(times);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
            dic.Add("access_token", store.s_token);
            dic.Add("data_type", "JSON");
            dic.Add("timestamp", times);
            dic.Add("type", "pdd.logistics.online.send");
            dic.Add("order_sn", order_sn);
            dic.Add("logistics_id", logistics_id);
            dic.Add("tracking_number", tracking_number);
            dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
            return GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router");
        }

        //public static LogCompanyJson getLogCompanys(StoreInfo store)
        //{
        //    String times = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    dic.Add("client_id", "0c0ad2da4fbf43d69a930f44dc5a6800");
        //    dic.Add("access_token", store.s_token);
        //    dic.Add("data_type", "JSON");
        //    dic.Add("timestamp", times);
        //    dic.Add("type", "pdd.logistics.companies.get");
        //    dic.Add("sign", getsign(dic, "f9ab58883ba3797328e125c76580c181dbb113c2"));
        //    return JsonHelper.DeserializeJsonToObject<LogCompanyJson>(GetOrderJson(dic, "https://gw-api.pinduoduo.com/api/router"));
             
        //}


        //联众接口
        public static CaptCha GetCapt(string base64)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("softwareId", 15288);
            dic.Add("softwareSecret", "OZJS907bVNgJcdDCyecloe6SXfWvKMd3Yp9iktFa");
            dic.Add("username", "hetmly");
            dic.Add("password", "Mark425426");
            dic.Add("captchaData", base64);
            dic.Add("captchaType", 1001);           
            return JsonHelper.DeserializeJsonToObject<CaptCha>(GetOrderJson(dic, "https://v2-api.jsdama.com/upload"));
        }

    }
}
