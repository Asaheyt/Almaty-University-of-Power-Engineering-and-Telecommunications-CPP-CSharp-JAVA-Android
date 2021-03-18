using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab7_a_ {
    class Client {
        public static void Run() {
            byte[] bytes = new byte[1024];
            //Соединяемся с удаленным устройством
            try
            {
                //Устанавливаем удаленную конечную точку для сокета
                //IPHostEntry ipHost = Dns.Resolve("169.254.59.93");
                //IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
                Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                //Соединяем сокет с удаленной конечной точкой
                sender.Connect(ipEndPoint);
                Console.WriteLine("Connection... {0}",
                sender.RemoteEndPoint.ToString());

                ////////////////////
                string theMessage = "";
                byte[] msg;
                int bytesSent;
                int bytesRec;
                Programer x = new Programer();
                Project a = new Project();
                BinaryFormatter binFormatter = new BinaryFormatter();
                while (theMessage != "stop")
                {
                    Console.WriteLine("Введите команду help");
                    theMessage = Console.ReadLine();
                    msg = Encoding.ASCII.GetBytes(theMessage);
                    switch (theMessage)
                    {
                        case "add": { x.Read(); a.Add(x); }; break;
                        case "del": a.DelLast(); break;
                        case "show": a.Show(); break;
                        case "sort": a.Sort(); break;
                        case "reverse": a.Reverse(); break;
                        case "clear": a.Clear(); break;
                        case "deldupl": a.DelDupl(); break;
                        case "save":
                            {
                                bytesSent = sender.Send(msg); bytesRec = sender.Receive(bytes); Console.WriteLine("Server says : {0}",
             Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            }; break;
                        case "read":
                            {
                                bytesSent = sender.Send(msg); bytesRec = sender.Receive(bytes); Console.WriteLine("Server says : {0}",
               Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            }; break;
                        case "fill":
                            {
                                bytesSent = sender.Send(msg);
                                using (Stream rstream = new NetworkStream(sender))
                                {
                                    a = (Project)binFormatter.Deserialize(rstream);
                                }
                                bytesRec = sender.Receive(bytes); Console.WriteLine("Server says : {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            }; break;
                        case "get":
                            {
                                bytesSent = sender.Send(msg);
                                using (Stream rstream = new NetworkStream(sender))
                                {
                                    a = (Project)binFormatter.Deserialize(rstream);
                                }
                                bytesRec = sender.Receive(bytes); Console.WriteLine("Server says : {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            }; break;
                        case "stop": break;
                        case "help": Console.WriteLine("add del show sort reverse clear deldupl save read fill stop"); break;
                        default: Console.WriteLine("Неверная команда, введите команду help"); break;
                    }
                }
                 
                //отправляем данные через сокет
                 
               

                //Получаем ответ от удаленного устройства
                
                    
               // }
                //Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);

                sender.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
    }
}
