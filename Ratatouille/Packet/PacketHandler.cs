using Ratatouille;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class PacketHandler
{


    public static void L_ClientReqHandler(PacketSession session, IPacket packet)
    {
        L_ClientReq conPacket = packet as L_ClientReq;

        MainForm _mainForm = Program.MainForm;

        if (_mainForm.requestListPanel.InvokeRequired)
        {
            _mainForm.requestListPanel.Invoke(new MethodInvoker(delegate ()
            {
                _mainForm.requestListPanel.Controls.Add(Util.CreateClientRequestUI("From Client : "+conPacket.address.ToString() , session));
            }));
        }
    }
    public static void L_ClientResHandler(PacketSession session, IPacket packet)
    {
        L_ClientRes conResPacket = packet as L_ClientRes;

        if (conResPacket.condition == true)
        {
            ServerSession ss = ServerSessionManager.Instance.Generate(); // 새 서버 세션 만들기
            try
            {
                IPEndPoint ep = session.Socket.RemoteEndPoint as IPEndPoint;
                IPEndPoint endPoint = new IPEndPoint(ep.Address, conResPacket.port);

                Connecter connecter = new Connecter();
                connecter.Connect(endPoint, () =>
                {
                    return ss;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ss.SetBackgroundWork();
            session.Disconnect();
        }

        string message = conResPacket.condition ? "원격 컨트롤이 시작됬습니다." : "클라이언트 요청이 거절됬습니다.";
        MessageBox.Show(message, "Alarm");
        
    }

    public static void L_ServerReqHandler(PacketSession session, IPacket packet)
    {
        L_ServerReq conPacket = packet as L_ServerReq;

        MainForm _mainForm = Program.MainForm;

        if (_mainForm.requestListPanel.InvokeRequired)
        {
            _mainForm.requestListPanel.Invoke(new MethodInvoker(delegate ()
            {
                _mainForm.requestListPanel.Controls.Add(Util.CreateServerRequestUI("From Server : " + conPacket.address.ToString(), session));
            }));
        }
    }
    public static void L_ServerResHandler(PacketSession session, IPacket packet)
    {
        L_ServerRes conResPacket = packet as L_ServerRes;

        if (conResPacket.condition == true)
        {
            ClientSession cs = ClientSessionManager.Instance.Generate(); // 새 클라 세션 만들기
            try
            {
                IPEndPoint ep = session.Socket.RemoteEndPoint as IPEndPoint;
                IPEndPoint endPoint = new IPEndPoint(ep.Address, conResPacket.port);

                Connecter connecter = new Connecter();
                connecter.Connect(endPoint, () =>
                {
                    return cs;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cs.MyClientControlForm.ShowDialog();
            session.Disconnect();
        }

        string message = conResPacket.condition ? "원격 컨트롤을 시작됬습니다." : "서버 요청이 거절됬습니다.";
        MessageBox.Show(message, "Alarm");
    }


    public static void C_ScreenImageHandler(PacketSession session, IPacket packet)
    {
        ClientSession cs = session as ClientSession;
        C_ScreenImage p = packet as C_ScreenImage;
        Image oldImage = cs.MyClientControlForm.clientScreenPbox.Image;
        cs.MyClientControlForm.clientScreenPbox.Image = Util.ByteArrayToImage(p.bmp);
        if (oldImage != null)
        {
            oldImage.Dispose();
        }
    }

    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

    public static void S_MouseMoveHandler(PacketSession session, IPacket packet)
    {
        S_MouseMove pkt = packet as S_MouseMove;
        Cursor.Position = new Point((int)pkt.posx, (int)pkt.posy);
    }
    public static void S_MouseClickHandler(PacketSession session, IPacket packet)
    {
        S_MouseClick pkt = packet as S_MouseClick;
        mouse_event(pkt.flag, 0, 0, 0, 0);
    }

    public static void S_KeyboardHandler(PacketSession session, IPacket packet)
    {
        S_Keyboard pkt = packet as S_Keyboard;
        keybd_event(pkt.keycode,0, pkt.flag , 0);
        Console.WriteLine($"keycode:{pkt.keycode}");
        Console.WriteLine($"flag:{pkt.flag}");

    }
}