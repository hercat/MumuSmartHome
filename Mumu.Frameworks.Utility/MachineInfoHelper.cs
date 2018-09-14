using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.Net;
using System.Net.NetworkInformation;
using System.Management;
using System.Text.RegularExpressions;
using System.IO;

namespace Mumu.Frameworks.Utility
{
    public class MachineInfoHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 获取本地的IP地址列表
        /// </summary>
        /// <returns></returns>
        public static IPAddress[] GetMachineIPAddress()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] iplist = Dns.GetHostAddresses(hostname);
            return iplist;
        }
        /// <summary>
        /// 获取本地IPv4地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetMachineIPv4()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] list = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in list)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip;
            }
            return null;
        }
        /// <summary>
        /// 获取本地IPv6地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetMachineIPv6()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] list = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in list)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    return ip;
            }
            return null;
        }
        /// <summary>
        /// 获取网卡地址
        /// </summary>
        /// <returns></returns>
        public static string GetMachineMacAddress()
        {
            string mac = null;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        mac = mo["MacAddress"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mac;
        }

        public static string GetInternetIPAddress()
        {
            string ip = null;
            try
            {
                WebRequest request = WebRequest.Create("http://www.ip138.com/ips138.asp");
                Stream stream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                ip = reader.ReadToEnd();
                Regex reg = new Regex("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}");
                Match match = reg.Match(ip);
                ip = match.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ip;
        }
    }
}
