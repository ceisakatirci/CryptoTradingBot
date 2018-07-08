using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var processLList = from p in Process.GetProcesses()
                               orderby p.Threads.Count descending, p.ProcessName ascending
                               select new
                               {
                                   p.ProcessName,
                                   ThreadsCount = p.Threads.Count
                               };

            foreach (var process in processLList)
            {
                Console.WriteLine(process.ProcessName + " " + process.ThreadsCount);
            }
        }
    }
}
