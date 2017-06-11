using System;
using Microsoft.Practices.Unity;

namespace UnityIoC
{
    public class Service2
    {
        private IReader _read;
        private IWriter _write;
        //[InjectionMethod]
        public void Read(IReader read)
        {
            _read = read;

            Console.WriteLine("Set reader");
        }

        //[InjectionMethod]
        public void Write(IWriter write)
        {
            _write = write;
            Console.WriteLine("Set writer");
        }

        public void TryRead()
        {
            Console.WriteLine(_read.Read());
        }

        public void TryWrite()
        {
            _write.Write("message from service 2");
        }
    }
}