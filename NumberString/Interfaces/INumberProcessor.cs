namespace NumberString.Interfaces
{
    using Model;
    using System;

    public interface INumberProcessor
    {
        /// <summary>
        /// This is called by the environment before any events are processed.
        /// </summary>
        void StartProcessing(object sender, ProcessingStartEventArgs args);

        /// <summary>
        /// This handles a specific input event.
       
        /// </summary>
        void HandleInput(object sender, EventArgs args);

        /// <summary>
        /// This is called by the environment when no more events will be processed.
        /// </summary>
        void FinishProcessing(object sender, EventArgs args);
    }
}
