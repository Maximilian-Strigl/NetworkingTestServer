﻿

using System.Net.Sockets;
using System.Text;

TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
listener.Start();

while(true)
{
    Console.WriteLine("Waiting for a connection");
    TcpClient client = listener.AcceptTcpClient();
    Console.WriteLine("Client Accepted");
    NetworkStream stream = client.GetStream();
    StreamReader sr = new StreamReader(stream);
    StreamWriter sw = new StreamWriter(stream);

    try
    {
        byte[] buffer = new byte[1024];
        stream.Read(buffer, 0, buffer.Length);
        int recv = 0;

        foreach(byte b in buffer)
        {
            if(b >= 0)
            { recv++; }
        }

        string request = Encoding.UTF8.GetString(buffer, 0, recv);
        Console.WriteLine("request received");
        sw.WriteLine("youRock");
        sw.Flush();
    }
    catch(Exception e)
    {
        Console.WriteLine("something went wrong");
        Console.WriteLine(e.ToString());
    }
}

