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
        public static int minScroll = 0;
 
        public static readonly int heightOffset = 10;
        

        public MessagePanel() {
            this.AutoScroll = true;
            DoubleBuffered = true;
            this.AutoScrollMinSize = new Size(0, minScroll);
            InitializeComponent();
        }

        void render(Message m, Graphics g2d) {
      
            if (m.side == Message.Side.Left) m.x = (int)((double)this.Width / (double) xSegment * (double)xOffsetLeft);
            else m.x = (int)(this.Width-((double)this.Width / (double)xSegment * (double)xOffsetRight))-m.width;

            m.setPos();

            //Console.WriteLine(m.box.Width);
          
            if (m.side == Message.Side.Right) {
                g2d.FillRectangle(Brushes.LimeGreen, Rectangle.Round(m.box));
                g2d.DrawString(m.text, m.font, Brushes.Blue, m.box);
            } else {
                g2d.FillRectangle(Brushes.Coral, Rectangle.Round(m.box));
                g2d.DrawString(m.text, m.font, Brushes.Blue, m.box);
            }



        }


        protected override void OnPaint(PaintEventArgs pe) {
            pe.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            foreach (Message m in Program.messages) {
                render(m, pe.Graphics);
            }
            Message bottom = null;
            if (Program.messages.Count > 0) {
               bottom = Program.messages[Program.messages.Count - 1];
               minScroll = bottom.y + bottom.height;
            }
          
            this.AutoScrollMinSize = new Size(0, minScroll);
            base.OnPaint(pe);
            
        }
    }
}
