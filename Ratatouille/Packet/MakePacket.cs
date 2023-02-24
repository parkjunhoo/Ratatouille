using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MakePacket
{
    public static ArraySegment<byte> L_ClientReq (string address)
    {
        L_ClientReq packet = new L_ClientReq();
        packet.address = address;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
    public static ArraySegment<byte> L_ClientRes(bool condition, int port)
    {
        L_ClientRes packet = new L_ClientRes();
        packet.condition = condition;
        packet.port = port;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> L_ServerReq(string address)
    {
        L_ServerReq packet = new L_ServerReq();
        packet.address = address;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
    public static ArraySegment<byte> L_ServerRes(bool condition, int port)
    {
        L_ServerRes packet = new L_ServerRes();
        packet.condition = condition;
        packet.port = port;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> C_ScreenImage()
    {
        C_ScreenImage packet = new C_ScreenImage();
        packet.bmp = Util.ScreenToByte();
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> S_MouseMove(short x , short y)
    {
        S_MouseMove packet = new S_MouseMove();
        packet.posx = x;
        packet.posy = y;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> S_MouseClick(uint flag , short line = 0)
    {
        S_MouseClick packet = new S_MouseClick();
        packet.flag = flag;
        packet.line = line;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> S_Keyboard(uint flag , byte keycode)
    {
        S_Keyboard packet = new S_Keyboard();
        packet.flag = flag;
        packet.keycode = keycode;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
    public static ArraySegment<byte> S_SendScreenSleep(uint sleepAmount)
    {
        S_SendScreenSleep packet = new S_SendScreenSleep();
        packet.sleepAmount = sleepAmount;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
}