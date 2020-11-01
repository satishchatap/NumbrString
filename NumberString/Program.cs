namespace NumberString
{
    class Program
    {

        static void Main(string[] args)
        {
            var environment = new AppEnvironment();
            var numberProcessor = new NumberProcessor();

            environment.ProcessingStartEvent += numberProcessor.StartProcessing;
            environment.ProcessingFinishEvent += numberProcessor.FinishProcessing;
            environment.InputActionEvent += numberProcessor.HandleProcessAction;

            environment.Run();           

        }
    }
}
