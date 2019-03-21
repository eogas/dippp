using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace dippp.tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SalutationTests
    {
        [TestMethod]
        public void TestExclaim()
        {
            // arrange
            var writer = new Mock<IMessageWriter>();
            var salutation = new Salutation(writer.Object);

            // act
            salutation.Exclaim();

            // assert
            writer.Verify(w => w.Write("Hello DI!"), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullWriter()
        {
            var salutation = new Salutation(null);
        }
    }
}
