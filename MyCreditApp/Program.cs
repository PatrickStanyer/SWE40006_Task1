using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MyCreditApp is running.");

            // Show architecture (AnyCPU/x86/x64)
            Console.WriteLine($"Process Architecture: {System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}");

            // Demonstrate working directory impact
            Console.WriteLine($"Current Working Directory: {Directory.GetCurrentDirectory()}");

            // Try reading a config file using a relative path
            string configPath = "config.txt";

            if (File.Exists(configPath))
            {
                string text = File.ReadAllText(configPath);
                Console.WriteLine($"Config file contents: {text}");
            }
            else
            {
                Console.WriteLine("config.txt not found in working directory.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

