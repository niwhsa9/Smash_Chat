using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Chat_Client {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // UserControl1 u1 = new UserControl1();
            // u1.Dock = DockStyle.Fill;
            //this.Controls.Add(u1);
            Program.networker = new Thread(new ThreadStart(Program.startNetworker));
            Program.manager = new Thread(new ThreadStart(Program.startManager));

            Program.networker.Start();
            Program.manager.Start();
        }
    }
}
