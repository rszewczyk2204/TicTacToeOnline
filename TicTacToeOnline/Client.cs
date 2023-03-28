using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeOnline
{
    public sealed class Client
    {
        private static TcpClient _tcpClient = null;

        public static bool IsConnected { private set; get; }

        public static NetworkStream client
        {
            get
            {
                return _tcpClient.GetStream();
            }
        }

        private Client()
        { }

        public static void JoinGame(string ip, string port)
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(IPAddress.Parse(ip), Int32.Parse(port));
                IsConnected = true;
            }
            catch (Exception)
            {
                IsConnected = false;
            }
        }

        public static void LeaveGame()
        {
            _tcpClient?.Close();
        }
    }
}
