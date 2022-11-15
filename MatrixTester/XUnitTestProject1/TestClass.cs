using NUnit.Framework;
using System;

namespace XUnitTestProject1
{
    [TestFixture]
    public class Tests
    {
        TestingClass Class;
        String[] FullName;

        [SetUp]
        public void SetUp()
        {
            Class = new TestingClass();
            FullName = new String[] { "Name1", "Name2", "Name3" };
        }

        [Test]
        public void Test()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(FullName[i], Class.getClientName(FullName[i]));
            }
        }
    }
}
