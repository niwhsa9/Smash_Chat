using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Client {
    class Message {
        public string text;
        public int breakLen = 10;
        public Rectangle box;
        public int height;
        public int width = 140;
        public int x=0;
        public int y=0;
        public Font font = new Font("Cambria", 12.0F, FontStyle.Bold);
        public enum Side {Left, Right};
        public Side side;
        public int absoluteHeight = 0;
        public int index;

        public Message(string text, Side side, int index) {
            this.text = text;
            this.side = side;
            this.index = index;
            setBreakLen();
            updateHeight();
           
        }

 
        public void setBreakLen() {
            var cwidth = MessageScreen.g2d.MeasureString("h", SystemFonts.DefaultFont).Width;
            breakLen = (int)(width / cwidth);
        }

        public void setPos() {
            box.X = x;
            box.Y = y;
        }

        public void updateHeight() {

            /*
            StringBuilder sb = new StringBuilder(text);
            int numAppended = 0;
            for (int i = 0; i < text.Length; i++) {
                if ((i + 1) % breakLen == 0) {
                    sb.Insert((i + 1 + numAppended), "\n");
                    numAppended += 1;
                }
            }
            Size s = TextRenderer.MeasureText(sb.ToString(), font);
            height = s.Height;
            */

            TextFormatFlags fmt = TextFormatFlags.Default | TextFormatFlags.WordBreak;  
            Size s1 = TextRenderer.MeasureText(text, font, new Size(width, 0), fmt);
            height = s1.Height + 5; //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            box = new Rectangle(x, y, width, height);
           // MessageBox.Show(""+box.Height);

        }

        public void setY() {
            int q = 15;
            for (int i = 0; i < index; i++) q += Program.heights[i] + MessagePanel.heightOffset;
            y = q;
        }
    

     



    }
}
