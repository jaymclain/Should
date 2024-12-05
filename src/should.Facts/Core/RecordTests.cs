using System;
using System.Threading.Tasks;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class RecordTests
    {
        public class MethodsWithoutReturnValues
        {
            [Fact]
            public async Task Exception()
            {
                Exception ex = await Record.ExceptionAsync(delegate { throw new InvalidOperationException(); });

                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

            [Fact]
            public void NoException()
            {
                Exception ex = Record.Exception(delegate { });

                Assert.Null(ex);
            }
        }

        public class MethodsWithReturnValues
        {
            [Fact]
            public void Exception()
            {
                StubAccessor accessor = new StubAccessor();

                Exception ex = Record.Exception(() => accessor.FailingProperty);

                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

            [Fact]
            public void NoException()
            {
                StubAccessor accessor = new StubAccessor();

                Exception ex = Record.Exception(() => accessor.SuccessfulProperty);

                Assert.Null(ex);
            }

            class StubAccessor
            {
                public int SuccessfulProperty { get; set; }

                public int FailingProperty
                {
                    get { throw new InvalidOperationException(); }
                }
            }
        }
    }
}