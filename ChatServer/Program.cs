using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ChatServer {

    struct QueuedMessage {
        public int clientID;
        public string message;
    }

    class Program {
        public static IPAddress ipAddress;
        public static IPEndPoint serverEP;
        static Socket[] handler = new Socket[10];
        private static Thread[] client = new Thread[10];
        public static int i = 0;
        private static Thread listener;
        public static QueuedMessage[] queue = new QueuedMessage[20];

        static void send(string m, Socket handler) {
            byte[] msg = Encoding.ASCII.GetBytes(m);
            handler.Send(msg);
        }

        static void listen(Socket hndl) {
            try {
                i++;
                while (true) {
                   
                    byte[] data = new byte[1024];
                    Console.WriteLine("trying");
                    int size = hndl.Receive(data); //handler

                    string s = Encoding.ASCII.GetString(data, 0, size);
                    send("echo " + s, hndl);

                }

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Closing");
                Console.ReadKey();
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
                handler[i] = server.Accept();
                client[i] = new Thread(() => listen(handler[i]));
                client[i].Start();
                send("Connected to " + ipAddress.ToString() + " on " + serverEP.Port, handler[i]);
               // i++;
                //handler.Shutdown(SocketShutdown.Both);
                //handler.
            }
        }

        static void Main(string[] args) {
            listener = new Thread(new ThreadStart(acceptConnections)); //new ThreadStart(listen)
            listener.Start();
            while(true) {
            Console.WriteLine(i);
            }
        }
    }
}
