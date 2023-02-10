using ServerCore;
using System;
using System.Collections.Generic;

class ListenPacketManager
{
	#region Singleton
	static ListenPacketManager _instance = new ListenPacketManager();
	public static ListenPacketManager Instance
	{
		get { return _instance; }
	}
    #endregion

    ListenPacketManager()
    {
        Register();
    }

	Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>> _onRecv = new Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>>();
	Dictionary<ushort, Action<PacketSession, IPacket>> _handler = new Dictionary<ushort, Action<PacketSession, IPacket>>();
		
	public void Register()
	{
		_onRecv.Add((ushort)PacketID.L_ClientReq, MakePacket<L_ClientReq>);
		_handler.Add((ushort)PacketID.L_ClientReq, PacketHandler.L_ClientReqHandler);
		_onRecv.Add((ushort)PacketID.L_ClientRes, MakePacket<L_ClientRes>);
		_handler.Add((ushort)PacketID.L_ClientRes, PacketHandler.L_ClientResHandler);
		_onRecv.Add((ushort)PacketID.L_ServerReq, MakePacket<L_ServerReq>);
		_handler.Add((ushort)PacketID.L_ServerReq, PacketHandler.L_ServerReqHandler);
		_onRecv.Add((ushort)PacketID.L_ServerRes, MakePacket<L_ServerRes>);
		_handler.Add((ushort)PacketID.L_ServerRes, PacketHandler.L_ServerResHandler);

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