

namespace NumberString
{
    using Interfaces;
    using Model;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Converter for Number to string - Single responsibility.
    /// Dependency inversion principle
    /// </summary>
    public class Convertor
    {
        private readonly ILog _log;
        public InputObject InputString { get; private set; }
        private string _result=string.Empty;
        private readonly Dictionary<long, string>  OneTo19 = new Dictionary<long, string>() {
                { 0,"zero" },{  1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
                { 6, "six" },{ 7, "seven" },{8, "eight" },{ 9, "nine" },{ 10, "ten" },{ 11, "eleven" },
                { 12, "twelve" },{ 13, "thirteen" },{ 14, "fourteen" },{ 15, "fifteen" },{ 16, "sixteen" },
                { 17, "seventeen" },{ 18, "eighteen" },{ 19, "nineteen" }
            };
        /// <summary>
        /// Tenner
        /// </summary>
        private readonly Dictionary<long, string> Ten290 = new Dictionary<long, string>() {
                { 1, "ten" }, { 2, "twenty" }, { 3, "thirty" }, {4, "fourty" }, {5, "fifty" },
                { 6, "sixty" },{ 7, "seventy" },{ 8, "eighty" },{ 9, "ninty" }
            };
        /// <summary>
        /// Future Use
        /// </summary>
        private readonly Dictionary<long, string>  Beyond100 = new Dictionary<long, string>()
            {
                { 3, "hundred" }, { 4, "thousand" }, { 5, "million" }, { 8, "billion" }, { 11, "trillion" },
                { 14, "quadrillion" },{ 17, "quintillion" },{ 20, "sextillion" },{ 23, "septillion" },{ 26, "octillion" }
            };
        public Convertor(ILog log,InputObject input)
        {
            _log = log;
            InputString = input;
        }
        /// <summary>
        /// Conversion Process
        /// </summary>
        /// <returns>Converted string</returns>
        public string Process()
        {
            if (InputString.InputNumber.HasValue)
            {
                _result = StringRepresentation(InputString.InputNumber.Value);
                return _result;
            }
            else
            {
                throw new ApplicationException(Constants.ERR_INVALID_INPUT);
            }
        }
        /// <summary>
        /// String representation of
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string StringRepresentation(long n)
        {
            var result= n == 0 ? OneTo19[n] : GetShortString(n).Trim().TrimEnd(',');
            if (n >= 100)
            {
                //add and at end if missing
                var lastIndex = result.LastIndexOf(' ');
                var splitword = result.Substring(0, lastIndex);
                if (splitword != splitword.TrimEnd(','))
                {
                    string finalResult = $"{splitword.TrimEnd(',')} and{result.Replace(splitword, "")}";
                    return finalResult;
                }
            }
            return result;
        }
        /// <summary>
        /// Recurrsive travers - Beware of Stack Overflow Exception
        /// </summary>
        /// <param name="n">long</param>
        /// <returns>string representation</returns>
        private  string GetShortString(long n)
        {
            return 
                   n == 0 ? "" :
                   n <= 19 ? OneTo19[n] :
                   n <= 99 ? Ten290[n / 10] + "-" + GetShortString(n % 10) :
                   n <= 199 ? "one hundred and " + GetShortString(n % 100) :
                   n <= 999 ? GetShortString(n / 100) + " hundred and" + GetShortString(n % 100) :
                   n <= 1999 ? "one thousand " + GetShortString(n % 1000) :
                   n <= 999999 ? GetShortString(n / 1000) + " thousand, " + GetShortString(n % 1000) :
                   n <= 1999999 ? "one million " + GetShortString(n % 1000000) :
                   n <= 999999999 ? GetShortString(n / 1000000) + " million, " + GetShortString(n % 1000000) :
                   n <= 1999999999 ? "one billion " + GetShortString(n % 1000000000) :
                                      GetShortString(n / 1000000000) + " billion, " + GetShortString(n % 1000000000);
        }
        /// <summary>
        /// Log Output
        /// </summary>
        internal void LogOutput()
        {
            _log.Log($"Result:{_result}");
        }

    }
}
