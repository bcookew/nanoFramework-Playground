using nanoFrameworkDemo.Abstractions;
using System;
using System.Device.Gpio;

namespace nanoFrameworkDemo.Services
{
    internal class HardwareService : IHardwareService, IDisposable
    {
        public GpioController GpioController { get; init; }

        HardwareService()
        {
            GpioController = new GpioController();
        } 

        public void Dispose()
        {
            GpioController.Dispose();
        }
    }
}
