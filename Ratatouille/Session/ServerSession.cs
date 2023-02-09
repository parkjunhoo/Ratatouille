using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;
using System.ComponentModel;

class ServerSession : PacketSession
{
    Task t;
    public void SetBackgroundWork()
    {
        t = new Task(SendScreen);
        t.Start();
    }
    void SendScreen()
    {
        while (_disconnected != 1)
        {
            ArraySegment<byte> pkt = MakePacket.MakeC_ScreenImage();
            Send(pkt);
            Thread.Sleep(100);
            
        }
    }


    public override void OnConnected(EndPoint endPoint)
    {
        Console.WriteLine($"OnConnected :{endPoint}");
    }

    public override void OnDisconnected(EndPoint endPoint)
    {
        Console.WriteLine($"OnDisconnected :{endPoint}");
    }

    public override void OnRecvPacket(ArraySegment<byte> buffer)
    {
        ClientPacketManager.Instance.OnRecvPacket(this, buffer);
    }

    public override void OnSend(int numOfBytes)
    {

    }
}