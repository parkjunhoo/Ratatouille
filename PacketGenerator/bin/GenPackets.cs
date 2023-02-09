using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;

public enum PacketID
{
	C_ConnectReq = 1,
	S_ConnectRes = 2,
	C_ScreenImage = 3,
	S_MouseClick = 4,
	
}

interface IPacket
{
	ushort Protocol { get; }
	void Read(ArraySegment<byte> segment);
	ArraySegment<byte> Write();
}


class C_ConnectReq : IPacket
{
	public string address;

	public ushort Protocol { get { return (ushort)PacketID.C_ConnectReq; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		ushort addressLen = BitConverter.ToUInt16(s.Slice(count, s.Length - count));
		count += sizeof(ushort);
		this.address = Encoding.Unicode.GetString(s.Slice(count, addressLen));
		count += addressLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open();
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.C_ConnectReq);
		count += sizeof(ushort);
		ushort addressLen = (ushort)Encoding.Unicode.GetBytes(this.address, 0, this.address.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), addressLen);
		count += sizeof(ushort);
		count += addressLen;
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class S_ConnectRes : IPacket
{
	public bool condition;

	public ushort Protocol { get { return (ushort)PacketID.S_ConnectRes; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.condition = BitConverter.ToBoolean(s.Slice(count, s.Length - count));
		count += sizeof(bool);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.S_ConnectRes);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.condition);
		count += sizeof(bool);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class C_ScreenImage : IPacket
{
	public byte[] bmp;

	public ushort Protocol { get { return (ushort)PacketID.C_ScreenImage; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		int bmpLen = BitConverter.ToInt32(s.Slice(count, s.Length - count));
		count += sizeof(int);
		this.bmp = s.Slice(count, bmpLen).ToArray();
		count += bmpLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(300000);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.C_ScreenImage);
		count += sizeof(ushort);
		int bmpLen = (int)this.bmp.Length;
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), bmpLen);
		count += sizeof(int);
		foreach(byte b in this.bmp)
		{
			segment.Array[segment.Offset + count] = b;
			count += sizeof(byte);
		}
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class S_MouseClick : IPacket
{
	public float posx;
	public float posy;

	public ushort Protocol { get { return (ushort)PacketID.S_MouseClick; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.posx = BitConverter.ToSingle(s.Slice(count, s.Length - count));
		count += sizeof(float);
		this.posy = BitConverter.ToSingle(s.Slice(count, s.Length - count));
		count += sizeof(float);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.S_MouseClick);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.posx);
		count += sizeof(float);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.posy);
		count += sizeof(float);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

