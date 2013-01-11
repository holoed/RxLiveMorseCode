using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using MorseCodeInterpreter;

namespace MorseCodeClient
{
    class Program
    {

        public static IObservable<char> MorseCodeLiveStream()
        {
            var subject = new Subject<char>();
            Task.Run(() =>
                         {
                             ConsoleKeyInfo info;
                             do
                             {
                                 info = Console.ReadKey();
                                 subject.OnNext(info.KeyChar);
                             } while (info.Key != ConsoleKey.Enter);
                             Console.WriteLine("Done...");
                         });
            return subject.AsObservable().ObserveOn(CurrentThreadScheduler.Instance).SubscribeOn(CurrentThreadScheduler.Instance);
        }



        static void Main(string[] args)
        {
            var xss = MorseCodeLiveStream();
            int index = 0;
            xss.TranslateMorseCode().Subscribe(xs =>
                                                   {
                                                       xs.Subscribe(x =>
                                                                        {
                                                                            var oldpos = Console.CursorLeft;
                                                                            Console.SetCursorPosition(index, 1);
                                                                            Console.Write(x);
                                                                            Console.SetCursorPosition(oldpos, 0);
                                                                        }, () => index++);
                                                   });
            Thread.Sleep(-1);
        }
    }
}
