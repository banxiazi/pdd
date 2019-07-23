using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MallInfoCrawler.Helpers
{
    class IHWRCrawler<T> where T : class
    {
        public static T PDDCrawler<T2, T3>(string uri, string accessToken = "") where T2 : class, T where T3 : class, T
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Add("AccessToken", accessToken);
            }
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.AllowAutoRedirect = false;//禁止自动跳转
                                              //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.38 (KHTML, like Gecko) Version/11.0 Mobile/15A372 Safari/604.1";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET              
            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {//获取请求响应
                    string content;
                    if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();


                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();
                            }

                        }
                    }
                    else
                    {
                        using (Stream stream = response.GetResponseStream())//原始
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();

                            }
                        }
                    }
                    request.Abort();
                    JsonSerializer serializer = new JsonSerializer();
                    StringReader sr = new StringReader(content);
                    object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T2));
                    T2 info = o as T2;
                    return info;
                }
            }
            catch (WebException ex)
            {

                string content = "";
                using (var response = (HttpWebResponse)ex.Response)
                {
                    if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();
                            }

                        }
                    }
                    else
                    {
                        using (Stream stream = response.GetResponseStream())//原始
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                content = reader.ReadToEnd();

                            }
                        }
                    }
                    request.Abort();
                    JsonSerializer serializer = new JsonSerializer();
                    StringReader sr = new StringReader(content);
                    object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T3));
                    T3 info = o as T3;
                    return info;
                }
            }
        }
    }
}
