using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mumu.Frameworks.Utility;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.LogicalOperation;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static string _connString;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 配置文件生成测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SystemSettingBase.CreateInstance().SysMySqlDB.Server = "localhost";
            SystemSettingBase.CreateInstance().SysMySqlDB.DataBase = "test";
            SystemSettingBase.CreateInstance().SysMySqlDB.Charset = "utf8";
            SystemSettingBase.CreateInstance().SysMySqlDB.Uid = "root";
            SystemSettingBase.CreateInstance().SysMySqlDB.Password = "jianglin";
            SystemSettingBase.CreateInstance().Save();
        }
        /// <summary>
        /// 数据库连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            IDbConnection conn = DbConnOperation.CreateMySqlConnection();
            conn.Open();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _connString = SystemSettingBase.CreateInstance().SysMySqlDB.ConnString;
            ConnString.MySqldb = _connString;
        }
        /// <summary>
        /// MD5加密测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string content = "wuw_sh@aliyun.com";
            string result = EncryptionHelper.CreateInstance().GetMD5Hash(content);
        }
        /// <summary>
        /// MD5加密内容验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string content = "wuw_sh@aliyu.com";
            string hash = EncryptionHelper.CreateInstance().GetMD5Hash(content);
            bool result = EncryptionHelper.CreateInstance().VerfierMD5Hash("wuwei_sh@aliyu.com", hash);
        }
        /// <summary>
        /// 生成二维码测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string context = "wuwei";
            ThoughtWorksQRCodeHelper.CreateInstance().CreateThoughWorksQRCode(context, "./test.jpeg", Color.White, Color.Black, 4, 8, QRCodeEncoder.ENCODE_MODE.BYTE, QRCodeEncoder.ERROR_CORRECTION.H, ImageFormat.Jpeg);
        }
    }
}
