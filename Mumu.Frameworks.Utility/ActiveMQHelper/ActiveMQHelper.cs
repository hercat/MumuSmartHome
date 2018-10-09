using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:ActiveMQ帮助类
    /// Author:WUWEI
    /// Date:2018/10/09
    /// </summary>
    public class ActiveMQHelper
    {        
        #region ActiveMQ地址
        private static string _url;
        //public static string Url
        //{
        //    get { return _url; }
        //    set { _url = value; }
        //}
        #endregion

        #region ActiveMQ用户名
        private static string _user;
        //public static string User
        //{
        //    get { return _user; }
        //    set { _user = value; }
        //}
        #endregion

        #region ActiveMQ密码
        private static string _pwd;
        //public static string Pwd
        //{
        //    get { return _pwd; }
        //    set { _pwd = value; }
        //}
        #endregion
        public ActiveMQHelper() { }
        public ActiveMQHelper(string url, string user, string pwd)
        {
            _url = url;
            _user = user;
            _pwd = pwd;
        }
        
        #region 连接工厂IconnectionFFactory
        private static IConnectionFactory _factory;
        public void CreateFactory()
        {
            _factory = new ConnectionFactory(_url);
        }
        #endregion

        private ITextMessage _message;
        public string GetMessage()
        {
            if (null != _message)
                return _message.Text;
            else
                return string.Empty;
        }
        /// <summary>
        /// 生产Topic消息
        /// </summary>
        /// <param name="topic">消息Topic</param>
        /// <param name="message">消息内容</param>
        /// <param name="mode">发送模式</param>
        /// <param name="priority">权限</param>
        public void ProduceTopicMessage(string topic,string message,MsgDeliveryMode mode,MsgPriority priority)
        {
            try
            {
                //创建连接
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(topic));
                        ITextMessage msg = producer.CreateTextMessage();
                        msg.Text = message;
                        producer.Send(msg, mode, priority, TimeSpan.MinValue);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 订阅Topic消息
        /// </summary>
        /// <param name="topic">消息Topic</param>
        /// <param name="clientId"></param>
        /// <param name="subscribeName"></param>
        /// <param name="mode"></param>
        public void SubscribeTopicMessage(string topic,string clientId,string subscribeName, AcknowledgementMode mode)
        {
            try
            {
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    connection.ClientId = clientId;
                    connection.Start();
                    using (ISession session = connection.CreateSession(mode))
                    {
                        IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(topic), subscribeName, null, false);
                        consumer.Listener += new MessageListener(customer_listener);
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

        private void customer_listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            _message = msg;
        }
    }
}
