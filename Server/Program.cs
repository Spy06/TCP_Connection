using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Conn_Server
{
	class MainClass
	{
		private static TcpListener tcpListener;

		public static void Main (string[] args)
		{
			tcpListener = new TcpListener (IPAddress.Any, 80);
			tcpListener.Start ();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine ("Server Started, Listening...");

			TcpClient client = tcpListener.AcceptTcpClient ();
			Console.WriteLine ("Incoming connection");

			NetworkStream stream = client.GetStream ();
			byte[] buffer = new byte[1024];
			int data = stream.Read (buffer, 0, buffer.Length);
			byte[] message = new byte[data];
			Array.Copy (buffer, message, data);
			string msg = Encoding.ASCII.GetString (message);
			Console.WriteLine (msg);
		}
	}
}
