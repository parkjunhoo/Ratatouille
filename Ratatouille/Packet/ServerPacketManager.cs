using ServerCore;
using System;
using System.Collections.Generic;

class ServerPacketManager
{
	#region Singleton
	static ServerPacketManager _instance = new ServerPacketManager();
	public static ServerPacketManager Instance
	{
		get { return _instance; }
	}
    #endregion

    ServerPacketManager()
    {
        Register();
    }

	Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>> _onRecv = new Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>>();
	Dictionary<ushort, Action<PacketSession, IPacket>> _handler = new Dictionary<ushort, Action<PacketSession, IPacket>>();
		
	public void Register()
	{
		_onRecv.Add((ushort)PacketID.C_ConnectReq, MakePacket<C_ConnectReq>);
		_handler.Add((ushort)PacketID.C_ConnectReq, PacketHandler.C_ConnectReqHandler);
		_onRecv.Add((ushort)PacketID.C_ScreenImage, MakePacket<C_ScreenImage>);
		_handler.Add((ushort)PacketID.C_ScreenImage, PacketHandler.C_ScreenImageHandler);

	}

	public void OnRecvPacket(PacketSession session, ArraySegment<byte> buffer)
	{
		int count = 0;

		int size = BitConverter.ToInt32(buffer.Array, buffer.Offset);
		count += 4;
		ushort id = BitConverter.ToUInt16(buffer.Array, buffer.Offset + count);
		count += 2;

		Action<PacketSession, ArraySegment<byte>> action = null;
		if (_onRecv.TryGetValue(id, out action))
			action.Invoke(session, buffer);
	}

	void MakePacket<T>(PacketSession session, ArraySegment<byte> buffer) where T : IPacket, new()
	{
		T pkt = new T();
		pkt.Read(buffer);
		Action<PacketSession, IPacket> action = null;
		if (_handler.TryGetValue(pkt.Protocol, out action))
			action.Invoke(session, pkt);
	}
}