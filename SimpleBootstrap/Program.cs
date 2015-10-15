namespace SimpleBootstrap
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Microsoft.CSharp;

    class Program
    {
        private const string configuration = "_Configuration";

        static void Main()
        {
            if (!CompileConfiguration()) return;

            var bootstrapper = LoadBootstrapper();
            var dispatcher = bootstrapper.Initialize();

            dispatcher.Dispatch(new RegisterUser("mwinder", "password123"));
            Console.WriteLine();
            dispatcher.Dispatch(new RegisterUser("jdoe", "password123"));
            Console.WriteLine();
            dispatcher.Dispatch(new RegisterUser("ssmith", "password123"));
            Console.WriteLine();
            dispatcher.Dispatch(new RegisterUser("auser", "password123"));
            Console.WriteLine();

            WaitForExit();
        }

        private static bool CompileConfiguration()
        {
            var compiler = new CSharpCodeProvider();
            var parameters = new CompilerParameters(
                assemblyNames: new[] { "mscorlib.dll", "System.Core.dll", "SimpleBootstrap.exe" },
                outputName: ConfigurationAssembly(),
                includeDebugInformation: true);
            var results = compiler.CompileAssemblyFromFile(parameters, new[] { ConfigurationSource() });
            results.Errors.Cast<CompilerError>().ToList().ForEach(Console.WriteLine);

            return results.Errors.Count == 0;
        }

        private static string ConfigurationSource()
        {
            return configuration + ".cs";
        }

        private static string ConfigurationAssembly()
        {
            return configuration + ".dll";
        }

        private static Bootstrapper LoadBootstrapper()
        {
            var type = Assembly.LoadFrom(ConfigurationAssembly())
                .GetExportedTypes()
                .First(t => typeof(Bootstrapper).IsAssignableFrom(t));

            return (Bootstrapper)Activator.CreateInstance(type);
        }

        private static void WaitForExit()
        {
            var shutdown = new AutoResetEvent(false);
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                shutdown.Set();
            };

            Console.WriteLine("Application has started. Ctrl-C to end");

            shutdown.WaitOne();
        }
    }
}
