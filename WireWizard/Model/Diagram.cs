using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireWizard.Contoller;
namespace WireWizard
{
    public class Diagram
    {
        private string id;                  // Unique identifier for diagram.
        private List<Device> devices;       // List of devices.
        private List<Wire> wires;           // List of wires.
        private static int nextID = 100;    // Static number used to generate ID numbers.
        private DiagramFormatter df;        // Formatter class to help read files.

        // Default Constructor.
        public Diagram()
        {
            devices = new List<Device>();
            wires = new List<Wire>();
            df = new DiagramFormatter();
            id = GetID();                   // Generate ID.
        }

        // Constructor
        // Takes a formatter object.
        public Diagram(DiagramFormatter formatter)
        {
            devices = new List<Device>();
            wires = new List<Wire>();
            df = formatter;
            id = GetID();                   // Generate ID.
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

        // Method to add device to diagram.
        // param Device
        public void AddDevice(Device device)
        {
            if (HasDevice(device.ID))
            {
                throw new DuplicateDeviceNameException("This device name is already in use.");
            }
            devices.Add(device);
        }

        // Method to add device to diagram.
        // param string device ID.
        public void AddDevice(string id)
        {
            AddDevice(new Device(id, this));    //Construct new Device with given id.
        }

        // Method to check if device exists.
        // param string device ID.
        // returns true if device list contains this ID.
        public bool HasDevice(string id)
        {
            return devices.Exists(d => d.ID == id.Trim());
        }
         
        // Method to get device object with given ID.
        // param string device ID.
        // returns existing Device object from the diagram.
        public Device GetDevice(string deviceID)
        {
            return this.Devices.First(d => d.ID == deviceID);
        }

        // Method to get terminal object with given ID.
        // param string terminal ID.
        // returns existing Terminal object from a device.
        public Terminal GetTerminal(string id)
        { 
            string str = "";
            str = df.DestinationDeviceID(id);
            Device device = devices.First<Device>(d => d.ID == str);
            str = df.DestinationTerminalID(id);
            return device.Terminals.First<Terminal>(t => t.ID == str);
        }        

        // Method to generate unique ID numbers.
        // returns unique ID number from static seed.
        private string GetID()
        {
            return nextID++.ToString();
        }

        // Method to make a string that represents the diagram.
        // returns string describing devices and terminals.
        public override string ToString()
        {
            string str = "";
            foreach (Device d in this.devices)
            {
                str += "\n" + d.ToString() + "\n";
            }
            return str;
        }
    }
}
