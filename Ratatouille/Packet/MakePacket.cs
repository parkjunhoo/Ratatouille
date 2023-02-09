using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MakePacket
{
    public static ArraySegment<byte> MakeC_ConnectReq(string address)
    {
        C_ConnectReq packet = new C_ConnectReq();
        packet.address = address;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
    public static ArraySegment<byte> MakeS_ConnectRes(bool condition)
    {
        S_ConnectRes packet = new S_ConnectRes();
        packet.condition = condition;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> MakeC_ScreenImage()
    {
        C_ScreenImage packet = new C_ScreenImage();
        packet.bmp = Util.ScreenToByte();
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }

    public static ArraySegment<byte> MakeS_MouseClick(float x , float y)
    {
        S_MouseClick packet = new S_MouseClick();
        packet.posx = x;
        packet.posy = y;
        ArraySegment<byte> segment = packet.Write();
        return segment;
    }
}