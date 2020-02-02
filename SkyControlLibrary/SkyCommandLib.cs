using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkyControlLibrary
{
    public static class SkyCommandLib
    {
        public static bool IsSkyBoxOn(string ip)
        {
            WebRequest httpWebRequest = WebRequest.Create($"http://{ip}:9006/as/system/information");
            using (WebResponse httpWebResponse = httpWebRequest.GetResponse())
            using (Stream dataStream = httpWebResponse.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                string responseFromServer = reader.ReadToEnd();
                SkyJsonResponse jsonResponse = JsonConvert.DeserializeObject<SkyJsonResponse>(responseFromServer);
                return !jsonResponse.ActiveStandby;
            }
        }

        public static bool GoBack(string ip)
        {
            try
            {
                SkyRemote remote = new SkyRemote(ip, SkyRemote.SKY_Q);

                remote.Press(SkyCommands.Backup);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Dismiss(string ip)
        {
            try
            {
                SkyRemote remote = new SkyRemote(ip, SkyRemote.SKY_Q);

                remote.Press(SkyCommands.Dismiss);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TurnOn(string ip)
        {
            try
            {
                if (IsSkyBoxOn(ip))
                {
                    return true;
                }

                SkyRemote remote = new SkyRemote(ip, SkyRemote.SKY_Q);

                remote.Press(SkyCommands.Power);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TurnOff(string ip)
        {
            try
            {
                if (!IsSkyBoxOn(ip))
                {
                    return true;
                }

                SkyRemote remote = new SkyRemote(ip, SkyRemote.SKY_Q);

                remote.Press(SkyCommands.Power);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool GoToChannel(string ip, SkyCommands n1, SkyCommands n2, SkyCommands n3)
        {
            try
            {
                SkyRemote remote = new SkyRemote(ip, SkyRemote.SKY_Q);

                remote.Press(n1);
                Thread.Sleep(50);
                remote.Press(n2);
                Thread.Sleep(50);
                remote.Press(n3);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
