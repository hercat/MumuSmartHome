using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using log4net;
using System.Reflection;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:邮件发送帮助类
    /// Author:WUWEI
    /// Date:2018/09/30
    /// </summary>
    public class EMailHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region SMTP邮箱服务器地址
        private static string _mailSmtpServer;
        public string MailSmtpServer
        {
            get { return _mailSmtpServer; }
            set { _mailSmtpServer = value; }
        }
        #endregion

        #region SMTP凭证邮箱
        private static string _mailCredential;
        public string MailCredential
        {
            get { return _mailCredential; }
            set { _mailCredential = value; }
        }
        #endregion

        #region SMTP凭证邮箱密码
        private static string _mailCredentialPwd;
        public string MailCredentialPwd
        {
            get { return _mailCredentialPwd; }
            set { _mailCredentialPwd = value; }
        }
        #endregion
        /// <summary>
        /// 发送SMTP邮件
        /// </summary>
        /// <param name="mailFrom">发件人</param>
        /// <param name="mailTo">收件人(多个收件人用;隔开)</param>
        /// <param name="mailSubject">主题</param>
        /// <param name="mailBody">内容</param>
        /// <param name="mailAttach">附件(多个附件用;隔开)</param>
        /// <param name="mailPriority">优先级</param>
        /// <param name="mailCC">抄送人(多个抄送人用;隔开)</param>
        /// <param name="resultMessage">返回信息</param>
        public void SendSmtpMail(string mailFrom, string mailTo, string mailSubject, string mailBody, string mailAttach, string mailPriority, string mailCC, out string resultMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(mailFrom))
                {
                    resultMessage = "error:mailFrom is null";
                    return;
                }
                if (string.IsNullOrEmpty(mailTo))
                {
                    resultMessage = "error:mailTo is null";
                    return;
                }

                MailMessage email = new MailMessage();
                MailAddress emailFrom = new MailAddress(mailFrom);
                //指定发件人地址
                email.From = emailFrom;
                //收件人
                string[] toUsers = mailTo.Split(';');
                foreach (string to in toUsers)
                {
                    //用于处理收件人结尾可能有;情况
                    if (!string.IsNullOrEmpty(to))
                    {
                        //邮箱有效性验证
                        if (RegexMatchHelper.RegexEmailAddressMatch(to))
                            email.To.Add(to);//添加收件人邮箱
                    }
                }
                //抄送人
                if (!string.IsNullOrEmpty(mailCC))
                {
                    string[] ccUsers = mailCC.Split(';');
                    foreach (string cc in ccUsers)
                    {
                        //用于处理抄送人结尾可能要;情况
                        if (!string.IsNullOrEmpty(cc))
                        {
                            //邮箱有效性验证
                            if (RegexMatchHelper.RegexEmailAddressMatch(cc))
                                email.CC.Add(cc);//添加抄送人邮箱
                        }
                    }
                }
                //主题
                email.Subject = mailSubject;
                //内容
                email.Body = mailBody;
                //附件
                if (!string.IsNullOrEmpty(mailAttach))
                {
                    string[] attachments = mailAttach.Split(';');
                    foreach (string file in attachments)
                    {
                        //用于处理多个附件结尾可能存在;情况
                        if (!string.IsNullOrEmpty(file))
                        {
                            Attachment attach = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
                            //附件添加发送时间
                            System.Net.Mime.ContentDisposition disposition = attach.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(file);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                            //添加附件
                            email.Attachments.Add(attach);
                        }
                    }
                }
                //优先级
                email.Priority = mailPriority == "High" ? MailPriority.High : MailPriority.Normal;
                //内容编码格式
                email.BodyEncoding = System.Text.Encoding.UTF8;
                //设置正文内容是否为html格式的值
                email.IsBodyHtml = true;
                //SMTP服务器地址
                SmtpClient client = new SmtpClient(_mailSmtpServer);
                //验证(Credentials凭证)
                client.Credentials = new System.Net.NetworkCredential(_mailCredential, _mailCredentialPwd);
                //处理待发的电子邮件方法
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //发送邮件
                client.Send(email);
                resultMessage = "send your email success";
            }
            catch (Exception ex)
            {
                log.Error(string.Format("SendSmtpMail()发生错误,错误信息如下:{0}", ex));
                resultMessage = "error:" + ex.Message;
            }
        }

    }
}
