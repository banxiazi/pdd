using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDD721
{
   
    public partial class Form1 : Form
    {

       
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
    }
}
