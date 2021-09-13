using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Conn_Client
{
	class MainClass
	{
		private static TcpClient client;
		private static string IP = "127.0.0.1";
		private static int port = 80;
		public static void Main (string[] args)
		{
			IPEndPoint endPoint = new IPEndPoint (IPAddress.Parse (IP), port);
			client = new TcpClient {
				SendBufferSize = 1024,
				ReceiveBufferSize = 1024
			};
			client.Connect (endPoint);

			Console.WriteLine ("Connecting");

			string msg = Console.ReadLine ();

			byte[] data = Encoding.ASCII.GetBytes (msg);
			NetworkStream stream = client.GetStream ();
			stream.Write (data, 0, data.Length);
			stream.Flush ();
		}
	}
}
