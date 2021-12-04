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
        private string partNo;
        private string id;
        private List<Terminal> terminals;

        public Device()
        {
            this.terminals = new List<Terminal>();
        }
        public Device(string name)
        {
            this.id = name;
            this.terminals = new List<Terminal>();
        }
        public Device(string name, Diagram diagram)
        {
            this.diagram = diagram;
            this.id = name;
            this.terminals = new List<Terminal>();
        }

        public string PartNumber
        {
            get { return partNo; }
            set { partNo = value; }
        }
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
        public void AddTerminal(Terminal terminal)
        {
            if (HasTerminal(terminal.ID))
            {
                throw new DuplicateTerminalIDException("This terminal ID already exists.");
            }
            terminals.Add(terminal);
        }
        public void AddTerminal(string terminalID)
        {
            if (HasTerminal(terminalID))
            {
                throw new DuplicateTerminalIDException("This terminal ID is already in use.");
            }
            terminals.Add(new Terminal(terminalID, this));
        }
        public bool HasTerminal(string terminalID)
        {
            return this.Terminals.Exists(t => t.ID == terminalID.Trim());
        }
        public Terminal GetTerminal(string terminalID)
        {
            return this.Terminals.First(t => t.ID == terminalID);
        }
        public void RemoveTerminal(Terminal t)
        {
            t.RemoveWires();
            terminals.Remove(t);
        }
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

        internal Terminal GetOrAddTerminal(string str)
        {
            Terminal t;
            if (HasTerminal(str))
            {
                t = GetTerminal(str);
            }
            else
            {
                t = new Terminal(str);
                AddTerminal(t);
            }
            return t;
        }
    }   
}
