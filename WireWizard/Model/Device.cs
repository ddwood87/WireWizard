using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireWizard
{
    public class Device
    {
        private Diagram diagram;
        private string id;
        private List<Terminal> terminals;

        // Default constructor.
        public Device()
        {
            this.terminals = new List<Terminal>();
        }

        // Constructor
        // param string ID for device.
        public Device(string id)
        {
            this.id = id;
            this.terminals = new List<Terminal>();
        }

        // Constructor.
        // param string ID and Diagram
        public Device(string id, Diagram diagram)
        {
            this.diagram = diagram;
            this.id = id;
            this.terminals = new List<Terminal>();
        }

        // Accessors.
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public List<Terminal> Terminals
        {
            get { return terminals; }
            set { terminals = value; }
        }

        // This method adds a terminal to the device.
        // param Terminal
        public void AddTerminal(Terminal terminal)
        {
            if (HasTerminal(terminal.ID))
            {
                throw new DuplicateTerminalIDException("This terminal ID already exists.");
            }
            terminals.Add(terminal);
        }

        // This method creates a terminal and adds it to the device.
        // param string terminal ID
        public void AddTerminal(string terminalID)
        {
            if (HasTerminal(terminalID))
            {
                throw new DuplicateTerminalIDException("This terminal ID is already in use.");
            }
            terminals.Add(new Terminal(terminalID, this));
        }

        // This method returns true if device contains a terminal ID.
        // param string terminal ID.
        public bool HasTerminal(string terminalID)
        {
            return this.Terminals.Exists(t => t.ID == terminalID.Trim());
        }

        // This method gets a terminal object from the device.
        // param string terminal ID.
        // returns Terminal object.
        public Terminal GetTerminal(string terminalID)
        {
            return this.Terminals.First(t => t.ID == terminalID);
        }

        // This method removes a terminal from the device.
        // param Terminal to be removed.
        public void RemoveTerminal(Terminal t)
        {
            t.RemoveWires();
            terminals.Remove(t);
        }

        // This method writes a string describing the device and its terminals.
        // returns string detailing device.
        public override string ToString()
        {
            string str = "";
            str = this.ID + "\n";
            foreach (Terminal t in this.terminals)
            {
                str += t.ID + ".";
                str += (t.Wire1 == null ? "" : (t.Wire1.Origin == t ? 
                    t.Wire1.Destination.ToString() : t.Wire1.Origin.ToString()));

                str += (t.Wire1 != null && t.Wire2 != null ? ", " : "");

                str += (t.Wire2 == null ? "" : (t.Wire2.Origin == t ? 
                    t.Wire2.Destination.ToString() : t.Wire2.Origin.ToString()));

                str += "\n";
            }
            return str;
        }
    }   
}
