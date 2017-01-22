using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Chat_Client {
    public partial class MessageScreen : UserControl {
       
        Graphics g2d;
     
        public MessageScreen() {
            InitializeComponent();
            g2d = messagePanel1.CreateGraphics();
            messagePanel1.AutoScrollMinSize = new Size(0, 1000);
        }
      

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void submit_Click(object sender, EventArgs e) {
            string text = textEntry.Text;
            Message msg = new Message(text, Message.Side.Right, Program.mCount);
            Program.messages.Add(msg);
            Program.heights.Add(msg.height);
            Program.mCount++;
            textEntry.Clear();
            messagePanel1.Invalidate();

            
        }

        private void messagePanel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
