using System;
using Xunit;
using WireWizard;

namespace TestWireWizard
{
    public class TestWire
    {
        [Fact]
        public void IsConnectedTest()
        {
            Terminal t1 = new Terminal();
            Terminal t2 = new Terminal();
            Terminal t3 = new Terminal();
            Wire w = new Wire(t1, t2);
            w.Connect();
            Assert.True(w.IsConnected(t1));
            Assert.True(w.IsConnected(t2));
            Assert.False(w.IsConnected(t3));
        }
        [Fact]
        public void ConnectTest()
        {
            Terminal a = new Terminal();
            Terminal b = new Terminal();
            Wire wire = new Wire(a, b);

            Assert.Equal(wire.Origin, a);
            Assert.Equal(wire.Destination, b);
        }
    }
}
