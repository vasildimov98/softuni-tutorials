namespace Telecom.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private const string MAKE = "TestMake";
        private const string MODEL = "TestModel";

        private const string NAME = "TestName";
        private const string PHONE = "TestPhone";

        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(MAKE, MODEL);
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual(MAKE, this.phone.Make);
            Assert.AreEqual(MODEL, this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void Test_Make()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, MODEL));
        }

        [Test]
        public void Test_Model()
        {
            Assert.Throws<ArgumentException>(() => new Phone(MAKE, null));
        }

        [Test]
        public void Test_Add_Contact_Exception()
        {
            this.phone.AddContact(NAME, PHONE);
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact(NAME, PHONE));
        }

        [Test]
        public void Test_Add_Contact()
        {
            this.phone.AddContact(NAME, PHONE);
            this.phone.AddContact(NAME + 1, PHONE + 1);

            Assert.AreEqual(2, this.phone.Count);
        }

        [Test]
        public void Test_Call_Exception()
        {
            this.phone.AddContact(NAME, PHONE);
            Assert.Throws<InvalidOperationException>(() => this.phone.Call(NAME + 1));
        }

        [Test]
        public void Test_Call()
        {
            this.phone.AddContact(NAME, PHONE);
            this.phone.AddContact(NAME + 1, PHONE + 1);
            Assert.AreEqual($"Calling {NAME} - {PHONE}...", this.phone.Call(NAME));
        }
    }
}