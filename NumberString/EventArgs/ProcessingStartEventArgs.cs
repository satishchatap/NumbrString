namespace NumberString.Model
{
    using Interfaces;
    using System;

    public class ProcessingStartEventArgs : EventArgs
    {
        public ILog Log { get; }

        public ProcessingStartEventArgs(ILog log) => this.Log = log;
    }
}
