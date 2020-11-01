using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberString.Tests
{
    using NumberString.Interfaces;
    using NumberString.Model;
    [TestClass()]
    public class ConvertorTests
    {
        ILog log;
        public ConvertorTests()
        {
            log = new Logger();
        }
        [TestMethod()]
        public void ProcessTest_1()
        {           
            var convertor = new Convertor(log, new InputObject("The pump is 536 deep underground."));
            var result = convertor.Process();
            Assert.IsTrue(result == "five hundred and thirty-six");
        }
        [TestMethod()]
        public void ProcessTest_2()
        {

            var convertor = new Convertor(log, new InputObject("We processed 9121 records."));
            var result = convertor.Process();
            Assert.IsTrue(result == "nine thousand, one hundred and twenty-one");
        }
       
        [TestMethod()]
        public void ProcessTest_4()
        {

            var convertor = new Convertor(log, new InputObject("Interactive and printable 10022 ZIP code."));
            var result = convertor.Process();
            Assert.IsTrue(result == "ten thousand and twenty-two");
        }
        [TestMethod()]
        public void ProcessTest_5()
        {

            var convertor = new Convertor(log, new InputObject("The database has 66723107008 records."));
            var result = convertor.Process();
            Assert.IsTrue(result == "sixty-six billion, seven hundred and twenty-three million, one hundred and seven thousand and eight");
        }
        [TestMethod()]
        public void ProcessTest_3()
        {

            var convertor = new Convertor(log, new InputObject("The database has 1000000 records."));
            var result = convertor.Process();
            Assert.IsTrue(result == "one million");
        }
    }
}