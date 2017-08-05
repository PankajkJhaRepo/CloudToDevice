using Common;
using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    class Program
    {
        static DeviceClient deviceClient;
        static void Main(string[] args)
        {
            Console.WriteLine("Simulated device\n");
            // deviceClient = DeviceClient.CreateFromConnectionString(Constants.connectionString, "myFirstDevice",TransportType.Mqtt);
            deviceClient = DeviceClient.CreateFromConnectionString(Constants.connectionString, "myFirstDevice");
            ReceiveC2dAsync();

         //   string connectionString = "HostName=IOTHUBKDIDemo1.azure-devices.net;DeviceId=myFirstDevice;SharedAccessKey=y4Pmw9wRqQpHnrmfgbWkTHq7xfSXIPhElww9eCm1SbA=";
        //    deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        //   ReceiveC2dAsync();
          
            //runCommandLoopReceiver();
        }
        private static  void ReceiveC2dAsync()
        {
            Console.WriteLine("\nReceiving cloud to device messages from service");
            while (true)
            {
                Message receivedMessage =  deviceClient.ReceiveAsync().Result ;
                if (receivedMessage == null) continue;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Received message: {0}", Encoding.ASCII.GetString(receivedMessage.GetBytes()));
                Console.ResetColor();

                deviceClient.CompleteAsync(receivedMessage).Wait() ;
            }
        }

        private static void runCommandLoopReceiver()
        {
            {
                // Goto DeviceExplorer and copy copy 
                // Shared Access Policy for your device. 
                string connectionString = "HostName=IOTHUBKDIDemo1.azure-devices.net;DeviceId=myFirstDevice;SharedAccessKey=y4Pmw9wRqQpHnrmfgbWkTHq7xfSXIPhElww9eCm1SbA=";

                var deviceClient = DeviceClient.CreateFromConnectionString(connectionString);

                while (true)
                {

                    var msg = deviceClient.ReceiveAsync().Result;
                    if (msg != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Received message: {0}", Encoding.ASCII.GetString(msg.GetBytes()));
                        Console.ResetColor();
                    }

                    Task.Delay(1000).Wait();
                }


            }
        }
    }
}
