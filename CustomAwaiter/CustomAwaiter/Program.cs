using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{

    class Program
    {

        static void Main(string[] args)
        {
            var test = new CustomAwaiter();
            test.WaitIntMethod(1000);
            var info = new ProcessStartInfo("IExplore.exe", "www.google.com");
            test.WaitProcessMethod(info);
            Console.ReadLine();
        }
    }
}
