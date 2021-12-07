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
        
        // Default constructor sets no fields.
        public Terminal() { }

        // Constructor sets the ID field.
        public Terminal(string id)
        {
            this.id = id;
        }

        // Constructor sets id and device fields.
        public Terminal(string id, Device device)
        {
            this.id = id;
            this.device = device;
        }

        // Accessors.
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

        // This method connects adds a wire to an empty wire field.
        // param Wire to be added.
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

        // This method removes wires from the terminal.
        public void RemoveWires()
        {
            wire1 = null;
            wire2 = null;
        }

        // This method writes a string containing device ID and terminal ID.
        // returns string terminal name.
        public override string ToString()
        {
            return Device.ID + "-" + id;
        }
    }
}
