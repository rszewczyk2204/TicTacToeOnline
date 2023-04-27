using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TicTacToeOnline
{
    public sealed class Server
    {
        private static TcpListener server = null;
        private static Int32 _port = 13001;
        private static string CLOSE_TEXT_INFORMATION = "Close connection";

        private Server()
        { }

        public static void StartServer(ref string ipAddress, ref string port, out bool hasServerStarted)
        {
            ipAddress = GetLocalIPv4(NetworkInterfaceType.Ethernet);
            port = _port.ToString();
            try
            {
                server = new TcpListener(IPAddress.Parse(ipAddress), _port);
                server.Start();

                hasServerStarted = true;

            } catch (Exception ex)
            {
                var excMessage = ex.Message;
                server.Stop();
                hasServerStarted = false;
            }
        }

        public static void CloseServer()
        {
            server?.Stop();
        }

        private static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = String.Empty;
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
