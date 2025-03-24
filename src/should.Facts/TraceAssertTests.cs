using System;
using System.Diagnostics;
using Should.Core.Exceptions;
using Xunit;
using Xunit.Abstractions;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class ThrowListener : TextWriterTraceListener
{
    public override void Fail(string message)
    {
        throw new Exception(message);
    }

    public override void Fail(string message, string detailMessage)
    {
        throw new Exception(message);
    }
}
    public class ThrowListenerFixture
    {
        public ThrowListenerFixture()
        {
            Trace.Listeners.RemoveAt(0);
            Trace.Listeners.Add(new ThrowListener());
        }

        public void Dispose()
        {

        }
    }

    public class TraceAssertTests //: IClassFixture<ThrowListenerFixture>
    {
        private readonly ITestOutputHelper _output;

        public TraceAssertTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TraceAssertFailureWithFullDetails()
        {
            var ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false, "message", "detailed message"));

            Assert.Equal("message", ex.AssertMessage);
            Assert.Equal("detailed message", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure : message" + Environment.NewLine + "Detailed Message:" + Environment.NewLine + "detailed message", ex.Message);
        }

        [Fact]
        public void TraceAssertFailureWithNoDetailedMessage()
        {
            TraceAssertException ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false, "message"));

            Assert.Equal("message", ex.AssertMessage);
            Assert.Equal("", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure : message", ex.Message);
        }

        [Fact]
        public void TraceAssertFailureWithNoMessage()
        {
            TraceAssertException ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false));

            Assert.Equal("", ex.AssertMessage);
            Assert.Equal("", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure", ex.Message);
        }
    }
}