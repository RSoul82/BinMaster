using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace BinMaster
{
    class RunCommand
    {
        /// <summary>
        /// Starts the command prompt in the background and runs the supplied command
        /// </summary>
        /// <param name="SingleCommand">The command to be executed.</param>
        public static void Execute(string SingleCommand)
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", @"/C " + "\"" + SingleCommand + "\"");

            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;

            p.StartInfo = psi;
            p.Start();

            p.WaitForExit();
            p.Close();
        }

        public static void ExecuteMultiple(List<string> listOfCommands)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;

            p.Start();

            StreamWriter sW = p.StandardInput;
            foreach(string s in listOfCommands)
            {
                sW.WriteLine(s);
            }

            sW.Close();

            p.WaitForExit();
            p.Close();
        }
    }
}
