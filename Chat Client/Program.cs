using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;



namespace Chat_Client {
   static class Program {
        public static string username = "Username";
        public static int mCount = 0;
        static Form1 f1;
        static MessageScreen messageScreen;
        public static List<Message> messages = new List<Message>();
        public static List<int> heights = new List<int>();
        public static Socket client;
        public static Thread networker;
        public static Thread manager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new Form1();
     
            try {
                Application.Run(f1);
            } catch(Exception ex) {

            }
        }

        static void displayBalloon(string text) {
            var notification = new System.Windows.Forms.NotifyIcon() {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
          
                BalloonTipTitle = "Smash Chat:",
                BalloonTipText = text,
               
            };
            // Display for 5 seconds.
            notification.ShowBalloonTip(2);
            //notification.Dispose();

        }

        public static void startManager() {

            f1.BeginInvoke(new Action(() =>
            {
                f1.Controls.Remove(f1.loadingImage);
         
                messageScreen = new MessageScreen();
                 messageScreen.Dock = DockStyle.Fill;
                f1.Controls.Add(messageScreen);

            }));
            
        }
        public static void startNetworker() {
            Thread.Sleep(1000);

            IPAddress ipAddress = IPAddress.Parse("68.101.98.197");
            IPEndPoint server = new IPEndPoint(ipAddress, 9191);

            // Create a TCP/IP  socket.
            client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try {
                client.Connect(server);
              
                while (true) {
                   
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    string s = Encoding.ASCII.GetString(data, 0, size);
                    string[] mData = s.Split(':');
                    addMessage(new Message(s, Message.Side.Left, mCount));
                 
                    displayBalloon(s);

                }


            } catch (Exception e) {
               
            }
        }

        public static void sendMessage(string msg) {
            msg = username + ":" + msg;
            byte[] bmsg = Encoding.ASCII.GetBytes(msg);
            client.Send(bmsg);
        }

        public static void addMessage(Message msg) {
            Program.messages.Add(msg);
            Program.heights.Add(msg.height);
            Program.mCount++;
            msg.setY();
            messageScreen.messagePanel1.Invalidate();
           
        }

        
    }
}

/*
TODO:
- Setup webserver on Raspberry Pi to handle 2 way communication
- Encrypt messages
-rounded boxes
-color changing
-better message icon
-custom connection user control w/ port, ip, choose host, choose encrypt
-menu
-better UI
-baloon notification
-Allow better colors/multifont/bold/etc
*/