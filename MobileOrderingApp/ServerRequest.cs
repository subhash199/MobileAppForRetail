using MobileOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace MobileOrderingApp
{
   public  class ServerRequest
    {
        
            private string reply;
            private string hostName = "194.207.197.57";
            private int port = 5002;
            private string fileName = "UserDetails.txt";
            private TcpClient client;


            public string LogIn(string userName, string password)
            {
                string value = "";
                TcpClient client = new TcpClient();

                try
                {
                    client.Connect(hostName, port);
                    client.SendTimeout = 1000;
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    StreamReader sr = new StreamReader(client.GetStream());
                    sw.AutoFlush = true;
                    sw.WriteLine("logIn|" + userName + "|" + password);
                    reply = sr.ReadLine();
                    if (reply.Contains("ok"))
                    {
                        reply = reply.Remove(0, 2);
                        var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                        StreamWriter writer = new StreamWriter(backingFile);
                        writer.Write(reply);
                        value = "ok";
                    }
                    else
                    {
                        value = "NotExist";
                    }

                }


                catch (Exception e)
                {
                    throw (e);
                }
                return value;
            }

        public List<Item> ItemsRequest()
        {
            List<Item> products = new List<Item>();
            client = new TcpClient();

            try
            {

                client.Connect(hostName, port);
                client.SendTimeout = 1000;
                StreamWriter sw = new StreamWriter(client.GetStream());
                StreamReader sr = new StreamReader(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine("GetItems");
                string[] readLine = sr.ReadLine().Split('|');
                for (int i = 0; i < readLine.Length; i++)
                {
                    byte[] binaryString = Convert.FromBase64String(readLine[i + 3]);
                    string storagePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string localPath = Path.Combine(storagePath, readLine[i] + ".png");
                    File.WriteAllBytes(localPath, binaryString);

                    products.Add(new Item() { Name = readLine[i], Category = readLine[i + 1], Price = double.Parse(readLine[i + 2]), Image = readLine[i] + ".png" });
                    i = i + 4;
                }

                sw.Close();
                sr.Close();
            }
            catch (Exception e)
            {
                reply = "Problem with Server";
            }
            finally
            {

                client.Close();

            }
            return products;
        }
       

        public string Register(string details)
            {
                client = new TcpClient();
                try
                {
                    client.Connect(hostName, port);
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    StreamReader sr = new StreamReader(client.GetStream());
                    sw.AutoFlush = true;
                    sw.WriteLine("register|" + details);

                    if (sr.ReadLine() == "ok")
                    {
                        reply = "ok";

                    }
                    else
                    {
                        reply = "exist";
                    }
                    sw.Close();
                    sr.Close();
                }
                catch (Exception e)
                {
                    reply = "Problem with Server";
                }
                finally
                {

                    client.Close();

                }

                return reply;
            }

        
    }
}
