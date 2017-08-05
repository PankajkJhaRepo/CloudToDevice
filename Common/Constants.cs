using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static  class Constants
    {
        public static  readonly string  connectionString = "";
        public static readonly string iotHubD2cEndpoint = "messages/events";
        public static readonly string iotHubUri = "";

        public static readonly string EventHubSendPolicyConnectionString = "";
        public static readonly string EventHubName = "callreceivereventhub";
        public struct device
        {
            public device(string name,string key)
            {
                Name = name;
                Key = key;
            }
           public string Name ;
           public string Key ;

        }
        public static device device1 = new device("myFirstDevice", "xxxxxxxx");
        public static device device2 = new device("mySecondDevice", "xxxxxxx");
        
    }
}
