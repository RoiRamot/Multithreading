using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ProjectBuilder();
            builder.SequenceBuilder();
            Console.ReadLine();
        }
    }
}
