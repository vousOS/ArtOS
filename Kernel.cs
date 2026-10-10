using System;
using Sys = Cosmos.Kernel.System;
using ArtOS.Apps.calc;
using ArtOS.Apps.setcolor;
using ArtOS.Apps.vfs;


namespace ArtOS;

/// <summary>
/// Main kernel class - inherits from Cosmos.Kernel.System.Kernel.
/// </summary>
public class Kernel : Sys.Kernel
{
    public static ConsoleColor CurrentColor = ConsoleColor.White;
    protected override void BeforeRun()
    {
        Console.Clear();
        Console.Beep();
        Console.Write("\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ArtOS");
        Console.ResetColor();
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("type help to show commands");
    }

     protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ROOT>");
            Console.ForegroundColor = CurrentColor;
            var OS = Console.ReadLine();
            
            switch (OS.ToLower())
            {
                case "help":
                    Console.WriteLine("clear    - clear screen");
                    Console.WriteLine("calc     - open calculator");
                    Console.WriteLine("info     - system info");
                    Console.WriteLine("time     - show real time");
                    Console.WriteLine("reboot   - reboot system");
                    Console.WriteLine("poweroff - shutdown system");
                    Console.WriteLine("setcolor - set text color");
                    Console.WriteLine("dir      - reboot system");
                    Console.WriteLine("mkfile   - shutdown system");
                    Console.WriteLine("rmfile   - set text color");
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "calc":
                    var calc = new calculator();
                    calc.Run();
                    break;
                case "setcolor":
                    SetColor.Run();
                    break;
                case "dir":
                    vfs.dir();
                    break;
                case "mkfile":
                    vfs.mkfile();
                    break;
                case "rmfile":
                    vfs.rmfile();
                    break;
                case "info":
                    Console.WriteLine("ArtOS x86_x64 1.2");
                    break;
                case "time":
                    Console.WriteLine(DateTime.Now.ToString());
                    break;
                case "reboot":
                    Sys.Power.Reboot();
                    break;
                case "poweroff":
                    Sys.Power.Shutdown();
                    break;
                default:
                    Console.WriteLine("command not found");
                    break;
            }
        }
}
