using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.ServiceProcess;



namespace ChatServer {

    struct QueuedMessage {
        public QueuedMessage(int clientID, string message) {
            this.clientID = clientID;
            this.message = message;
        }
        public int clientID;
        public string message;
    }

    class Program : ServiceBase {
        public static IPAddress ipAddress;
        public static IPEndPoint serverEP;
        static List<Socket> handler = new List<Socket>();
        private static List<Thread> client = new List<Thread>();
        public static int i = 0;
        private static Thread listener;
        public static List<QueuedMessage> queue = new List<QueuedMessage>();

        public Program() {
            this.ServiceName = "Smash Chat Server";
            this.EventLog.Log = "SmashChat";
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }

        static void send(string m, Socket handler) {
            byte[] msg = Encoding.ASCII.GetBytes(m);
            handler.Send(msg);
        }

        static void listen(Socket hndl, int id) {
            try {
                i++;
                while (true) {
                   
                    byte[] data = new byte[1024];
                 
                    int size = hndl.Receive(data); //handler
                    
                    string s = Encoding.ASCII.GetString(data, 0, size);
                    queue.Add(new QueuedMessage(id, s));
                   // send("echo " + s, hndl);

                }

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                handler.RemoveAt(id);
                client.RemoveAt(id);
               // Console.WriteLine("Closing");
               // Console.ReadKey();
            }
        }

        static void acceptConnections() {
            ipAddress = IPAddress.Parse("10.0.0.8");
            serverEP = new IPEndPoint(ipAddress, 9191);

            Socket server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            server.Bind(serverEP);
            server.Listen(10);
            while (true) {
                handler.Add(server.Accept());
                Console.WriteLine(i);
                client.Add(new Thread(() => listen(handler[i], i)));
                client[i].Start();
                send("SERVER: Connected to " + "68.101.98.197" + " on " + serverEP.Port, handler[i]);
                //i++;
                //handler.Shutdown(SocketShutdown.Both);
                //handler.
            }
        }

        static void Main(string[] args) {
         //   ServiceBase.Run(new Program());
            listener = new Thread(new ThreadStart(acceptConnections)); //new ThreadStart(listen)
            listener.Start();
            while(true) {
                //  Console.WriteLine(i);
                try {
                    if (queue.Count > 0) {
                        for (int i = queue.Count - 1; i >= 0; i--) {
                            for (int n = 0; n < handler.Count; n++) {
                                if (handler[n] == null) break;
                                if (queue[i].clientID == n) continue;
                                send(queue[i].message, handler[n]);
                            }
                            queue.RemoveAt(i);
                        }
                    }
                } catch(Exception e) {
                    continue;

                }
            }
        }
    }
}
