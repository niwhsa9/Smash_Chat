using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Chat_Client {
    static class Program {
        public static int mCount = 0;
        static Form1 f1;
        static MessageScreen messageScreen;
        public static List<Message> messages = new List<Message>();
        public static List<int> heights = new List<int>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new Form1();
            Thread networker = new Thread(new ThreadStart(startNetworker));
            Thread manager = new Thread(new ThreadStart(startManager));
            networker.Start();
            manager.Start();
            try {
                Application.Run(f1);
            } catch(Exception ex) {

            }
        }

        static void startManager() {
            Thread.Sleep(1000);
            f1.BeginInvoke(new Action(() =>
            {
                f1.Controls.Remove(f1.loadingImage);
         
                messageScreen = new MessageScreen();
                 messageScreen.Dock = DockStyle.Fill;
                f1.Controls.Add(messageScreen);

            }));
            
        }
        static void startNetworker() {
            Thread.Sleep(1000);
          
            
            
        }
    }
}

/*
TODO:
- Setup webserver on Raspberry Pi to handle 2 way communication
- Allow multi client connect
- Encrypt messages
-scrollbar on messages
-better message icon
-custom connection user control w/ port, ip, choose host, choose encrypt

*/