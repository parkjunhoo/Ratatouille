using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // DNS (Domain Name System)
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            while (true)
            {
                try
                {
                    //소켓 생성
                    Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    //Connect
                    socket.Connect(endPoint);
                    Console.WriteLine($"Connected To {socket.RemoteEndPoint.ToString()}");

                    //Send
                    for(int i=0; i<5; i++)
                    {
                        byte[] sendBuff = Encoding.UTF8.GetBytes($"Hello!{i}");
                        int sendBytes = socket.Send(sendBuff);
                    }
                    

                    //Recv
                    byte[] recvBuff = new byte[1024];
                    int recvBytes = socket.Receive(recvBuff);
                    string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                    Console.WriteLine($"[From Server] : {recvData}");

                    //Close
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Thread.Sleep(100);
            }
            

            
            
        }
    }
}