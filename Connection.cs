using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text;

namespace git_lab3_1
{
    public class Connection{
        public bool active = false;
        IPAddress IP_com;
        string active_comp;
        public Connection(string str_ip){
            IP_com = IPAddress.Parse(str_ip);
            Check_IP();
        }

        void Check_IP(){
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(IP_com);
            if(pingReply.Status == IPStatus.Success)
                active = true;
        }

        public string get_IP(){
            active_comp = IP_com.ToString();
            return active_comp;
        }

        public void get_Information(){
            Ping ping = new Ping();
            PingOptions options = new PingOptions ();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = ping.Send (IP_com, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("\nAddressFamily: " + IP_com.AddressFamily.ToString());
                if(IP_com.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                    Console.WriteLine("Scope Id: " + IP_com.ScopeId.ToString());
                Console.WriteLine ("Address: {0}", reply.Address.ToString ());
                Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
            }
        }
    }
}