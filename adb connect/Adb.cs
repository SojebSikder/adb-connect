using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        public static string connect()
        {
            return executeCmd("adb", "connect 192.168.0.101:5555");
        }
        public static string disconnect()
        {
            return executeCmd("adb", "disconnect 192.168.0.101:5555");
        }
        public static string restart()
        {
            return "";
        }
        public static string refresh()
        {
            return getDevices();
        }
    }
}
