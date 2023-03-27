using System;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeOnline
{
    public sealed class Client
    {
        private static TcpClient _tcpClient = null;

        private Client()
        { }

        public static void JoinGame(string ip, string port)
        {
            _tcpClient = new TcpClient(ip, Int32.Parse(port));
        }

        public static void SendMessage(string message)
        {
            Byte[] data = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = _tcpClient.GetStream();

            stream.Write(data, 0, data.Length);
        }

        public static void LeaveGame()
        {
            _tcpClient?.Close();
        }
    }
}
