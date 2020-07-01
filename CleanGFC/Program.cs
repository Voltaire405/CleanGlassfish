using System;
using System.IO;

namespace CleanGFC
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            GlassFish glassFish = new GlassFish(currentDirectory.Parent);
            glassFish.RemoveCache("domain1");
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadLine();
        }
    }
}
