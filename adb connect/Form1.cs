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
        }
        private void connect()
        {
            rtbLog.Text += Adb.connect();
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }
        private void restart()
        {
            rtbLog.Text += Adb.restart();
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }
        private void refresh()
        {
            rtbLog.Text += Adb.refresh();
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Adb.disconnect();
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
