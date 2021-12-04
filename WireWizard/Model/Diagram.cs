using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireWizard
{
    public class Diagram
    {
        private string id;
        private List<Device> devices;
        private List<Wire> wires;
        private static int nextID = 100;
        
        //Constructors;
        public Diagram()
        {
            devices = new List<Device>();
            wires = new List<Wire>();
            this.id = GetID();
        }



        public Diagram(List<Device> devices, string id)
        {
            this.Devices = devices;
            wires = new List<Wire>();
            this.id = id;
        }

        //Accessors
        public int WireCount
        {

            get { return wires.Count; }
        }
        public int DeviceCount
        {
            get { return devices.Count; }
        }

        

        public List<Device> Devices
        {
            get { return devices; }
            set { devices = value; }
        }
        public List<Wire> Wires
        {
            get { return wires; }
            set { wires = value; }
        }
        public void AddDevice(Device device)
        {
            if (HasDevice(device.ID))
            {
                throw new DuplicateDeviceNameException("This device name is already in use.");
            }
            devices.Add(device);
        }
        public void AddDevice(string name)
        {
            AddDevice(new Device(name, this));
        }
        public bool HasDevice(string id)
        {
            return devices.Exists(d => d.ID == id.Trim());
        }


        

        public Device GetDevice(string deviceID)
        {
            return this.Devices.First(d => d.ID == deviceID);
        }

        internal Terminal GetTerminal(string destination)
        {
            string str = "";
            string c;
            int i = 0;
            int dashIndex = destination.IndexOf('-');
            str = destination.Substring(0, dashIndex);
            Device device = devices.First<Device>(d => d.ID == str);
            str = destination.Substring(dashIndex + 1);
            return device.Terminals.First<Terminal>(t => t.ID == str);
        }
        

        private bool IsTerminalName(Device d, string str)
        {
            foreach (Terminal t in d.Terminals)
            {
                
                if (t.ID.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
        
        private string GetID()
        {
            return nextID++.ToString();
        }



        public override string ToString()
        {
            string str = "";
            foreach (Device d in this.devices)
            {
                str += "\n" + d.ToString() + "\n";
            }
            return str;
        }

        public string[] ListWires()
        {
            string[] str = new string[this.WireCount];
            int i = 0;
            foreach (Wire w in this.wires)                
            {
                str[i++] = w.ToString();
            }
            return str;
        }

        internal Device GetOrAddDevice(string str)
        {
            Device d;
            if (HasDevice(str))
            {
                d = GetDevice(str);
            }
            else
            {
                AddDevice(str);
                d = GetDevice(str);
            }
            return d;
        }
    }
}
