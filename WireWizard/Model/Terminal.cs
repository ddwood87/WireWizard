using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireWizard
{
    public class Terminal
    {
        private string id;
        private Device device;
        private Wire wire1;
        private Wire wire2;
        
        public Terminal() { }

        public Terminal(string id)
        {
            this.id = id;
        }
        public Terminal(string id, Device device)
        {
            this.id = id;
            this.device = device;
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public Device Device
        {
            get { return device; }
            set { device = value; }
        }
        public Wire Wire1
        {
            get { return wire1; }
        }
        public Wire Wire2
        {
            get { return wire2; }
        }

        public void Connect(Wire wire)
        {
            if (!wire.IsConnected(this)) { 
                if (wire1 == null)
                {
                    wire1 = wire;
                }
                else if (wire2 == null)
                {
                    wire2 = wire;
                }
            }
        }

        public void RemoveWires()
        {
            wire1 = null;
            wire2 = null;
        }

        public override string ToString()
        {
            return Device.ID + "-" + id;
        }
    }
}
