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
        private void refresh()
        {
            rtbLog.Text += Adb.refresh();
            rtbLog.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adb.connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

    }
}
