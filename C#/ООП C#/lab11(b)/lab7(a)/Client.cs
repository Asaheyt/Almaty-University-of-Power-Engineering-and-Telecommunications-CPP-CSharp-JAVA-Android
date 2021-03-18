using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab7_a_ {
    class Client {
        public void Run() {
            byte[] bytes = new byte[1024];
            //Соединяемся с удаленным устройством
            try
            {
                //Устанавливаем удаленную конечную точку для сокета
                //IPHostEntry ipHost = Dns.Resolve("169.254.59.93");
                //IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("172.20.10.14"), 8005);
                Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                //Соединяем сокет с удаленной конечной точкой
                sender.Connect(ipEndPoint);
                Console.WriteLine("Connection... {0}",
                sender.RemoteEndPoint.ToString());
                string theMessage = "";
                while (!(theMessage == "Bye"))
                {
                    theMessage = Console.ReadLine();
                    byte[] msg = Encoding.ASCII.GetBytes(theMessage);
                    //отправляем данные через сокет
                    int bytesSent = sender.Send(msg);
                    //Получаем ответ от удаленного устройства
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Server says : {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                }
                //Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);

                sender.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
