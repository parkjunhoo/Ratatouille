using ServerCore;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace Ratatouille
{
    public class ClientSession : PacketSession
    {
        public ClientControlForm MyClientControlForm = new ClientControlForm();
        public void ShowControlForm()
        {
            if(MyClientControlForm == null) MyClientControlForm = new ClientControlForm();
            MyClientControlForm.Show();
        }
        int _sessionId = 0;
        public int SessionId { 
            get
            {
                return _sessionId;
            }
            set 
            {
                MyClientControlForm.Text = value.ToString();
                MyClientControlForm.titleLabel.Text = value.ToString();
                MyClientControlForm.MySession = this;
                _sessionId = value;
            }
        }

        public override void OnConnected(EndPoint endPoint)
        {
            System.Console.WriteLine($"OnConnected :{endPoint}");
        }



        // [size(2) USHORT] [packetID (2)]
        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {
            ServerPacketManager.Instance.OnRecvPacket(this, buffer);
        }
        public override void OnDisconnected(EndPoint endPoint)
        {
            ClientSessionManager.Instance.Remove(this);

            System.Console.WriteLine($"OnDisconnected :{endPoint}");
        }
        public override void OnSend(int numOfBytes)
        {
            //System.Console.WriteLine($"Transferred bytes:{numOfBytes}");
        }
    }
}
