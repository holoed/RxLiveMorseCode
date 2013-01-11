using System;
using System.Reactive.Linq;

namespace MorseCodeInterpreter
{
    public static class MorseCodeInterpreter
    {
        public static IObservable<IObservable<string>> TranslateMorseCode(this IObservable<Char> source)
        {
            return source
                .SplitBy(' ')
                .Select(xs => xs.Scan(MorseCodeBuilder.Build(), ProcessChar).Select(x => x.Value));
        }

        private static IMorseCodeNode ProcessChar(IMorseCodeNode acc, char ch)
        {
            return ch == '.' ? acc.Dot : 
                   ch == '-' ? acc.Dash : 
                   new NullMorseCodeLeaf();
        }

        public static IObservable<IObservable<T>> SplitBy<T>(this IObservable<T> source, T separator)
        {
            return source.Window(() => source.Where(x => Equals(x , separator))).Select(ys => ys.Where(y => !Equals(y,  separator)));
        }
    }
}
