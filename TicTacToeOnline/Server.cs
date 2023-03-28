using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace TicTacToeOnline
{

    public sealed class Server
    {
        private static TcpListener server = null;
        private static TcpClient client = null;
        private static Int32 _port = 13001;
        private static string CLOSE_TEXT_INFORMATION = "Close connection";
        private static Byte[] bytes = new Byte[256];

        private Server()
        { }

        public static void StartServer(out string ip, out string port, out bool hasServerStarted)
        {
            
            try
            {
                ip = GetLocalIPv4(NetworkInterfaceType.Ethernet);
                port = _port.ToString();
                server = new TcpListener(IPAddress.Parse(ip), _port);
                server.Start();
                hasServerStarted = true;
                client = server.AcceptTcpClient();
                
            } 
            catch (Exception)
            {
                server?.Stop();
                hasServerStarted = false;
                ip = null;
                port = null;
            }
        }

        public static void Listen()
        {
            
        }

        public static void CloseServer()
        {
            server?.Stop();
        }

        private static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
