namespace NumberString.Model
{
    using Interfaces;
    using System.Linq;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Model for input
    /// </summary>
    public class InputObject : IValidator
    {
        
        public string InputString { get; } = string.Empty;
        public long? InputNumber { get; private set; } = null;
        public InputObject(string inputValue)
        {
            InputString = inputValue;
            //Get Number
            IsValid();
        }
        public bool IsValid()
        {
            Regex r = new Regex(Constants.REG_EX_ALFANUMERIC);
            if (r.IsMatch(InputString))
            {
               var rNumber = new Regex(Constants.REG_EX_NUMBER);
                //Check Number present
               var inputArr = InputString.Split(' ').OrderBy(a=>a).Where(a=> rNumber.IsMatch(a));
               if(inputArr.Count()==1 && long.TryParse(inputArr.First(),out long longNumber))
                {
                    InputNumber = longNumber;
                    return true;
                }
            }
            return false;
        }
    }

    
}
