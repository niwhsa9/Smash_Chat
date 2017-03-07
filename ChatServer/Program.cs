using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatServer {
    class Program {
        static Socket handler = null;
        static void send(string m) {
            byte[] msg = Encoding.ASCII.GetBytes(m);
            handler.Send(msg);
            
        }
  
        static void Main(string[] args) {         
            IPAddress ipAddress = IPAddress.Parse("10.0.0.8");
            IPEndPoint serverEP = new IPEndPoint(ipAddress, 9191 );

            Socket server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            byte[] bytes = new Byte[1024];

            try {
                server.Bind(serverEP);
                server.Listen(10);
                while (handler == null) {
                    handler = server.Accept();
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.
                }
                send("Connected to " + ipAddress.ToString() + " on " + serverEP.Port);
                while(true) {
                     

                    byte[] data = new byte[1024];
                    Console.WriteLine("trying");
                    int size = handler.Receive(data); //handler

                    string s = Encoding.ASCII.GetString(data, 0, size);
                    send("echo " + s);
                }

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Closing");
                Console.ReadKey();
            }
        }
    }
}
