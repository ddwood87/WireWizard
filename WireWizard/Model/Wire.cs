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
        public Wire() { }

        public Wire(Terminal origin, Terminal destination)
        {
            this.origin = origin;
            this.destination = destination;
            this.id = this.GetID();
            this.gauge = 14;
        }
        public Wire(Terminal origin, Terminal destination, int gauge, string id)
        {
            this.origin = origin;
            this.destination = destination;
            this.id = id;
            this.gauge = gauge;
        }

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
        internal string GetID()
        {
            return nextID++.ToString();
        }

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

        public void Connect()
        {
            this.origin.Connect(this);
            this.destination.Connect(this);
        }

        public override string ToString()
        {
            return "Wire ID: " + this.ID + " " + this.origin.ToString() + " - " + 
                    this.destination.ToString();
        }
    }
}
