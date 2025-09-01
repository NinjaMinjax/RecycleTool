// Code by NinjaMinja

using System;
using Microsoft.VisualBasic.FileIO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: recycle.exe <filename>");
            return;
        }

        string file = args[0];

        bool isNetworkPath = file.StartsWith(@"\\") ||
            (System.IO.Path.IsPathRooted(file) &&
             new System.IO.DriveInfo(file).DriveType == System.IO.DriveType.Network);

        if (!System.IO.File.Exists(file) && !System.IO.Directory.Exists(file))
        {
            Console.WriteLine("File or directory not found: " + file);
            return;
        }

        try
        {
            if (isNetworkPath)
            {
                // Direct delete for network drives (NAS, UNC paths)
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);
                else if (System.IO.Directory.Exists(file))
                    System.IO.Directory.Delete(file, true);

                Console.WriteLine("Deleted from network drive (no recycle bin): " + file);
            }
            else
            {
                // Send to Windows recycle bin for local drives
                FileSystem.DeleteFile(
                    file,
                    UIOption.OnlyErrorDialogs,
                    RecycleOption.SendToRecycleBin
                );

                Console.WriteLine("Sent to recycle bin: " + file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
