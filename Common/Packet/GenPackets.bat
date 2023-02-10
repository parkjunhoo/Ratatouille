START ../../PacketGenerator/bin/Debug/PacketGenerator.exe ../../PacketGenerator/PDL.xml
XCOPY /Y GenPackets.cs "../../Ratatouille/Packet" 
XCOPY /Y ClientPacketManager.cs "../../Ratatouille/Packet" 
XCOPY /Y ServerPacketManager.cs "../../Ratatouille/Packet" 
XCOPY /Y ListenPacketManager.cs "../../Ratatouille/Packet" 