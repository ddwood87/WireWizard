using System;
using System.Collections.Generic;
using System.IO;
using WireWizard.Contoller;

namespace WireWizard
{
    public class WireWizard
    {
        //Test file paths.
        string NCBPath = "../../../../SampleDiagrams/NCBDiagram.txt";
        string goodPath = "../../../../SampleDiagrams/Diagram.txt";
        string TwoDevicePath = "../../../../SampleDiagrams/DoubleDeviceDiagram.txt";
        string bothProbsPath = "../../../../SampleDiagrams/BothProbsDiagram.txt";
        DiagramFormatter df;
        private string filePath;
        private string scheduleFilePath;
        private Diagram diagram;
        private List<string> duplicateDevices;
        private List<Wire> ncbWires;

        // Constructor takes file path and formatter.
        // param string filePath, DiagramFormatter helper class.
        // Builds diagram object from file.
        public WireWizard(string filePath, DiagramFormatter formatter)
        {
            this.filePath = filePath;
            List<string> lines = GetLines(this.filePath);
            df = formatter;
            diagram = new Diagram(df);
            duplicateDevices = new List<string>();
            ncbWires = new List<Wire>();
            BuildDevices(lines);
            ConnectDevices(lines);
        }

        // Accessors
        public string ScheduleFilePath
        {
            get { return scheduleFilePath; }
        }
        public Diagram Diagram
        {
            get { return diagram; }
        }

        public List<string> DuplicateDevices
        {
            get { return duplicateDevices; }
        }

        public List<Wire> NCBWires
        {
            get { return ncbWires; }
            //set { ncbWires = value; }
        }

        public DiagramFormatter Format
        {
            get { return df; }
            set { df = value; }
        }

        // This method takes a key value to choose a sort method and sorts the wire list.
        // param int key
        public void WireScheduleSort(int key)
        {   
            // Write file output.
            switch (key){
                case 0:                    
                    diagram.Wires.Sort(CompareWireID);
                    break;
                case 1:
                    diagram.Wires.Sort(CompareWireOrigin);
                    break;
                case 2:
                    diagram.Wires.Sort(CompareWireDest);
                    break;
                // Additional cases here.
                default:
                    diagram.Wires.Sort(CompareWireID);
                    break;
            }            
        }

        // This method creates a directory folder of the same name as the diagram file.
        // Then it creates a file containing the wire list in its most recent sort order.
        public void WriteWireFile()
        {               
            Directory.CreateDirectory(filePath.Substring(0, filePath.Length-4));
            scheduleFilePath = filePath.Substring(0, filePath.Length - 4) + "\\Wires" + filePath.Substring(filePath.Length - 4);
            
            using (StreamWriter writer = new StreamWriter(scheduleFilePath))
            {
                foreach(Wire w in diagram.Wires)
                {
                    writer.WriteLine(w.ToString());
                }
            }
        }
        
        // This method reads the lines of a file into a list of strings.
        // param filePath
        // returns list of strings from file lines.
        public static List<string> GetLines(string filePath)
        {
            List<string> lines = new List<string>();
            foreach (string line in File.ReadLines(filePath))
            {
                lines.Add(line);
            }
            return lines;
        }

        // This method writes a string detailing wire calls that had no return call.
        // returns string describing wires that failed to match.
        public string NoCallBackReport()
        {
            if (NCBWires.Count > 0)
            {
                string str = "These connections do not call back.\n";
                foreach (Wire w in NCBWires)
                {
                    str += "Wire Number: " + w.ID + ". " + w.Origin.ToString() + 
                        " - " + w.Destination.ToString() + "\n";
                }
                return str + "\n";
            }
            return "";
        }

        // This method writes a string detailing device names that were not unique.
        // returns string detailing duplicate devices and changes made.
        public string DupDeviceReport()
        {
            if(DuplicateDevices.Count > 0)
            {                
                string str = "Some device names were changed because they were not unique.\n";
                int lastChar = DuplicateDevices.Count - 1;

                foreach(string s in DuplicateDevices)
                {
                    int i = DuplicateDevices.IndexOf(s);                    
                    str += s; 
                    str += (i < lastChar ? ", ": "");
                }
                return str + "\n";
            }
            return "";
        }

