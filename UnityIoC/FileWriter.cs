using System;

namespace UnityIoC
{
    public class FileWriter : IWriter
    {
        public void Write(string something)
        {
            Console.WriteLine(something + " File writer");
        }
    }

    public interface IWriter
    {
        void Write(string something);
    }
}