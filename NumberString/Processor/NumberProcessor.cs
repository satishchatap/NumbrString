namespace NumberString
{
    using Interfaces;
    using Model;
    using System;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Processing number from string
    /// </summary>
    public class NumberProcessor
    {
        private ILog _log;
        private Convertor convertor;
        public void StartProcessing(object sender, ProcessingStartEventArgs args)
        {
            _log = args.Log;
        }
        /// <summary>
        /// Handle Process action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void HandleProcessAction(object sender, InputEventArgs args)
        {
            switch (args.InputType)
            {
                case InputType.Console:
                    ProcessString(args.InputString);
                    break;
                case InputType.File:
                    var inputString= FileHelper.GetStringFromFile(args.InputString);
                    inputString = Regex.Replace(inputString, @"\t|\n|\r", "");
                    ProcessString(inputString);
                    break;
            }
        }

        /// <summary>
        /// Finish processing Event - Can do addtional things here if needed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void FinishProcessing(object sender, EventArgs args)
        {
            convertor?.LogOutput();
        }
        /// <summary>
        /// Process string value
        /// </summary>
        /// <param name="val"></param>
        private void ProcessString(string val)
        {
            try
            {
                var inputString = new InputObject(val);
                if (inputString.IsValid())
                {
                    convertor = new Convertor(_log, inputString);
                    convertor.Process();
                }
                else
                {
                    throw new ApplicationException(Constants.ERR_INVALID_INPUT);
                }
            }
            catch (ApplicationException aex)
            {
                _log.Log(aex.Message);
            }
            catch
            {
                _log.Log(Constants.APP_ERROR);
            }
        }
    }
}
