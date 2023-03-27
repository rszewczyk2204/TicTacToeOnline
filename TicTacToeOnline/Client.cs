using System;
using System.Net.Sockets;

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

        public static void LeaveGame()
        {
            _tcpClient?.Close();
        }
    }
}
