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
        public Font font = new Font("Arial", 12.0F);
        

        public Message(string text) {
            this.text = text;

            StringBuilder sb = new StringBuilder(text);
            int numAppended = 0;
            for (int i = 0; i < text.Length; i++) {
                if ((i + 1) % breakLen == 0) {
                    sb.Insert((i + 1+numAppended), "\n");
                    numAppended += 1;
                }
            }
           // text = sb.ToString();
            Size s = TextRenderer.MeasureText(sb.ToString() + numAppended, font);
            height = s.Height;
            box = new Rectangle(0, 0, 100, height);
        }

     



    }
}
