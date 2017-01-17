using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client {
    public partial class MessageScreen : UserControl {
        Graphics g2d;
        public MessageScreen() {
            InitializeComponent();
            g2d = messagePanel.CreateGraphics();
        }
      

        void render(Message m) {
            //g2d.FillRectangle(new SolidBrush(System.Drawing.Color.Red), new Rectangle(0, 0, 200, 300));
            g2d.DrawString(m.text, m.font, Brushes.Blue, m.box);
            g2d.DrawRectangle(Pens.Black, Rectangle.Round(m.box));

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
       

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void submit_Click(object sender, EventArgs e) {
            string text = textEntry.Text;
            Message msg = new Message(text);
            Program.messages.Add(msg);
            textEntry.Clear();
            render(msg);
            
        }
    }
}
