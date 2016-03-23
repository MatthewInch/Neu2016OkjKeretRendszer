using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérem a szöveget: ");
            var s = Console.ReadLine();

            MyServiceRef.MessageServiceClient client = new MyServiceRef.MessageServiceClient();
            Console.WriteLine(client.GetMessage(s));
        }
    }
}
