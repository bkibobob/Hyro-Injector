using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hyro_Injector
{
    class DLLPipe
    {
       


        public static void Inject(string process, string dllpath)
        {
            DLLInject.DllInjectionResult dllInjectionResult = DLLInject.DllInjector.GetInstance.Inject(process,dllpath);
            if (dllInjectionResult == DLLInject.DllInjectionResult.Success)
            {
                return;
            }
            switch (dllInjectionResult)
            {
              
                case DLLInject.DllInjectionResult.DllNotFound:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.errorHappened = true;
                    Console.WriteLine("[" + DateTime.Now.TimeOfDay + "]" + " " + "Error Dll not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                case DLLInject.DllInjectionResult.GameProcessNotFound:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.errorHappened = true;
                    Console.WriteLine("[" + DateTime.Now.TimeOfDay + "]" + " " + "Error Game Process not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                case DLLInject.DllInjectionResult.InjectionFailed:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.errorHappened = true;
                    Console.WriteLine("[" + DateTime.Now.TimeOfDay + "]" + " " + "An Critical Error has occured!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
               
                    
                default:
                    return;
            }
        }


    }
}

