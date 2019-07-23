using CefSharp;
using CefSharp.WinForms;
using MallInfoCrawler.Helpers;
using MallInfoCrawler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.beans;

namespace PDD721
{
   
    public partial class Form1 : Form
    {

        ChromiumWebBrowser browser;
        List<UserInfor> userlist = new List<UserInfor>();
        
        public Form1()
        {
            InitializeComponent();
        }
        //调整选项卡文字方向
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)allBody.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(allBody.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void StarToAdd_Click(object sender, EventArgs e)
        {

        }

        private void InputGoods_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputGoods_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Filter = "文本文件|*.txt";//设置文件后缀过滤条件
            if (importFile.ShowDialog() == DialogResult.OK)
            {

                //判断是否选择文件
                StreamReader sr = new StreamReader(importFile.FileName, Encoding.Default);//创建文件流文件
                                                                                          //设置序号
                int i = 1;
                while (sr.EndOfStream != true)
                {
                    //循环读取
                    string upgoodsstr = sr.ReadLine();
                    string[] bstr = upgoodsstr.Split('*');//切割字符串
                    string upGoodId = bstr[0];//上家ID
                    string goodTit = "";
                    string uri = $"http://mobile.yangkeduo.com/proxy/api/goods/{upGoodId}";//接口地址
                    var res = IHWRCrawler<PDDModel.IResp>.PDDCrawler<PDDModel.GoodsInfo, PDDModel.ErrorResp>(uri, "6RN7OCMJC4YMG7B2YU2LZNBLDD4BOOGHHBEAXX4ZGYGOCOPSZLNQ103e73f");
                    if (res is PDDModel.GoodsInfo)
                    {
                        var info = res as PDDModel.GoodsInfo;
                        Console.WriteLine("返回：" + info.goods_name);
                        goodTit = info.goods_name;
                        //for (int j = 0; j < info.sku.Count; j++)
                        //{
                        //    Console.WriteLine(info.sku[j]);
                        //}
                    }
                    else
                    {
                        var info = res as PDDModel.ErrorResp;
                        Console.WriteLine("错误信息：" + info.error_code);
                    }
                    ListViewItem item = new ListViewItem();
                    item.Text = i + "";
                    item.SubItems.Add(bstr[0]);//上家ID
                    item.SubItems.Add("");//商品ID
                    if (bstr[1].Equals(""))
                    {
                        //判断是否拿到了商品标题
                        if (!"".Equals(goodTit))
                        {
                            item.SubItems.Add(goodTit);
                        }
                        else
                        {
                            item.SubItems.Add("商品不存在");
                        }

                    }
                    else
                    {
                        item.SubItems.Add(bstr[1]);//商品标题
                    }
                    importDataView.Items.Add(item);
                    i += 1;

                }
            }
        }

