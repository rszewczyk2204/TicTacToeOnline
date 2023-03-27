using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TicTacToeOnline
{
    public sealed class Server
    {
        private static TcpListener server = null;
        private static Int32 _port = 13000;
        private static string CLOSE_TEXT_INFORMATION = "Close connection";

        private Server()
        { }

        public static void StartServer(ref string ipAddress, ref string port, out bool hasServerStarted)
        {
            ipAddress = (EstablishIpAddress().Result ?? IPAddress.Loopback).ToString();
            port = _port.ToString();
            try
            {
                server = new TcpListener(IPAddress.Parse(ipAddress), _port);
                server.Start();

                hasServerStarted = true;
            } catch (Exception)
            {
                server.Stop();
                hasServerStarted = false;
            }
        }

        public static void CloseServer()
        {
            server?.Stop();
        }

        private static async Task<IPAddress> EstablishIpAddress()
        {
            var externalIpString = (await new HttpClient().GetStringAsync("http://icanhazip.com")).Replace("\\r\\n", "").Replace("\\n", "").Trim();
            if (!IPAddress.TryParse(externalIpString, out var ipAddress)) return null;
            return ipAddress;
        }
    }
}
