using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace dippp.tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConsoleMessageWriterTests
    {
        [TestMethod]
        public void TestWrite()
        {
            var writer = new ConsoleMessageWriter();
            writer.Write("test");
        }

        [TestMethod]
        public void TestWriteNull()
        {
            var writer = new ConsoleMessageWriter();
            writer.Write(null);
        }
    }
}
