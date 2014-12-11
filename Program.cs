using System;
using System.Diagnostics;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Common.CommandLine;

namespace HelloK {
    public class Program {
        private readonly IApplicationEnvironment _env;
        public Program(IApplicationEnvironment env) {
            _env = env;
        }

        private string GetUnameValue(string arg) {
            var psi = new ProcessStartInfo("uname", "-" + arg);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            var p = Process.Start(psi);
            var ret = p.StandardOutput.ReadToEnd().Trim();
            p.WaitForExit();
            return ret;
        }

        public int Main(string[] args) {
            // Platform detection
            string platform = Environment.OSVersion.VersionString;
            if(Environment.OSVersion.Platform == PlatformID.Unix) {
                platform = GetUnameValue("sr");
            }

            AnsiConsole.Output.WriteLine("K is good!");
            AnsiConsole.Output.WriteLine("\x1b[30mRuntime Framework:    \x1b[39m " + _env.RuntimeFramework.ToString());
            AnsiConsole.Output.WriteLine("\x1b[30mRuntime Version:      \x1b[39m " + Environment.Version.ToString());
            AnsiConsole.Output.WriteLine("\x1b[30mRuntime Kind:         \x1b[39m " + (Type.GetType("Mono.Runtime") != null ? "Mono" : "Microsoft"));
            AnsiConsole.Output.WriteLine("\x1b[30mOS:                   \x1b[39m " + platform);
            AnsiConsole.Output.WriteLine("\x1b[30mMachine Name:         \x1b[39m " + Environment.MachineName ?? "<null>");
            AnsiConsole.Output.WriteLine("\x1b[30mUser Name:            \x1b[39m " + Environment.UserName ?? "<null>");
            AnsiConsole.Output.WriteLine("\x1b[30mSystem Directory:     \x1b[39m " + Environment.SystemDirectory ?? "<null>");
            AnsiConsole.Output.WriteLine("\x1b[30mCurrent Directory:    \x1b[39m " + Environment.CurrentDirectory ?? "<null>");
            AnsiConsole.Output.WriteLine();
            AnsiConsole.Output.WriteLine(
                "\x1b[1m" +
                "\x1b[30mA" + 
                "\x1b[31mN" + 
                "\x1b[32mS" +
                "\x1b[33mI" + " " +
                "\x1b[34mR" +
                "\x1b[35ma" +
                "\x1b[36mi" +
                "\x1b[37mn" +
                "\x1b[38mb" +
                "\x1b[22m" +
                "\x1b[30mo" +
                "\x1b[32mw" +
                "\x1b[33m!" +
                "\x1b[34m!" +
                "\x1b[35m!" +
                "\x1b[36m!" +
                "\x1b[37m!" +
                "\x1b[38m!" +
                "\x1b[39m");

            return 0;
        }
    }
}