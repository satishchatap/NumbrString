using System.Linq;

namespace NumberString
{
    using Interfaces;
    using Model;
    using System;
    /// <summary>
    /// Environment setup. Demonstrate event based programming. Environment setup stages - Start/Action/End
    /// Architecture Pattern -OPEN-CLOSE, Liskov Substitution.
    /// </summary>
    public class AppEnvironment : IAppEnvironment
    {
        public event EventHandler<InputEventArgs> InputActionEvent;
        public event EventHandler<ProcessingStartEventArgs> ProcessingStartEvent;
        public event EventHandler ProcessingFinishEvent;

        private readonly ILog log = new Logger();

        public void Run()
        {
            OnProcessingStart(new ProcessingStartEventArgs(log));
            OnProcessing();
            OnProcessingFinish();
        }
        /// <summary>
        /// Architecture Patterns- SOLID
        /// </summary>
        private void OnProcessing()
        {
            Console.WriteLine("Number String by Satish Chatap"); 
            Console.WriteLine($"Note: Sorry. This is to demonstrate the architecture. {Environment.NewLine} While this can be achieved by making Helper Class or implementing delegate TOutput Converter<in TInput, out TOutput>(TInput input).");
            Console.WriteLine($"TODO: Code coveerage.");
            Console.WriteLine("Select Input Type F-File or I-String else E-Exit:");

            var type = Console.ReadKey();
            while(!"FfIiEe".Contains(type.KeyChar)){
                Console.WriteLine("Invalid input type");
                type = Console.ReadKey();
            }
          
            if (type.KeyChar == 'e' || type.KeyChar == 'E')
                return;

            if (type.KeyChar == 'I' || type.KeyChar == 'i')
            {
                Console.WriteLine($"{Environment.NewLine}String to convert:");
                var sentence = Console.ReadLine();
                OnProcessingInput(new InputEventArgs(InputType.Console,sentence));
              
            }
            if (type.KeyChar == 'F' || type.KeyChar == 'f')
            {
                Console.WriteLine($"{Environment.NewLine}File to convert:");
                var filePath = Console.ReadLine();
                OnProcessingInput(new InputEventArgs(InputType.File, filePath));               
            }

        }

        private void OnProcessingStart(ProcessingStartEventArgs args)
        {
            this.ProcessingStartEvent?.Invoke(this, args);
        }

        private void OnProcessingFinish()
        {
            this.ProcessingFinishEvent?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Press c to continue or other key to exit.");
            var keyPress =Console.ReadKey();
            if(keyPress.KeyChar== 'c' || keyPress.KeyChar == 'C')
            {
                Run();
            }
        }

        private void OnProcessingInput(InputEventArgs args)
        {
            this.InputActionEvent?.Invoke(this, args);
        }


    }

}
