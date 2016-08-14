using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{

    public class CustomAwaiter
    {
        public async void WaitIntMethod(int delay)
        {
            await delay;
            Console.WriteLine("Delay Done");
        }
        public async void WaitProcessMethod(ProcessStartInfo process)
        {
            Console.WriteLine("Process Started");
            var start = Process.Start(process);
            if (start != null) await start;
            Console.WriteLine("Process done");

        }
    }
}
