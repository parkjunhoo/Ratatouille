using ServerCore;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace Ratatouille
{
    public class ListenSession : PacketSession
    {

        public override void OnConnected(EndPoint endPoint)
        {
            System.Console.WriteLine($"OnConnected :{endPoint}");
        }



        // [size(2) USHORT] [packetID (2)]
        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {
            ListenPacketManager.Instance.OnRecvPacket(this, buffer);
        }
        public override void OnDisconnected(EndPoint endPoint)
        {
            System.Console.WriteLine($"OnDisconnected :{endPoint}");
        }
        public override void OnSend(int numOfBytes)
        {
            //System.Console.WriteLine($"Transferred bytes:{numOfBytes}");
        }
    }
}
