namespace nanoFrameworkDemo.Abstractions
{
    internal interface IWifiService
    {
        bool IsConnected { get; }
        void ChangeNetwork(string ssid, string password);
    }
}
