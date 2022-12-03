using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KonusmaCns
{
    class Program
    {
        static void Main(string[] args)
        {
            var tr = new Thread(new ThreadStart(Dinle));
            tr.Start();
            Console.Read();
        }

        static void Dinle()
        {
            var UdpServer = new UdpClient();
            UdpServer.Client.Bind(new IPEndPoint(IPAddress.Any, 8888)); // Herhangi bir IP den gelen 8888. porttan gelen mesajı dinliyor
            UdpServer.EnableBroadcast = true;
            var ClientIP = new IPEndPoint(0, 8888);
            while (true) { 
            var b = UdpServer.Receive(ref ClientIP);
            string s = Encoding.Default.GetString(b);//gelen mesajı s adlı değişkene atıyor.
             Console.WriteLine("Bir şeyler geldi: " + s);// ekrana yazdırıyor.
       
            
            }
        }
    }
}
 