        // Set of methods to compare wire objects by different parameters.
        // Compares wire IDs
        public static int CompareWireID(Wire x, Wire y)
        {
            return x.ID.CompareTo(y.ID);
        }

        // Compares wire origin terminal.
        public static int CompareWireOrigin(Wire x, Wire y)
        {
            int device = x.Origin.Device.ID.CompareTo(y.Origin.Device.ID);
            if (device == 0)
            {
                return CompareTerminal(x.Origin, y.Origin);
            }
            else { return device; }
        }
        
        // Compares wire destination terminal.
        public static int CompareWireDest(Wire x, Wire y)
        {
            int device = x.Destination.Device.ID.CompareTo(y.Destination.Device.ID);
            if (device == 0) { 
                return CompareTerminal(x.Destination, y.Destination);
            }
            else { return device; }
        }

        // Compares terminal IDs.
        public static int CompareTerminal(Terminal x, Terminal y)
        {
            int xValue = -1;
            int yValue = -1;
            try     // Try to parse in from terminal x ID.
            {
                xValue = int.Parse(x.ID);
            }catch(FormatException e) { }
            try     // Try to parse int from terminal y ID.
            {
                yValue = int.Parse(y.ID);
            }catch (FormatException e) { }
            // If either string fails to parse, put the parsed string first.
            if (xValue > -1)
            {
                // If both strings successfully parse to int.
                if(yValue > -1) { return xValue - yValue; }
                else { return -1; }
            }
            else if(yValue > -1) { return 1; }
            // If neither string parses, compare strings to find order.
            else { return x.ID.CompareTo(y.ID); }
        }
            
        // This method builds devices and their terminals.
        // param list of strings detailing a wire diagram.
        public void BuildDevices(List<string> lines)
        {   
            Device d = new Device();
            foreach (string l in lines)
            {                
                // If this line is empty, go to next.
                if (l.Trim ().Equals(""))
                {
                    continue;
                }                 
                // If line contains device name, add device.
                if (df.IsDevice(l))
                {  
                    string name = df.ReadDevice(l);
                    // Loop will add "1" to device name until it is unique.
                    // Then add and get the device object.
                    bool done = false;
                    while (!done) {
                        try
                        {
                            diagram.AddDevice(name);
                            d = diagram.GetDevice(name);
                            done = true;
                            continue;
                        }
                        // If device name is already used, alter name.
                        catch (DuplicateDeviceNameException e)
                        {
                            duplicateDevices.Add(name);
                            // If duplicate device ID is found,
                            // add "1" to device name.
                            name = name + "1";
                        }
                    }
                }
                // When this line is a terminal.
                else
                {
                    string str = "";
                    // Get terminalID.
                    str = df.ReadTerminal(l);
                    // Does not add duplicate terminal.
                    try { d.AddTerminal(str); }
                    catch (DuplicateTerminalIDException e) { /*Do not add duplicates*/ }
                }
            }
        }
        
