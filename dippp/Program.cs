using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace dippp
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            IMessageWriter writer = new ConsoleMessageWriter();
            IMessageWriter secureWriter = new SecureMessageWriter(writer, new GenericIdentity("evan"));

            var salutation = new Salutation(secureWriter);
            salutation.Exclaim();
        }
    }
}
