using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab7_a_ {
    class ClientObject {
        public Socket client;
        public ClientObject(Socket socketClient) {
            client = socketClient;
        }
        public void Process() {
            string data = null;

            // Мы дождались клиента, пытающегося с нами соединиться

            byte[] bytes = new byte[1024];
            int bytesRec;
            Project a = new Project();
            string reply = "",g="";
            byte[] msg;
            BinaryFormatter binFormatter = new BinaryFormatter();
            ////////////////////////
            link1:
            while (data != "stop")
            {
                bytesRec = client.Receive(bytes);
                data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                switch (data)
                {
                    case "save":
                        {
                            a.save("server.txt"); reply = "save";
                            msg = Encoding.UTF8.GetBytes(reply);
                            client.Send(msg);
                        }; break;
                    case "read":
                        {
                            a = Project.read("server.txt"); reply = "read";
                            msg = Encoding.UTF8.GetBytes(reply);
                            client.Send(msg);
                        }; break;
                    case "fill":
                        {
                            a.Fill(10); reply = "fill";
                            using (Stream wstream = new NetworkStream(client))
                            {
                                binFormatter.Serialize(wstream, a);
                            }

                            msg = Encoding.UTF8.GetBytes(reply);
                            client.Send(msg);
                        }; break;
                    case "get":
                        {
                            reply = "get";
                            using (Stream wstream = new NetworkStream(client))
                            {
                                binFormatter.Serialize(wstream, a);
                            }

                            msg = Encoding.UTF8.GetBytes(reply);
                            client.Send(msg);
                        }; break;
                    case "stop": break;
                    case "help": Console.WriteLine(" save read fill stop"); break;
                    default: Console.WriteLine("Неверная команда, введите команду help"); break;
                }
                
            }
            
            //////////////////////////
            // Отправляем ответ клиенту\






            // Показываем данные на консоли


          if (data.IndexOf("<TheEnd>") > -1)
            {
                Console.WriteLine("Сервер завершил соединение с клиентом.");
                //break;
            }
            // }
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
 }

