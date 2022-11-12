using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vsprojclear
{
    internal class Program
    {
        static string pattern_regex = @"(\.xml)|(\.pdb)|(\.lib)|(\.config)|(\.exp)".ToLower();

        static void Main(string[] args)
        {


            while (true)
            {
                if (args.Length < 2)
                {
                    args = Console.ReadLine().Split(' ');
                    continue;
                }
                break;
            }
           
                 


            if (args[0].ToUpper() == "-C" && Directory.Exists(args[1]))
            {
                ClearFiles(args[1]);
                foreach (string dir in Directory.GetDirectories(args[1]))
                {
                    ClearFiles(dir);
                }
            }

            if(args.Length == 3)
            {
                if (args[2].ToUpper() == "-S")
                {
                    Console.ReadLine();
                }
                 
            }

           
        }
        static void ClearFiles( string directory )
        {
            if (!Directory.Exists(directory))
                return;
            FileInfo fileInfo;
            foreach (var item in Directory.GetFiles(directory))
            {
                fileInfo = new FileInfo(item);
                if (Regex.IsMatch(fileInfo.Extension.ToLower(), pattern_regex))
                {
                    File.Delete(item);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(fileInfo.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
