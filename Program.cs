using System;
using System.Collections.Generic;

namespace git_lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip_list = "";
            List<Connection> con_ip_list = new List<Connection>();
            try {
                for(int i=0; i<255; i++){
                    ip_list = "10.13.226." + i;
                    Connection con = new Connection(ip_list);
                    if (con.active == true)
                        con_ip_list.Add(con);
                }
                foreach(var curAdd in con_ip_list){
                    curAdd.get_Information();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
