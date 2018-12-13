using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AspectInjector.Broker;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace ConsoleApp
{
    [Aspect(Scope.Global)]
    [Injection(typeof(LogCall))]
    class LogCall : Attribute
    {
        [Advice(Kind.Before)]
        public void LogEnter([Argument(Source.Name)] string name)
        {
            Console.WriteLine($"Calling {name}");   //you can debug it	
        }
        [Advice(Kind.After)]
        public void LogExit([Argument(Source.Name)] string name)
        {
            Console.WriteLine($"Exit {name}");   //you can debug it	
        }

        [Advice(Kind.Around)]
        public object LogRound([Argument(Source.Name)] string name)
        {
            Console.WriteLine($"Around {name}");   //you can debug it	
            return null;
        }


    }

    [Aspect(Scope.Global)]
    [Injection(typeof(Log))]
    class Log : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> method)
        {
            Console.WriteLine($"Executing method {name}");

            var sw = Stopwatch.StartNew();

            var result = method(arguments);

            sw.Stop();

            Console.WriteLine($"Executed method {name} in {sw.ElapsedMilliseconds} ms");

            return result;
        }
    }

    class Program
    {

        [Log]
        public static void Calculate()
        {
            Thread.Sleep(3000);
        }
        [Log]
        public static int Sum(int a, int b)
        {
            //Thread.Sleep(1000);
            return a + b;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //using (var ctx = new NbIoTContext())
            //{
            //    var models = ctx.DeviceModel.Where(x => !x.IsDisable).ToList();
            //}
            //Calculate();
            var rst = Sum(1, 5);
            Console.ReadKey();
        }
    }
}
