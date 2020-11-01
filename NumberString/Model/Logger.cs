using NumberString.Interfaces;
using System;

namespace NumberString.Model
{
    /// <summary>
    /// Simple logger demonstrated for Dependency Injection.
    /// </summary>
    public class Logger : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
