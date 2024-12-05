using System;
using Machine.Specifications;
using NUnit.Framework;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    public class integration_test_base
    {
        protected static Exception exception;

        protected static void Try(Action assertAction)
        {
            exception = Catch.Exception(assertAction);
        }
    }
}