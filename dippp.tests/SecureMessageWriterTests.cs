using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace dippp.tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SecureMessageWriterTests
    {
        [TestMethod]
        public void TestSecureWriterAuthed()
        {
            // arrange
            var writer = new Mock<IMessageWriter>();
            var identity = new Mock<IIdentity>();
            identity.SetupGet(i => i.IsAuthenticated).Returns(true);

            var secureWriter = new SecureMessageWriter(writer.Object, identity.Object);

            // act
            secureWriter.Write("test");

            // assert
            writer.Verify(w => w.Write("test"), Times.Once());
        }

        [TestMethod]
        public void TestSecureWriterNoAuth()
        {
            // arrange
            var writer = new Mock<IMessageWriter>();
            var identity = new Mock<IIdentity>();
            identity.SetupGet(i => i.IsAuthenticated).Returns(false);
            
            var secureWriter = new SecureMessageWriter(writer.Object, identity.Object);

            // act
            secureWriter.Write("test");

            // assert
            writer.Verify(w => w.Write("test"), Times.Never());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullWriter()
        {
            new SecureMessageWriter(writer: null, identity: Mock.Of<IIdentity>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullIdentity()
        {
            new SecureMessageWriter(writer: Mock.Of<IMessageWriter>(), identity: null);
        }
    }
}
