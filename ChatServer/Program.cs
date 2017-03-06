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
            string data = null;
            byte[] bytes = new Byte[1024];

            try {
                server.Bind(serverEP);
                server.Listen(10);
                while (handler == null) {
                    Console.WriteLine("trying");
                    handler = server.Accept();
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.
                }
                send("Connected to " + ipAddress.ToString() + " on " + serverEP.Port);
                while(true) {

                }

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Closing");
                Console.ReadKey();
            }
        }
    }
}
