using System;

namespace UnityIoC
{
    public class ServiceWriter : IWriter
    {
        public void Write(string something)
        {
            Console.WriteLine(something + " Service writer");
        }
    }
}