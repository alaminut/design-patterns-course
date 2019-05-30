using System;
using System.Collections.Generic;
using System.Dynamic;
using ImpromptuInterface;
using static System.Console;

namespace Proxy.DynamicProxy
{
    public class LogProxy<T> : DynamicObject where T : class
    {
        private readonly T _subject;
        private readonly Dictionary<string, int> _methodCallCount = new Dictionary<string, int>();
        
        public LogProxy(T subject)
        {
            _subject = subject;
        }

        public static I As<I>(params object[] ctorArgs) where I : class
        {
            if(!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface type");

            return new LogProxy<T>((T)Activator.CreateInstance(typeof(T), ctorArgs)).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                WriteLine($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments: {string.Join(",", args)}");
                if (_methodCallCount.ContainsKey(binder.Name))
                {
                    _methodCallCount[binder.Name]++;
                }
                else
                {
                    _methodCallCount.Add(binder.Name, 1);
                }

                result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
