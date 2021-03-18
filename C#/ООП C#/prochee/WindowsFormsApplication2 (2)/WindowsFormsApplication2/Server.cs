using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;
using WindowsFormsApplication2;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication2
{
    class Server
    {
        public static void Run()
        {
            // Устанавливаем для сокета локальную конечную точку
            //IPHostEntry ipHost = Dns.GetHostEntry("169.254.59.93");
            // IPAddress ipAddr = ipHost.AddressList[0]; 
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8005);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec;
                    Kafedra a = new Kafedra();
                    string reply = "";
                    byte[] msg;
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    ////////////////////////
                    while (data != "stop")
                    {
                        bytesRec = handler.Receive(bytes);
                        data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                        switch (data)
                        {
                            case "save":
                                {
                                    a.save("server.txt"); reply = "save";
                                    msg = Encoding.UTF8.GetBytes(reply);
                                    handler.Send(msg);
                                }; break;
                            case "read":
                                {
                                    a = Kafedra.read("server.txt"); reply = "read";
                                    msg = Encoding.UTF8.GetBytes(reply);
                                    handler.Send(msg);
                                }; break;
                            case "fill":
                                {
                                    a.Fill(10); reply = "fill";
                                    using (Stream wstream = new NetworkStream(handler))
                                    {
                                        binFormatter.Serialize(wstream, a);
                                    }

                                    msg = Encoding.UTF8.GetBytes(reply);
                                    handler.Send(msg);
                                }; break;
                            case "get":
                                {
                                    reply = "get";
                                    using (Stream wstream = new NetworkStream(handler))
                                    {
                                        binFormatter.Serialize(wstream, a);
                                    }

                                    msg = Encoding.UTF8.GetBytes(reply);
                                    handler.Send(msg);
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
                        break;
                    }
                    // }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
