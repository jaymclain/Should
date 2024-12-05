using System;
using System.Text.Json;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class SerializationTests
    {
        [Serializable]
        class SerializableObject { }

        [Fact]
        void CanSerializeAndDeserializeObjectsInATest()
        {
            var serialized = JsonSerializer.Serialize(new SerializableObject());
            var o = JsonSerializer.Deserialize<SerializableObject>(serialized);

            Assert.IsType(typeof(SerializableObject), o);
            Assert.DoesNotThrow(delegate { SerializableObject o2 = (SerializableObject)o; });
        }
    }
}