using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adb_connect
{
    class Adb
    {
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
        public static string startServer(string port = "5555")
        {
            return executeCmd("adb", "tcpip 5555 " + port);
        }
        public static string connect(string ip,string port = "5555")
        {
            return executeCmd("adb", "connect "+ ip + ":"+port);
        }
        public static string disconnect(string ip,string port = "5555")
        {
            return executeCmd("adb", "disconnect "+ ip + ":"+port);
        }
        // Get Ip address from adb using device id
        public static string getIpFromAdb(string deviceId= "442f3d0d")
        {
            return executeCmd("adb", "-s "+deviceId+" shell ip -0 -4 addr");
        }
        public static string restart()
        {
            return "";
        }
        public static string refresh()
        {
            return "";
            //executeCmd("adb", "tcpip 5555");
            //return getDevices();
        }

        public static List<string> GetLocalIPAddress()
        {
            List<string> ipAdd = new List<string>();
            var addresses = Dns.GetHostEntry((Dns.GetHostName()))
                    .AddressList
                    .Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                    .Select(x => x.ToString()).ToList();

            return addresses;
        }


//1: lo inet 127.0.0.1/8 scope host lo\       valid_lft forever preferred_lft forever
//32: wlan0 inet 192.168.10.241/24 brd 192.168.10.255 scope global wlan0\       valid_lft forever preferred_lft forever
        public static MatchCollection parseAddress(string stdout)
        {
            //string pattern = @"/(?<=inet\s+)(((\d+)\.)+(\d+))\/\d+/g";
            string pattern = @"(((\d+)\.)+(\d+))\/\d+";
            Regex rg = new Regex(pattern, RegexOptions.ECMAScript);
            MatchCollection matches = rg.Matches(stdout);

            //foreach (Match match in matches)
            //{
            //    try
            //    {
            //        Console.WriteLine(match.Value);
            //    }
            //    catch { }
            //}
            return matches;

           
        }
    }
}
