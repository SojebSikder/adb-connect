using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adb_connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getAllIp();
        }
        private void connect()
        {
            setMessage(Adb.startServer());
            setMessage(Adb.connect(cbDevice.Text));
        }
        private void getAllIp()
        {
            string input = Adb.getIpFromAdb();

            foreach (Match match in Adb.parseAddress(input))
            {
                try
                {
                    string onlyIp = match.Value.Split('/')[0];
                    cbDevice.Items.Add(onlyIp);
                    cbDevice.SelectedIndex = 0;
                }
                catch { }
            }

            
        }
        private void setMessage(string value)
        {
            rtbLog.Text += value + "\n";
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }


        // Events

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            setMessage(Adb.disconnect(cbDevice.Text));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getAllIp();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
           setMessage(Adb.restart());
        }
    }
}
