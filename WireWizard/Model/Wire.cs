using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireWizard
{
    public class Wire
    {
        private Terminal origin;
        private Terminal destination;
        private string id;
        private static int nextID = 1000;
        private int gauge;

        // Default Constructor
        public Wire() { }

        // Constructor taking origin and destination Terminals.
        public Wire(Terminal origin, Terminal destination)
        {
            this.origin = origin;
            this.destination = destination;
            this.id = this.GetID();
            this.gauge = 14;
        }

        // Accessors.
        public Terminal Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Terminal Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public string ID
        {
            get { return id; }
        }
        public int Gauge
        {
            get { return gauge; }
            set { gauge = value; }
        }

        // This method creates a unique ID number from a seed.
        internal string GetID()
        {
            return nextID++.ToString();
        }

        // This method checks that the wire is connected to a terminal.
        // param Terminal
        // returns boolean true if input terminal matches origin or destination terminal.
        public bool IsConnected(Terminal t)
        {
            if (origin.Equals(t) || destination.Equals(t))
            {
                if (t.Wire1 == this || t.Wire2 == this)
                {
                    return true;
                }
            }
            return false;
        }

        // This method connects the wire to the origin and the destination terminals.
        public void Connect()
        {
            this.origin.Connect(this);
            this.destination.Connect(this);
        }

        // This method creates a string to describe the wire object.
        // returns string of wire object details.
        public override string ToString()
        {
            return "Wire ID: " + this.ID + " " + this.origin.ToString() + " - " + 
                    this.destination.ToString();
        }
    }
}
