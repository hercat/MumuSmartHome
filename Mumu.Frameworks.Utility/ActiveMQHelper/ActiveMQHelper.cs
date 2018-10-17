using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Xml;

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
        private string _url;
        #endregion

        #region ActiveMQ用户名
        private string _user;
        #endregion

        #region ActiveMQ密码
        private string _pwd;
        #endregion
        public ActiveMQHelper() { }
        public ActiveMQHelper(string url, string user, string pwd)
        {
            _url = url;
            _user = user;
            _pwd = pwd;
        }

        #region 连接工厂IconnectionFFactory
        private IConnectionFactory _factory;
        public void CreateFactory()
        {
            _factory = new ConnectionFactory(_url);
        }
        #endregion

        #region 订阅返回消息
        private ITextMessage _message = null;
        public string GetMessage()
        {
            if (null != _message)
                return _message.Text;
            else
                return string.Empty;

        }
        public void ResetMessage()
        {
            _message = null;
        }
        #endregion

        /// <summary>
        /// 生产Topic消息
        /// </summary>
        /// <param name="topic">消息Topic</param>
        /// <param name="message">消息内容</param>
        /// <param name="mode">发送模式</param>
        /// <param name="priority">权限</param>
        public void ProduceTopicMessage(string topic, string message, MsgDeliveryMode mode, MsgPriority priority)
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
        public void SubscribeTopicMessage(string topic, string clientId, string subscribeName, AcknowledgementMode mode)
        {
            try
            {
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    connection.ClientId = clientId;
                    connection.Start();
                    using (ISession session = connection.CreateSession(mode))
                    {
                        //持久性订阅Topic(将消息写入磁盘，即使重启MQ，下次订阅任然可以接收到该消息)
                        IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(topic), subscribeName, null, false);
                        //ITextMessage message = consumer.Receive() as ITextMessage;
                        //string str = message.Text;
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
        /// <summary>
        /// 订阅Topic委托处理方法
        /// </summary>
        /// <param name="message"></param>
        private void customer_listener(IMessage message)
        {
            _message = null;
            if (message is ITextMessage)
            {
                ITextMessage msg = (ITextMessage)message;
                _message = msg;
            }
        }

        /// <summary>
        /// 产生Queue消息
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="message"></param>
        public void ProduceQueueMessage(string queue, string message)
        {
            try
            {
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    connection.Start();
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(queue));
                        ITextMessage msg = producer.CreateTextMessage();
                        msg.Text = message;
                        producer.Send(msg, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
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
        /// <summary>
        /// 发送Xml内容的Queue消息
        /// </summary>
        /// <param name="queue">消息队列名称</param>
        /// <param name="doc">XmlDocument</param>
        public void ProduceQueueMessage(string queue, XmlDocument doc)
        {
            try
            {
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    connection.Start();
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(queue));
                        ITextMessage msg = producer.CreateTextMessage();
                        msg.Text = doc.InnerXml;
                        producer.Send(msg, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
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
        /// <summary>
        /// 订阅Queue消息
        /// </summary>
        /// <param name="queue"></param>
        public void SubscribeQueueMessage(string queue)
        {
            try
            {
                using (IConnection connection = _factory.CreateConnection(_user, _pwd))
                {
                    connection.Start();
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(queue));
                        consumer.Listener += new MessageListener(customer_listener);
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
