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
        bool state = false;
        public static Graphics g2d;
     
        public MessageScreen() {
            InitializeComponent();
            g2d = messagePanel1.CreateGraphics();
           
        }
      

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void submit_Click(object sender, EventArgs e) {
            string text = textEntry.Text;

            Message msg = new Message(text, Message.Side.Right, Program.mCount);
            Program.addMessage(msg);
            Program.sendMessage(msg.text);
            //Program.sendMessage(text);
            textEntry.Clear();

        }

        private void messagePanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            Program.username = textBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

        public void setCheckBox(bool value) {
            checkBox1.Checked = value;
        }
    }
}
