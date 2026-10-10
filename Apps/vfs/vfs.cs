using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOS.Apps.vfs
{
    internal class vfs
    {
        public static string[] disk = { "SYSTEM.INI", null, null, null, null, null, null };

        public static void dir() {
            for (int i = 0; i < disk.Length; i++)
            {
                if (disk[i] != null)
                {
                    Console.WriteLine(disk[i]);
                }
            }
        }

        public static void mkfile()
        {
            string inp2 = null;
            Console.WriteLine("enter filename");
            Console.Write(">");
            var inp = Console.ReadLine();
            for (int e = 0; e < disk.Length; e++)
            {
                inp2 = disk[e];

                if (disk[e] != null && inp2 == inp)
                {
                    Console.WriteLine("A file with this name already exists.");
                    return;
                }

                if (inp2 == null)
                {
                    disk[e] = inp;
                    break;
                }
            }
        }

        public static void rmfile()
        {
            Console.WriteLine("enter filename");
            Console.Write(">");
            var delfile = Console.ReadLine();

            for (int f = 0; f < disk.Length; f++)
            {
                if (delfile == disk[0])
                {
                    Console.WriteLine("This is a system file; it cannot be deleted.");
                    return;
                }

                if (disk[f] != null && disk[f] == delfile)
                {
                    disk[f] = null;
                    return;
                }

                if (f == disk.Length - 1)
                {
                    Console.WriteLine("file not found");
                }
            }
        }

    }
}
