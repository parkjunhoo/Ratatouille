using Ratatouille;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class PacketHandler
{
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

    public static void C_ConnectReqHandler(PacketSession session, IPacket packet)
    {
        C_ConnectReq conPacket = packet as C_ConnectReq;
        ClientSession clientSession = session as ClientSession;

        MainForm _mainForm = Program.MainForm;

        if (_mainForm.requestListPanel.InvokeRequired)
        {
            _mainForm.requestListPanel.Invoke(new MethodInvoker(delegate ()
            {
                _mainForm.requestListPanel.Controls.Add(Util.CreateRequestUI("From Client : "+conPacket.address.ToString() , session));
            }));
        }
    }
    public static void S_ConnectResHandler(PacketSession session, IPacket packet)
    {
        S_ConnectRes conResPacket = packet as S_ConnectRes;
        ServerSession serverSession = session as ServerSession;

        string message = conResPacket.condition ? "원격 접속을 시작했습니다." : "원격 제어 요청이 거절됬습니다.";
        MessageBox.Show(message, "Alarm");

        serverSession.SetBackgroundWork();
    }


    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
    public static void S_MouseClickHandler(PacketSession session, IPacket packet)
    {
        S_MouseClick pkt = packet as S_MouseClick;
        Cursor.Position = new Point((int)pkt.posx, (int)pkt.posy);
        mouse_event(0x0002, 0, 0, 0, 0);
        Thread.Sleep(40);
        mouse_event(0x0004, 0, 0, 0, 0);
    }
}