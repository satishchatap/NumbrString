using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberString.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberString.Model.Tests
{
    [TestClass()]
    public class InputObjectTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            var obj = new InputObject("I received 23 456,9 KGs. ");
            Assert.IsFalse(obj.IsValid());
            var obj1 = new InputObject("Variables reported as having a missing type #65678.");
            Assert.IsFalse(obj1.IsValid());
            var obj2 = new InputObject("Interactive and printable 10022 ZIP code.");
            Assert.IsTrue(obj2.IsValid());
            var obj3 = new InputObject("The database has 66723107008 records.");
            Assert.IsTrue(obj3.IsValid());
        }
    }
}