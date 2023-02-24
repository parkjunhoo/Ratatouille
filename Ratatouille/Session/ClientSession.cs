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
            this.MyClientControlForm.MySession = this;
            if (this.MyClientControlForm.InvokeRequired)
            {
                this.MyClientControlForm.Invoke(new MethodInvoker(delegate ()
                {
                    Application.Run(this.MyClientControlForm);
                }));
            }
            else
            {
                Application.Run(this.MyClientControlForm);
            }
            this.Send(MakePacket.S_SendScreenSleep(150));
        }

        public override void Disconnect()
        {
            if (this.MyClientControlForm.InvokeRequired)
            {
                this.MyClientControlForm.Invoke(new MethodInvoker(delegate ()
                {
                    this.MyClientControlForm.Close();
                }));
            }
            else
            {
                this.MyClientControlForm.Close();
            }

            ClientSessionManager.Instance.Remove(this);
            base.Disconnect();
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