        private async void Button1_Click_1(object sender, EventArgs e)
        {
            string curcode="";
           
            Console.WriteLine(browser.CanFocus);

            BindingList<string> lbMessages = new BindingList<string>();
            //this.lbMessage.DataSource = lbMessages;
            lbMessages.Add("正在读取！");
            // List<StoreInfo> ss = mysqlHelper.SelectList<StoreInfo>("select * from t_store where s_status = @s_status and u_id = @u_id", new MySqlParameter[] { new MySqlParameter("@s_status", "需授权"), new MySqlParameter("@u_id", 4) });
            List<UserInfor> ss = new List<UserInfor>();
            UserInfor u1 = new UserInfor();
            u1.uname = "pdd40645990943";
            u1.upwd = "Mark6666";
            ss.Add(u1);
            UserInfor u2 = new UserInfor();
            u2.uname = "pdd69435976993";
            u2.upwd = "Mark6666";
            ss.Add(u2);
            for (int i = 0; i < ss.Count; i++)
            {
               
                try
                {
                    //等待页面加载循环
                    while (true)
                    {
                        if (browser.IsLoading)
                        {
                            Thread.Sleep(100);
                            Console.WriteLine("页面在加载！");
                        }
                        else
                        {
                            break;
                        }

                    }
                    browser.ExecuteScriptAsync("document.getElementsByClassName('tab-item last-item')[0].click();");
                    Console.WriteLine("点击按钮跳转");
                    Thread.Sleep(200);
                    this.Focus();
                    browser.Focus();

                    browser.ExecuteScriptAsync("document.getElementById('usernameId').focus();");
                    //Clipboard.SetText(ss[i].s_username);
                    Clipboard.SetText(ss[i].uname);
                    SendKeys.SendWait("^a");
                    Thread.Sleep(200);
                    SendKeys.SendWait("^v");
                    SendKeys.Flush();
                    Thread.Sleep(200);
                    //获取输入的用户名：
                    var uname = await browser.EvaluateScriptAsync("(function(){return document.getElementById('usernameId').value;})();");//运行页面上js的test方法
                   
                        if (!"pdd40645990943".Equals(uname))
                        {
                        Console.WriteLine("再次输入用户名");
                            this.Focus();
                            browser.Focus();
                            browser.ExecuteScriptAsync("document.getElementById('usernameId').focus();");
                            //Clipboard.SetText(ss[i].s_username);
                            Clipboard.SetText(ss[i].uname);
                        SendKeys.SendWait("^a");
                        Thread.Sleep(200);
                        SendKeys.SendWait("^v");
                        SendKeys.Flush();
                        Thread.Sleep(200);
                    }
                    
                    
                    Thread.Sleep(200);
                    Console.WriteLine("输入用户名");
                    browser.Focus();
                    browser.ExecuteScriptAsync("document.getElementById('passwordId').focus();");
                    //Clipboard.SetText(ss[i].s_password);
                    Clipboard.SetText("Mark6666");
                    SendKeys.SendWait("^a");
                    Thread.Sleep(200);
                    SendKeys.SendWait("^v");
                    SendKeys.Flush();
                    Thread.Sleep(200);
                    var upwd = await browser.EvaluateScriptAsync("(function(){return document.getElementById('passwordId').value;})();");//运行页面上js的test方法
                    if (!"Mark6666".Equals(upwd)) {
                        Console.WriteLine("再次输入密码");
                        browser.Focus();
                        browser.ExecuteScriptAsync("document.getElementById('passwordId').focus();");
                        //Clipboard.SetText(ss[i].s_password);
                        Clipboard.SetText("Mark6666");
                        SendKeys.SendWait("^a");
                        Thread.Sleep(200);
                        SendKeys.SendWait("^v");
                        SendKeys.Flush();
                        Thread.Sleep(200);
                    }
                    Console.WriteLine("输入密码");
                    browser.ExecuteScriptAsync("document.getElementsByClassName('BeastButton___outer-wrapper___1I3RI1-9-1-next-0 BeastButton___danger____x6Rs1-9-1-next-0 BeastButton___large___2D47r1-9-1-next-0')[0].click(); ");
                    Console.WriteLine("点击登录");
                    
                    Console.WriteLine("授权结束");
                }
                catch (AggregateException Exception)
                {
                    Console.WriteLine("有访问出错了" + Exception.Message);
                }
            }
            MessageBox.Show("操作完成！");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        { TabPage nP = new TabPage();
            nP.Text = "新窗口";
            cS_Pages.Controls.Add(nP);
            UserInfor uu1 = new UserInfor();
            uu1.uname = "uu1";
            uu1.upwd = "密码1";
            UserInfor uu2 = new UserInfor();
            uu1.uname = "uu2";
            uu1.upwd = "密码2";
            userlist.Add(uu1);
            userlist.Add(uu2);
            for (int j = 0; j < userlist.Count; j++) {
                ListViewItem item = new ListViewItem();
                item.Text = userlist[j].uname;
                isLoginStoreView.Items.Add(item);
            }
            
            try
            {
                if (!CefSharp.Cef.IsInitialized)
                //{
                //    var setting = new CefSharp.CefSharpSettings
                //    {
                //        Locale = "zh-CN"
                //    };
                //    setting.CefCommandLineArgs.Add("disable-gpu", "1");
                //    CefSharp.Cef.Initialize(setting);
                //}
                browser = new ChromiumWebBrowser("https://mms.pinduoduo.com/login");
                
                //browser = new ChromiumWebBrowser("https://mms.pinduoduo.com/chat-merchant/index.html");
                //this.browser.RegisterJsObject("usbKey", new UsbKeyBound());
                browser.Height = 650;
                browser.Width = 500;
                nP.Controls.Add(browser);
                //this.Controls.Add(browser);
                browser.Dock = DockStyle.Bottom;
                //browser.KeyDown += TB_KeyDown;

                //browser.MouseDown += browser_FrameLoadEndAsync; 
                //  browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(browser_FrameLoadEndAsync);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
