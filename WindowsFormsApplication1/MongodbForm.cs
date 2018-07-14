using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.Dal;
using Mumu.Frameworks.LogicalOperation;
using Mumu.Frameworks.Utility;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MongodbForm : Form
    {
        public MongodbForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 连接Mongodb数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                //var client = MongodbHelper.CreateInstance().CreateMongoClient(ConnString.Mongodb);//new MongoClient(ConnString.Mongodb);
                //var database = MongodbHelper.CreateInstance().CreateMongoDatabase(client, SystemSettingBase.CreateInstance().SysMongoDB.Database); //client.GetDatabase(SystemSettingBase.CreateInstance().SysMongoDB.Database);
                //var collection = database.GetCollection<BsonDocument>("Sensors");
                //var sensor = new BsonDocument();
                //sensor.Add("no", Guid.NewGuid());
                //sensor.Add("name", "CO传感器");
                //sensor.Add("sn", "ISB001009");
                //sensor.Add("position", "厨房");
                //sensor.Add("setdate", DateTime.Now);
                //sensor.Add("status", "1");
                //collection.InsertOneAsync(sensor);
                #endregion

                #region
                //var sensor = new BsonDocument();
                //sensor.Add("no", Guid.NewGuid());
                //sensor.Add("name", "温湿度传感器1");
                //sensor.Add("sn", "ISB001011");
                //sensor.Add("position", "卧室");
                //sensor.Add("setdate", DateTime.Now);
                //sensor.Add("status", "1");
                ////MongodbHelper.CreateInstance().InsertOneDocumentAsync(ConnString.Mongodb, SystemSettingBase.CreateInstance().SysMongoDB.Database, "Sensors", sensor);
                //MongodbHelper.CreateInstance().InsertOneDocument(ConnString.Mongodb, SystemSettingBase.CreateInstance().SysMongoDB.Database, "Sensors", sensor);
                #endregion

                #region
                List<BsonDocument> list = new List<BsonDocument>();
                for (int i = 1; i < 5; i++)
                {
                    var sensor = new BsonDocument();
                    sensor.Add("no", Guid.NewGuid());
                    sensor.Add("name", string.Format("温湿度传感器{0}", i + 1));
                    sensor.Add("sn", string.Format("ISB001011{0}", i));
                    sensor.Add("position", "卧室");
                    sensor.Add("setdate", DateTime.Now);
                    sensor.Add("status", "1");
                    list.Add(sensor);
                }
                MongodbHelper.CreateInstance().InsertManyDocumentAsync(ConnString.Mongodb, SystemSettingBase.CreateInstance().SysMongoDB.Database, "Sensors", list);
                #endregion

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void MongodbForm_Load(object sender, EventArgs e)
        {
            ConnString.Mongodb = SystemSettingBase.CreateInstance().SysMongoDB.ConnString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region
            //var jsonString = "{a:1}";
            //using (var reader = new JsonReader(jsonString))
            //{
            //    reader.ReadStartDocument();
            //    string fieldname = reader.ReadName();
            //    int value = reader.ReadInt32();
            //    reader.ReadEndDocument();
            //}
            #endregion

            //using (var stream = File.OpenRead("test.bson"))
            //{
            //    using (var reader = new BsonBinaryReader(stream))
            //    {
            //        reader.ReadStartDocument();
            //        string filedname = reader.ReadName();
            //        int value = reader.ReadInt32();
            //        reader.ReadEndDocument();
            //    }
            //}
        }
    }
}
