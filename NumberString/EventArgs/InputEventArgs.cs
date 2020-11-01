using System;
using System.IO;

namespace NumberString.Model
{
    public enum InputType
    {
        File,
        Console
    }
    public class InputEventArgs :EventArgs
    {

        public InputType InputType { get; }
        public string InputString { get; }
        public InputEventArgs(InputType inputType,string inputString)
        {
            InputType = inputType;
            InputString = inputString;
        }

    }
}
