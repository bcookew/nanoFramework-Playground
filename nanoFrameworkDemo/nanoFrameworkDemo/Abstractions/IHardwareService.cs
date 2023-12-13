using System.Device.Gpio;

namespace nanoFrameworkDemo.Abstractions
{
    internal interface IHardwareService
    {
        GpioController GpioController { get;} 
    }
}
