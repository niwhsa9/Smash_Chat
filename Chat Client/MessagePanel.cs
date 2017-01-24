using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client {
    public partial class MessagePanel : Panel {
        readonly int xSegment = 10;
        readonly int xOffsetLeft = 1;
        readonly int xOffsetRight = 1;
 
        public static readonly int heightOffset = 10;
        

        public MessagePanel() {
            this.AutoScroll = true;
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        void render(Message m, Graphics g2d) {
      
            if (m.side == Message.Side.Left) m.x = (int)((double)this.Width / (double) xSegment * (double)xOffsetLeft);
            else m.x = (int)(this.Width-((double)this.Width / (double)xSegment * (double)xOffsetRight))-m.width;

            m.setPos();

            //Console.WriteLine(m.box.Width);
            g2d.DrawString(m.text, m.font, Brushes.Blue, m.box);
            g2d.DrawRectangle(Pens.Black, Rectangle.Round(m.box));


        }


        protected override void OnPaint(PaintEventArgs pe) {
            pe.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            foreach (Message m in Program.messages) {
                render(m, pe.Graphics);
            }
     
            base.OnPaint(pe);
        }
    }
}
