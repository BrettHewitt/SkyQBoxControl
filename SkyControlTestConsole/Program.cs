using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyControlLibrary;

namespace SkyControlTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string skyBoxIp = "192.160.0.256";
            bool isActive = SkyCommandLib.IsSkyBoxOn(skyBoxIp);

            if (isActive)
            {
                SkyCommandLib.TurnOff(skyBoxIp);
            }
            else
            {
                SkyCommandLib.TurnOn(skyBoxIp);
            }

            Console.WriteLine(isActive);
        }
    }
}