        // This method connects terminal objects with wire objects.
        // param list of strings from diagram file.
        public void ConnectDevices(List<string> lines)
        {            
            Device d = null;
            Terminal termA = null;
            Terminal termB = null;
            Wire wire = null;
            Queue<Wire> queue = new Queue<Wire>();
            string term;
            List<string> isWired = new List<string>();
            foreach (string l in lines)
            {
                // Check for empty line.
                if (l.Trim().Equals("")) { continue; }
                // Check for new device name in next line l
                if (df.IsDevice(l))
                {
                    string deviceName = df.ReadDevice(l);
                    // If this device name has been wired earlier,
                    
                    if (isWired.Contains(deviceName))
                    {   
                        // append "1" to name and get renamed Device.
                        if (diagram.HasDevice(deviceName + "1"))
                        { 
                            deviceName += "1";
                            d = diagram.GetDevice(deviceName);
                        }
                    }
                    else
                    {
                        // Retrieve device object from device list.
                        d = diagram.GetDevice(deviceName);
                    }
                    // Add current device to isWired list.
                    isWired.Add(d.ID);                 
                    continue;
                }
                // When next line is a terminal string,
                string termID = df.ReadTerminal(l);
                // Check that device has this terminal ID.
                if(d.HasTerminal(termID)) 
                { 
                    // Retrieve Terminal from terminal list.
                    termA = d.GetTerminal(termID);
                }
                // If line has a connection.
                if (df.HasConnection(l))
                {
                    string deviceName;
                    Device tempDevice;
                    
                    // Get destination strings.
                    deviceName = df.ReadConnOneDevice(l);
                    term = df.ReadConnOneTerminal(l);
                    // Check for empty terminal string.
                    if (term.Equals(""))
                    {
                        // Go to next line.
                        continue;
                    }
                    // Get device from diagram.
                    tempDevice = diagram.GetDevice(deviceName);
                    // Get terminal from device.
                    termB = tempDevice.GetTerminal(term);
                    wire = new Wire(termA, termB);
                    //Match to opposite wire or enqueue.
                    ConnectWire(wire, queue);
                    // If the line has two connections.
                    if (df.HasTwoConnections(l))
                    {
                        // Read second connection device and terminal IDs.               
                        deviceName = df.ReadConnTwoDevice(l);
                        term = df.ReadConnTwoTerminal(l);

                        if (!term.Equals(""))
                        {
                            // Get device.
                            tempDevice = diagram.GetDevice(deviceName);
                            // Retrieve other terminal.
                            termB = tempDevice.GetTerminal(term);
                            // Construct new Wire.
                            wire = new Wire(termA, termB);
                            // Add Wire to connection queue.
                            ConnectWire(wire, queue);
                        }
                    }
                }
            }
            // If some wires don't match, more checks.
            int loopCount = 0;
            while(queue.Count > 0)
            {
                // Get next wire.
                Wire w = queue.Dequeue();
                // Get terminal string for w.Destination.
                string a = w.Destination.ToString();
                int dashIndex = a.IndexOf("-");
                // Add 1 to end of device ID.
                a = a.Substring(0, dashIndex) + "1" + a.Substring(dashIndex);
                bool match = false;
                

                // Loop for other wires in queue.
                int inner = queue.Count;
                for (int j = 0; j < inner; j++)
                {
                    // Compare to next wire in queue.
                    Wire comp = queue.Dequeue();
                    // Get Origin
                    string b = comp.Origin.ToString();
                    // Compare altered string from wires and attempt match.
                    if (a.Equals(b) && w.Origin.Equals(comp.Destination))
                    {
                        dashIndex = b.IndexOf("-");
                        w.Destination = comp.Origin;
                        w.Connect();
                        diagram.Wires.Add(w);
                        match = true;
                    }
                    else
                    {
                        queue.Enqueue(comp);
                    }
                    if (j == queue.Count + 1 || match)
                    {
                        // Exit loop if queue is empty.
                        j = inner;
                    }
                }
                // If no match, enqueue wire.
                if (!match)
                {
                    queue.Enqueue(w);
                }
                // If loop has run twice for each wire, add wires to bad wire list.
                if (loopCount > queue.Count * 2)
                {
                    while (queue.Count > 0)
                    {
                        NCBWires.Add(queue.Dequeue());
                    }
                }
                loopCount++;
            }
        }
        
        // This method attempts to match a wire to another in a queue of wires.
        private bool ConnectWire(Wire wire, Queue<Wire> queue)
        {

            Wire queuedWire;
            if (queue.Count > 0)
            {
                // Save current queue count and loop for that count.
                int limit = queue.Count;
                for (int i = 0; i < limit; i++)
                {
                    queuedWire = queue.Dequeue();
                    // Compare wire to queued wire. 
                    if (wire.Origin.Equals(queuedWire.Destination) && wire.Destination.Equals(queuedWire.Origin))
                    {
                        //Connect and add to wire list.
                        queuedWire.Connect();
                        diagram.Wires.Add(queuedWire);
                        return true;
                    }
                    else
                    {        
                        // Requeue the wire if not matched.
                        queue.Enqueue(queuedWire);
                    }
                }
                // Enqueue the current wire if no match was found.
                queue.Enqueue(wire);
                return false;                
            }
            // Enqueue the wire if no wires are in queue.
            else
            {
                queue.Enqueue(wire);
                return false;
            }
        }
    }
}
