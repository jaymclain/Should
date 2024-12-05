using System;
using Machine.Specifications;
using NUnit.Framework;
using Should.Core.Exceptions;

namespace Should.Fluent.UnitTests
{
    [Behaviors]
    public class Throws<T> where T : AssertException
    {
        protected static Exception exception;

        It should_throw_assert_exception_of_expected_type = () =>
        {
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception, Is.InstanceOf(typeof(T)));
        };
    }

    [Behaviors]
    public class DoesNotThrow
    {
        protected static Exception exception;
        It should_throw_not_equal_exception = () => Assert.That(exception, Is.Null);
    }
}