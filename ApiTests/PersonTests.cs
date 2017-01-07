using System;
using FluentApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [TestClass]
    public class PersonTests
    {
        private string GetStatus(string status)
        {
            Console.WriteLine(status);
            return status;
        }

        [TestMethod]
        public void UsePropertyName()
        {
            Person person = new Person();

            person.Name = "Klaus";

            Assert.AreEqual("Klaus", person.Name);
        }

        [TestMethod]
        public void UserPropertyBirth()
        {
            Person person = new Person();
            var birthDate = new DateTime(1967, 3, 8);

            person.Birth = birthDate;

            Assert.AreEqual(birthDate, person.Birth);
        }

        [TestMethod]
        public void UseFluentIsBorn()
        {
            var birthDate = new DateTime(1967, 3, 8);
            string status = String.Empty;

            Person.GetsBorn("Klaus", new DateTime(1967, 3, 8)).DisplayState(s => status = GetStatus(s));

            Assert.IsTrue(status.Contains("Klaus"));
            Assert.IsTrue(status.Contains("single"));
        }

        [TestMethod]
        public void UseFluentTillDeath()
        {
            var birthDate = new DateTime(1967, 3, 8);
            string status = String.Empty;

            Person.GetsBorn("Julius Caesar", birthDate).Dies(new DateTime(2035, 3, 3)).DisplayWholeLife(s => status = GetStatus(s)); 

            Assert.IsTrue(status.Contains("1967"));
            Assert.IsTrue(status.Contains("Julius"));
        }

        [TestMethod]
        public void UseFluentInCoolLife()
        {
            var birthDate = new DateTime(1967, 3, 8);
            string status = String.Empty;

            Person.GetsBorn("Julius Caesar", birthDate).
                GetsMarried("First Wife", new DateTime(1992, 3, 5)).
                GetsDivorced(new DateTime(1993, 2, 3)). 
                GetsMarried("Second Wife", new DateTime(1994, 3, 5)).
                GetsWidowed(new DateTime(1995, 2, 3)). 
                Dies(new DateTime(2035, 3, 3)).DisplayWholeLife(s => status = GetStatus(s)); 

            Assert.IsTrue(status.Contains("1967"));
            Assert.IsTrue(status.Contains("Julius"));
        }

        // doesnt work any more
        //[TestMethod]
        //public void UseFluentIncorrectStates()
        //{
        //    var birthDate = new DateTime(1967, 3, 8);
        //    string status = String.Empty;

        //    var person = Person.GetsBorn("Julius Caesar", birthDate).
        //        GetsMarried("First Wife", new DateTime(1992, 3, 5)).
        //        GetsMarried("Second Wife", new DateTime(1994, 3, 5)).
        //        DisplayWholeLife(s => status = GetStatus(s)); 

        //    Assert.IsTrue(status.Contains("1967"));
        //    Assert.IsTrue(status.Contains("Julius"));
        //}

        [TestMethod]
        public void UseCorrectFluentApiFirstTest()
        {
            var birthDate = new DateTime(1967, 3, 8);
            string status = String.Empty;

            Person.GetsBorn("Julius Caesar", birthDate).
                DisplayWholeLife(s => status = GetStatus(s)); 

            Assert.IsTrue(status.Contains("1967"));
            Assert.IsTrue(status.Contains("Julius"));
        }
    }
}
