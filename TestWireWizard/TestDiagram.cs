using System;
using System.Collections.Generic;
using Xunit;
using WireWizard;

namespace TestWireWizard
{
    public class TestDiagram
    {
        string nameAA = "*AA";
        string nameAB = "*AB";
        string connection1 = "1.AA-2";
        string connection2 = "2.AB-1";
        [Fact]
        public void AddDeviceTest()
        {
            Diagram d = new Diagram();
            Device a = new Device(nameAA, d);
            d.AddDevice(a);
            Assert.True(d.HasDevice(a.ID));
        }
        [Fact]
        public void AddDevice_DuplicateName()
        {
            Diagram d = new Diagram();
            d.AddDevice(nameAA);
            d.AddDevice(nameAB);
            Assert.Throws<DuplicateDeviceNameException>(() => d.AddDevice(nameAA));
        }
        [Fact]
        public void AddWireTest()
        {
            Diagram d = new Diagram();
            Device a = new Device();
            Terminal t = new Terminal();
            Terminal s = new Terminal();
            Wire wire = new Wire(t, s);
            wire.Connect();
            Assert.Equal(t.Wire1, wire);
            Assert.Equal(s.Wire1, wire);

        }
        /**
        [Fact]
        public void BuildDrawing_NoMistakes()
        {
            Diagram d = new Diagram();
            string file = "../../../Diagram.txt";
            List<string> lines = WireWizard.WireWizard.GetLines(file);
            d.BuildDevices(lines);
            d.ConnectDevices(lines);
            Assert.Empty(d.NCBWires);
        }
        [Fact]
        public void BuildDrawing_NoCallBack()
        {
            Diagram d = new Diagram();
            string file = "../../../NCBDiagram.txt";
            List<string> lines = WireWizard.WireWizard.GetLines(file);
            d.BuildDevices(lines);
            d.ConnectDevices(lines);
            Assert.NotEmpty(d.NCBWires);
        }*/
    }
}
