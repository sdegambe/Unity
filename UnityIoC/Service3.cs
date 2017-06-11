using System;
using Microsoft.Practices.Unity;

namespace UnityIoC
{
    public class Service3
    {
        //[Dependency]
        public IWriter Writer { get; set; }
        //[Dependency]
        public IReader Reader { get; set; }

        public void Read()
        {
            Console.WriteLine(Reader.Read());
        }

        public void Write()
        {
            Writer.Write("message from service 3");
        }
    }
}