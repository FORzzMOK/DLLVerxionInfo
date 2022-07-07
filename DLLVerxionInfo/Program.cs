using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DLLVerxionInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var fileVersionInfoType = typeof(FileVersionInfo);
            var properties = fileVersionInfoType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            foreach (var file in directoryInfo.GetFiles())
            {
                if (Path.GetExtension(file.FullName) == ".dll" || Path.GetExtension(file.FullName) == ".exe")
                {
                    foreach (var property in properties)
                    {
                        var fileVersionInfo = FileVersionInfo.GetVersionInfo(file.Name);
                        var name = fileVersionInfoType.GetProperty(property.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                        var value = name?.GetValue(fileVersionInfo);
                        Console.WriteLine($"{name.Name}={value}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any button to close...");
            Console.ReadKey();
        }
    }
}
