using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat.Core.HttpHelper;

namespace SpiderFrm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var http = new HttpHelper();
            var result = http.GetHtml(new HttpItem
            {
                Url = textBox1.Text,
            });

            var html = result.Html;

            richTextBox1.Text = html;

            var pic = http.GetImage(new HttpItem
            {
                Url = "https://images.cnblogs.com/cnblogs_com/soundcode/840692/o_%e5%be%ae%e4%bf%a1%e5%9b%be%e7%89%87_20171230114857.png"
            });

            pictureBox1.Image = pic;
        }
    }
}
