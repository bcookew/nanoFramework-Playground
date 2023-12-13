using nanoFramework.Networking;
using System;
using System.Device.Wifi;
using System.Threading;

namespace nanoFrameworkDemo.Services
{
    internal class WifiService
    {
        private string _ssid = "SO070VOIP4E2E";
        private string _password = "E0013E4E2D";
        private IPConfiguration _staticIpConfiguration = new IPConfiguration("192.168.200.162", "255.255.255.0", "192.168.200.254");
        public bool IsConnected { get; private set; }

        public WifiService()
        {
            Connect();
        }

        public void ChangeNetwork(string ssid, string password)
        {
            if (IsConnected)
            {
                Disconnect();
            }
            _ssid = ssid;
            _password = password;
            Connect();
        }

        private void Connect()
        {
            if (IsConnected) return;
            CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(15_000);
            
            IsConnected = WifiNetworkHelper.ConnectDhcp( _ssid, _password, 
                                                        WifiReconnectionKind.Automatic, 
                                                        requiresDateTime: true, 
                                                        token: _cancellationTokenSource.Token);
            
            if (!IsConnected)
            {
                Console.WriteLine($"Can't get a proper IP address and DateTime, error: {WifiNetworkHelper.Status}.");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Console.WriteLine($"Exception: {WifiNetworkHelper.HelperException}");
                }
                return;
            }
            else
            {
                System.Net.NetworkInformation.NetworkInterface inter = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0];
                if (inter.IPv4Address[0] != '0')
                {
                    Console.WriteLine($"Connected to network: {inter.IPv4Address}");
                }
            }
        }

        private void Disconnect()
        {
            if (!IsConnected) return;
            WifiNetworkHelper.Disconnect();
            IsConnected = false;
        }
    }
}
