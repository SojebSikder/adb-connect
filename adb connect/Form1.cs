using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            refresh();
            getAllIp();
        }
        private void connect()
        {
            setMessage(Adb.connect(cbDevice.Text));
        }
        private void restart()
        {
        }
        private void refresh()
        {
            setMessage(Adb.refresh());
        }
        private void getAllIp()
        {
            
            foreach (var item in Adb.GetLocalIPAddress())
            {
                cbDevice.Items.Add(item);
            }

            cbDevice.SelectedIndex = 0;
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
            refresh();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connect();
        }
    }
}
