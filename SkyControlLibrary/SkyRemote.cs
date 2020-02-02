using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyControlLibrary
{
    public class SkyRemote
    {
        public string Host
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public int ConnectTimeout
        {
            get;
            set;
        } = 1000;

        public SkyRemote(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public void SendCommand(SkyCommands code)
        {
            var commandBytes = new byte[] { 4, 1, 0, 0, 0, 0, (byte)Math.Floor(224 + ((int)code / 16d)), (byte)((int)code % 16)};
            var commandBytes2 = new byte[] { 4, 0, 0, 0, 0, 0, (byte)Math.Floor(224 + ((int)code / 16d)), (byte)((int)code % 16) };

            TcpClient client = new TcpClient(Host, Port);
            NetworkStream ns = client.GetStream();
            
            ns.WriteTimeout = 1000;
            ns.ReadTimeout = 1000;
            try
            {
                byte[] handShake = new byte[24];
                ns.Read(handShake, 0, 12);
                ns.Write(handShake, 0, 12);
                ns.Read(handShake, 0, 2);
                ns.Write(handShake, 0, 1);
                ns.Read(handShake, 0, 4);
                ns.Write(handShake, 0, 1);
                ns.Read(handShake, 0, 24);

                ns.Write(commandBytes, 0, commandBytes.Length);
                ns.Write(commandBytes2, 0, commandBytes2.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            ns.Dispose();
            client.Close();
        }

        public void Press(SkyCommands button)
        {
            SendCommand(button);
        }

        public const int SKY_Q_LEGACY = 5900;
        public const int SKY_Q = 49160;
    }

    public enum SkyCommands
    {
        Power = 0,
        Select = 1,
        Backup = 2,
        Dismiss = 2,
        Channelup = 6,
        Channeldown = 7,
        Interactive = 8,
        Sidebar = 8,
        Help = 9,
        Services = 10,
        Search = 10,
        Tvguide = 11,
        Home = 11,
        I = 14,
        Text = 15,
        Up = 16,
        Down = 17,
        Left = 18,
        Right = 19,
        Red = 32,
        Green = 33,
        Yellow = 34,
        Blue = 35,
        Keypad0 = 48,
        Keypad1 = 49,
        Keypad2 = 50,
        Keypad3 = 51,
        Keypad4 = 52,
        Keypad5 = 53,
        Keypad6 = 54,
        Keypad7 = 55,
        Keypad8 = 56,
        Keypad9 = 57,
        Play = 64,
        Pause = 65,
        Stop = 66,
        Record = 67,
        Fastforward = 69,
        Rewind = 71,
        Boxoffice = 240,
        Sky = 241
    }
}
