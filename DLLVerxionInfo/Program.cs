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
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            foreach (var file in directoryInfo.GetFiles())
            {
                if (Path.GetExtension(file.FullName) == ".dll" || Path.GetExtension(file.FullName) == ".exe")
                {
                    var notepadFileInfo = FileVersionInfo.GetVersionInfo(file.Name);
                    Console.WriteLine(
                        $"{nameof(notepadFileInfo.InternalName)}={notepadFileInfo.InternalName}\n" +
                        $"{nameof(notepadFileInfo.FileVersion)}={notepadFileInfo.FileVersion}\n");
                }
            }
            Console.WriteLine("Press any button to close...");
            Console.ReadKey();
        }
    }
}
