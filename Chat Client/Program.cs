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
        public static string username = "duh";
        public static int mCount = 0;
        static Form1 f1;
        static MessageScreen messageScreen;
        public static List<Message> messages = new List<Message>();
        public static List<int> heights = new List<int>();
        public static Socket client;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new Form1();
            // Thread.Sleep(300);
            //while (!f1.IsHandleCreated);
          
            Thread networker = new Thread(new ThreadStart(startNetworker));
            Thread manager = new Thread(new ThreadStart(startManager));
         
            networker.Start();
            manager.Start();
            try {
                Application.Run(f1);
            } catch(Exception ex) {

            }
        }

        static void displayBalloon(string text) {
            var notification = new System.Windows.Forms.NotifyIcon() {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                // optional - BalloonTipTitle = "My Title",
                BalloonTipText = text,
            };
            // Display for 5 seconds.
            notification.ShowBalloonTip(5);

        }

        static void startManager() {

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

            IPAddress ipAddress = IPAddress.Parse("10.0.0.8");
            IPEndPoint server = new IPEndPoint(ipAddress, 9191);

            // Create a TCP/IP  socket.
            client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try {
                client.Connect(server);
               
                Console.WriteLine("Connected to chat-server at {0}",
                    client.RemoteEndPoint.ToString());
                while(true) {
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    string s = Encoding.ASCII.GetString(data, 0, size);
                    string[] mData = s.Split(':');
                    addMessage(new Message(s, Message.Side.Right, mCount));
                        
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
- Allow multi client connect
- Encrypt messages
-scrollbar on messages
-better message icon
-custom connection user control w/ port, ip, choose host, choose encrypt
-baloon notification
*/