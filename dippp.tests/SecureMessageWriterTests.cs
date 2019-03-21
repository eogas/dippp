using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dippp.tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SecureMessageWriterTests
    {
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
            IMessageWriter writer = null;
            IIdentity identity = new GenericIdentity("asdf");
            IMessageWriter secureWriter = new SecureMessageWriter(writer, identity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullIdentity()
        {
            IMessageWriter writer = new ConsoleMessageWriter();;
            IIdentity identity = null;
            IMessageWriter secureWriter = new SecureMessageWriter(writer, identity);
        }
    }
}
