using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;



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
        public static bool pushToBottom = false;
        private static bool connectState = false;
        private static byte[] encryption = new byte[4];

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
        /*
        static void getEncryption() {
            try {  
                using (StreamReader sr = new StreamReader("EncryptKey.txt")) {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    // Console.WriteLine(line);
                    String[] data = line.Split(new char[] { ' ' });
                    for (int i = 0; i < encryption.Length; i++) {
                        encryption[i] = Byte.Parse(data[i]);
                    }
                }
            } catch (Exception e) {
                encryption[0] = 0;
                encryption[1] = 1;
            }
        } */

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
                f1.BeginInvoke(new Action(() => {
                    messageScreen.setCheckBox(true);
                }));
                connectState = true;
                int lastRecieve = 0;
                while (true) {

                    //  connectState = false;
                    /*
                      f1.BeginInvoke(new Action(() => {
                          messageScreen.setCheckBox(false);
                      }));
                 */
                    
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    string s = Encoding.ASCII.GetString(data, 0, size);
                    char type = s[0];
                    s = s.Remove(0, 1);
                    if (type == 'm') {
                        string[] mData = s.Split(':');
                        addMessage(new Message(s, Message.Side.Left, mCount));
                        displayBalloon(s);
                    }
                }


            } catch (Exception e) {
                
            }
        }

        public static void sendMessage(string msg) {

            msg = "m" + username + ":" + msg;
            byte[] bmsg = Encoding.ASCII.GetBytes(msg);
      
            client.Send(bmsg);

        }

        public static void addMessage(Message msg) {
            Program.messages.Add(msg);
            Program.heights.Add(msg.height);
            Program.mCount++;
            msg.setY();
            Program.pushToBottom = true;
            messageScreen.messagePanel1.Invalidate();
            // Program.pushToBottom = true;

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