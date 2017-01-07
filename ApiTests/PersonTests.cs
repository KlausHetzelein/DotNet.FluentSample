using System;
using FluentApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [TestClass]
    public class PersonTests
    {
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
    }
}
