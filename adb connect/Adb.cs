using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace adb_connect
{
    class Adb
    {
        public static string device;
        public static string setDevice()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIP;
            //device = id;
        }
        private static string executeCmd(string filename, string args)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = args;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            return output;
        }
        public static string getDevices()
        {
            return executeCmd("adb", "devices");
        }
        public static string connect()
        {
            return executeCmd("adb", "connect"+ device +":5555");
        }
        public static string disconnect()
        {
            return executeCmd("adb", "disconnect"+ device +":5555");
        }
        public static string restart()
        {
            return "";
        }
        public static string refresh()
        {
            return setDevice();
            //executeCmd("adb", "tcpip 5555");
            //return getDevices();
        }

        public static List<string> GetLocalIPAddress()
        {
            List<string> ipAdd = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAdd.Add(ip.ToString());
                    Console.WriteLine(ip.ToString()+"\n");
                }
            }
            return ipAdd;
            //throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
