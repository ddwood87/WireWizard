using System;
using Xunit;
using WireWizard;

namespace TestWireWizard
{
    public class TestDevice
    {
        [Fact]
        public void AddTerminalTest()
        {
            string term = "2";
            Device d = new Device();
            d.AddTerminal(term);
            Assert.True(d.HasTerminal(term));
        }
        [Fact]
        public void AddTerminal_DuplicateID()
        {
            string term = "2";
            Device d = new Device();
            d.AddTerminal(term);
            Assert.Throws<DuplicateTerminalIDException>(() => d.AddTerminal(term));
        }
        [Fact]
        public void RemoveTerminalTest()
        {
            string term = "2";
            Device d = new Device();
            d.AddTerminal(term);
            Assert.True(d.HasTerminal(term));
            d.RemoveTerminal(d.Terminals.Find(t => t.ID == term));
            Assert.False(d.HasTerminal(term));
        }
    }
}
