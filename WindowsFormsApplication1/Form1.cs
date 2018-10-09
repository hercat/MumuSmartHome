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
using System.Web;
using System.Net;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.Mail;
using System.Collections.Specialized;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Threading;

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
            SystemSettingBase.CreateInstance().SysMySqlDB.DataBase = "MumuSmartHomeDB";
            SystemSettingBase.CreateInstance().SysMySqlDB.Charset = "utf8";
            SystemSettingBase.CreateInstance().SysMySqlDB.Uid = "root";
            SystemSettingBase.CreateInstance().SysMySqlDB.Password = "jianglin";

            SystemSettingBase.CreateInstance().SysMongoDB.Server = "192.168.224.128";
            SystemSettingBase.CreateInstance().SysMongoDB.Port = "27017";
            SystemSettingBase.CreateInstance().SysMongoDB.Database = "SmartHome";
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
            bool result = EncryptionHelper.CreateInstance().VerfierMD5Hash("wuexwei_sh@aliyu.com", hash);
        }
        /// <summary>
        /// 生成二维码测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string context = "木木之家工作室:+WUWEI:+20180710150900:+MumuSmartHome:+上海市虹桥国际机场T1航站楼";
            ThoughtWorksQRCodeHelper.CreateInstance().CreateThoughWorksQRCode(context, "./test.bmp", Color.Orange, Color.Green, 50, 0, QRCodeEncoder.ENCODE_MODE.BYTE, QRCodeEncoder.ERROR_CORRECTION.H, ImageFormat.Bmp);
        }
        /// <summary>
        /// 生成带logo的二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            string context = "木木之家工作室:+WUWEI:+20180710150900:+MumuSmartHome:+上海市虹桥国际机场T2航站楼";
            Image logo = Image.FromFile("../../images/logo(128x128).png");
            ThoughtWorksQRCodeHelper.CreateInstance().CreateThoughWorksQRCodeWithLogo(context, "./123456.jpeg", Color.White, Color.Black, 8, 10, QRCodeEncoder.ENCODE_MODE.BYTE, QRCodeEncoder.ERROR_CORRECTION.H, ImageFormat.Jpeg, logo);
        }
        /// <summary>
        /// 获取ftp文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<string> achn = new List<string>();//全国
            List<string> accn = new List<string>();//华中
            List<string> aecn = new List<string>();//华东
            List<string> ancn = new List<string>();//华北
            List<string> anec = new List<string>();//东北
            List<string> anwc = new List<string>();//西北
            List<string> ascn = new List<string>();//华南
            List<string> aswc = new List<string>();//西南
            List<string> result = new List<string>();
            FtpWebRequest request = null;
            try
            {
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://172.20.25.103/"));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential("","");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.UsePassive = false;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();
                while (null != line)
                {
                    if (line.Contains(DateTime.Now.ToString("yyyyMMdd")))
                        list.Add(line);
                    line = reader.ReadLine();
                }
                foreach (string str in list)
                {
                    if (str.Contains("achn"))
                        achn.Add(str);
                    if (str.Contains("accn"))
                        accn.Add(str);
                    if (str.Contains("aecn"))
                        aecn.Add(str);
                    if (str.Contains("ancn"))
                        ancn.Add(str);
                    if (str.Contains("anec"))
                        anec.Add(str);
                    if (str.Contains("anwc"))
                        anwc.Add(str);
                    if (str.Contains("ascn"))
                        ascn.Add(str);
                    if (str.Contains("aswc"))
                        aswc.Add(str);
                }
                result.Add(achn[achn.Count - 1]);
                result.Add(accn[accn.Count - 1]);
                result.Add(aecn[aecn.Count - 1]);
                result.Add(ancn[ancn.Count - 1]);
                result.Add(anec[anec.Count - 1]);
                result.Add(anwc[anwc.Count - 1]);
                result.Add(ascn[ascn.Count - 1]);
                result.Add(aswc[aswc.Count - 1]);
                reader.Close();
                response.Close();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// ftp文件下载测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            FtpWebRequest requset = null;
            try
            {
                FileStream file = new FileStream(string.Format(".\\{0}", "cma_rdr_accn.png"), FileMode.Create);
                requset = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://172.20.25.103/{0}", "cma_rdr_accn201806200530.png")));
                requset.UseBinary = true;
                requset.Credentials = new NetworkCredential("", "");
                requset.Method = WebRequestMethods.Ftp.DownloadFile;
                requset.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)requset.GetResponse();
                Stream stream = response.GetResponseStream();
                long len = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = stream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    file.Write(buffer, 0, readCount);
                    readCount = stream.Read(buffer, 0, bufferSize);
                }
                stream.Close();
                file.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = "内部人员";
            GroupInfo info = new GroupInfo()
            {
                id = Guid.NewGuid(),
                name = name,
                description = name,
                updatetime = DateTime.Now,
                status = 1
            };
            GroupInfo info2 = GroupOperation.GetGroupInfoByName(name);
            bool ret = false;
            if (null == info2)
                ret = GroupOperation.AddOrUpdateGroupInfo(info, EnumAddOrUpdate.Add);
            else
                MessageBox.Show(string.Format("{0}已存在！", "默认组"));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GroupInfo info = new GroupInfo()
            {
                id = new Guid("4ae75530-a9a4-4f0a-ae4c-5f35d009b611"),
                name = "默认组",
                description = "所有用户若未被分配组均属于默认组",
                updatetime = DateTime.Now,
                status = 1
            };
            bool ret = GroupOperation.AddOrUpdateGroupInfo(info, EnumAddOrUpdate.Update);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Guid id = new Guid("1e143ba4-7805-46ce-a123-95cb850795ac");
            bool ret = GroupOperation.DeleteGroupInfo(id);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            List<GroupInfo> list = new List<GroupInfo>();
            //list = GroupOperation.GetGroupInfoPageList("*", string.Empty, 1, 2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("smarthome");
                var collection = database.GetCollection<BsonDocument>("group");
                var group = new BsonDocument();
                group.Add("gid", new Guid("4ae75530-a9a4-4f0a-ae4c-5f35d009b611"));
                group.Add("name", "默认组");
                group.Add("description", "所有用户若未被分配组均属于默认组");
                group.Add("updatetime", DateTime.Now);
                group.Add("status", 1);
                collection.InsertOneAsync(group);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {            
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            IPAddress[] list = MachineInfoHelper.GetMachineIPAddress();
            string ipv4 = list[1].ToString();
            string ipv6 = list[0].ToString();

            string mac = MachineInfoHelper.GetMachineMacAddress();
            MachineInfoHelper.GetInternetIPAddress();
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            #region
            //MailAddress from = new MailAddress("wuwei038177@163.com");
            //string messageTo = "1195230489@qq.com";
            //string messageSubject = "测试邮件";
            //string body = "测试邮件内容";
            //Send(from, messageTo, messageSubject, body, "");
            #endregion

            NameValueCollection values = new NameValueCollection();
            values.Add("name", "WUWEI");
            values.Add("start", "2017-09-20");
            values.Add("end", "2018-09-30");
            values.Add("points", "10000");
            string template = EmailTemplateHelper.ConstructTemplate("../EmailTemplate.txt", values);
            EMailHelper helper = new EMailHelper();
            helper.MailSmtpServer = "smtp.aliyun.com";
            helper.MailCredential = "wuw_sh@aliyun.com";
            helper.MailCredentialPwd = "wuwei038177";
            string mailFrom = "wuw_sh@aliyun.com";
            string mailTo = "1195230489@qq.com;";
            string mailSubject = "模板邮件";
            string mailCC = "wuwei038177@163.com;";
            string result;
            helper.SendSmtpMail(mailFrom, mailTo, mailSubject, template, "", "", mailCC, out result);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="MessageFrom"></param>
        /// <param name="MessageTo"></param>
        /// <param name="MessageSubject"></param>
        /// <param name="MessageBody"></param>
        /// <param name="SUpFile"></param>
        /// <returns></returns>
        private static bool Send(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody, string SUpFile)
        {
            MailMessage message = new MailMessage();
            message.From = MessageFrom;
            message.To.Add(MessageTo); //收件人邮箱地址可以是多个以实现群发

            message.Subject = MessageSubject;
            message.Body = MessageBody;

            message.IsBodyHtml = true; //是否为html格式
            message.Priority = MailPriority.Normal; //发送邮件的优先等级
            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.163.com"; //指定发送邮件的服务器地址或IP
            sc.Port = 25; //指定发送邮件端口
            sc.Credentials = new System.Net.NetworkCredential("wuwei038177@163.com", "ww038177"); //指定登录服务器的
            try
            {
                sc.Send(message); //发送邮件
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// MQ订阅测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
                using (IConnection connection = factory.CreateConnection())
                {
                    connection.ClientId = "消费者1";
                    connection.Start();
                    using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                    {
                        IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("demo"), "消费者1", null, false);
                        consumer.Listener += new MessageListener(consumer_listener);
                    }
                    connection.Stop();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void consumer_listener(IMessage message)
        {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                string str = msg.Text;
                MessageBox.Show(msg.Text, "信息");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// MQ发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("demo"));
                        ITextMessage message = producer.CreateTextMessage();
                        message.Text = @"test message";
                        producer.Send(message, Apache.NMS.MsgDeliveryMode.NonPersistent, Apache.NMS.MsgPriority.Normal, TimeSpan.MinValue);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
