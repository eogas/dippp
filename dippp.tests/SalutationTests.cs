using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dippp.tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SalutationTests
    {
        [TestMethod]
        public void TestWriter()
        {
            IMessageWriter writer = new ConsoleMessageWriter();
            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }

        [TestMethod]
        public void TestSecureWriter()
        {
            IMessageWriter writer = new ConsoleMessageWriter();
            IMessageWriter secureWriter = new SecureMessageWriter(writer, new GenericIdentity("asdf"));
            var secureSalutation = new Salutation(secureWriter);
            secureSalutation.Exclaim();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullWriter()
        {
            var salutation = new Salutation(null);
        }
    }
}
