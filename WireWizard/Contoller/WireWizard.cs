using System;
using System.Collections.Generic;
using System.IO;
using WireWizard.Contoller;

namespace WireWizard
{
    public class WireWizard
    {
        //Test file paths.
            string NCBPath = "../../../NCBDiagram.txt";
            string goodPath = "../../../Diagram.txt";
            string TwoDevicePath = "../../../DoubleDeviceDiagram.txt";
            string bothProbsPath = "../../../BothProbsDiagram.txt";
        DiagramFormatter df;
        private string filePath;
        private string scheduleFilePath;
        private Diagram diagram;
        private List<string> duplicateDevices;
        private List<Wire> ncbWires;

        public WireWizard(string filePath)
        {
            this.filePath = filePath;
            List<string> lines = GetLines(this.filePath);
            df = new DiagramFormatter();
            diagram = new Diagram();
            duplicateDevices = new List<string>();
            ncbWires = new List<Wire>();
            BuildDevices(lines, df);
            Console.WriteLine(diagram.ToString());
            ConnectDevices(lines, df);
            Console.WriteLine(diagram.ToString());
            Console.WriteLine(diagram.WireCount);
        }
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
            set { ncbWires = value; }
        }

        public void WireSchedule(int key)
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
            WriteWireFile();
        }

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
        
        public static List<string> GetLines(string filePath)
        {
            List<string> lines = new List<string>();
            foreach (string line in File.ReadLines(filePath))
            {
                lines.Add(line);
            }
            return lines;
        }
        public string NoCallBackReport()
        {
            if (NCBWires.Count > 0)
            {
                string str = "\nThese connections do not call back.\n";
                foreach (Wire w in NCBWires)
                {
                    str += "Wire Number: " + w.ID + ". " + w.Origin.ToString() + 
                        " - " + w.Destination.ToString() + "\n";
                }
                return str;
            }
            return "";
        }
        public string DupDeviceReport()
        {
            if(DuplicateDevices.Count > 0)
            {                
                string str = "\nSome device names were changed because they were not unique.\n";
                int lastChar = DuplicateDevices.Count - 1;

                foreach(string s in DuplicateDevices)
                {
                    int i = DuplicateDevices.IndexOf(s);                    
                    str += s; 
                    str += (i < lastChar ? ", ": "");
                }
                return str;
            }
            return "";
        }
        public static int CompareWireID(Wire x, Wire y)
        {
            return x.ID.CompareTo(y.ID);
        }
        public static int CompareWireOrigin(Wire x, Wire y)
        {
            int device = x.Origin.Device.ID.CompareTo(y.Origin.Device.ID);
            if (device == 0)
            {
                return CompareTerminal(x.Origin, y.Origin);
            }
            else { return device; }
        }
        public static int CompareWireDest(Wire x, Wire y)
        {
            int device = x.Destination.Device.ID.CompareTo(y.Destination.Device.ID);
            if (device == 0) { 
                return CompareTerminal(x.Destination, y.Destination);
            }
            else { return device; }
        }
        public static int CompareTerminal(Terminal x, Terminal y)
        {
            int xValue = -1;
            int yValue = -1;
            try
            {
                xValue = int.Parse(x.ID);
            }catch(FormatException e) { }
            try
            {
                yValue = int.Parse(y.ID);
            }catch (FormatException e) { }

            if (xValue > -1)
            {
                if(yValue > -1) { return xValue - yValue; }
                else { return -1; }
            }
            else if(yValue > -1) { return 1; }
            else { return x.ID.CompareTo(y.ID); }
        }
        public void BuildDiagram(List<string> lines)
        {
            DiagramFormatter df = new DiagramFormatter();
            Device d = new Device();
            Terminal t = new Terminal();
            Queue<Wire> wireQueue = new Queue<Wire>();
            List<string> devicesBuilt = new List<string>();
            List<string> terminalsBuilt = new List<string>();
            foreach (string l in lines)
            {
                // If this line is empty, go to next.
                if (l.Trim().Equals(""))
                {
                    continue;
                }
                // If line contains device name, add device.
                if (df.IsDevice(l))
                {
                    string str = df.ReadDevice(l);
                    devicesBuilt.Add(str);
                    try
                    {
                        diagram.AddDevice(str);
                        d = diagram.GetDevice(str);
                        continue;
                    }
                    catch (DuplicateDeviceNameException e)
                    {
                        if (devicesBuilt.Contains(str))
                        {
                            duplicateDevices.Add(str);
                            // If duplicate device ID is found,
                            // add "1" to device name.
                            str += "1";
                            diagram.AddDevice(str);                            
                        }
                        d = diagram.GetDevice(str);                        
                        continue;
                    }
                }
                else if (df.IsTerminal(l))
                {
                    Device destDev;
                    Terminal destTerm;
                    // Get terminalID.
                    string str = df.ReadTerminal(l);
                    terminalsBuilt.Add(str);
                    try { d.AddTerminal(str);
                        t = d.GetTerminal(str);
                        terminalsBuilt.Add(t.ToString());
                    }
                    catch (DuplicateTerminalIDException e) 
                    { 
                        if(terminalsBuilt.Contains(str))
                        { }
                    }

                    /// Check for zero, one, or two connections.
                    if (df.HasConnection(l))
                    {


                        str = df.ReadConnOneDevice(l);
                        destDev = diagram.GetOrAddDevice(str);
                        

                        str = df.ReadConnOneTerminal(l);
                        destTerm = destDev.GetOrAddTerminal(l);
                        
                        Wire wire = new Wire(t, destTerm);
                        ConnectWire(wire, wireQueue);
                        if (df.HasTwoConnections(l))
                        {
                            str = df.ReadConnTwoDevice(l);
                            destDev = diagram.GetOrAddDevice(str);

                            str = df.ReadConnTwoTerminal(l);
                            destTerm = destDev.GetOrAddTerminal(str);

                            wire = new Wire(t, destTerm);
                            ConnectWire(wire, wireQueue);
                        }
                    }
                }
            }
            BuildDevices(lines, df);
            ConnectDevices(lines, df);
        }
        
        public void BuildDevices(List<string> lines, DiagramFormatter df)
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
                    try
                    {
                        diagram.AddDevice(name);
                        d = diagram.GetDevice(name);
                        continue;
                    }
                    catch (DuplicateDeviceNameException e)
                    {
                        duplicateDevices.Add(name);
                        // If duplicate device ID is found,
                        // add "1" to device name.
                        name = name + "1";
                        diagram.AddDevice(name);
                        d = diagram.GetDevice(name);
                    }
                }
                else
                {
                    string str = "";
                    // Get terminalID.
                    str = df.ReadTerminal(l);
                    try { d.AddTerminal(str); }
                    catch (DuplicateTerminalIDException e) { }
                }
            }
        }
        
        public void ConnectDevices(List<string> lines, DiagramFormatter df)
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
                    // Remove device marker.
                    string deviceName = df.ReadDevice(l);
                    // If this device name has been wired,
                    // append "1" to name and add new Device.
                    if (isWired.Contains(deviceName))
                    {
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
                int dotIndex = l.IndexOf('.');
                int dashIndex = l.IndexOf('-');
                string termID = l.Substring(0, dotIndex).Trim();
                // Check that device has this terminal ID.
                if(d.HasTerminal(termID)) 
                { 
                    // Retrieve Terminal from terminal list.
                    termA = d.GetTerminal(termID);
                }

                // If terminal string contains two destinations, get the first
                // destination and move the dotIndex variable to get the next.
                if (l.Contains(','))
                {                
                    // Find comma index.
                    int commaIndex = l.IndexOf(',');
                    // Substring of l between dot and comma.
                    term = l.Substring(dotIndex + 1, commaIndex - dotIndex - 1).Trim();
                    // If no characters between dot and comma.
                    if (!term.Equals("")) { 
                        // Retrieve other terminal;
                        termB = diagram.GetTerminal(term);      
                        // Construct new Wire.
                        wire = new Wire(termA, termB);
                        // Add Wire to connection queue.
                        ConnectWire(wire, queue);
                    }
                    // Move start of destination string to comma.
                    dotIndex = commaIndex;
                }
                // Get destination string.
                term = l.Substring(dotIndex + 1).Trim();
                // Check for empty terminal string.
                if (term.Equals(""))
                { 
                    // Go to next line.
                    continue;
                }                
                termB = diagram.GetTerminal(term);
                wire = new Wire(termA, termB);
                //Match to opposite wire or enqueue.
                ConnectWire(wire, queue);                
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
                if (!match)
                {
                    queue.Enqueue(w);
                }
                if (loopCount > queue.Count * 2)
                {
                    while (queue.Count > 0)
                    {
                        NCBWires.Add(queue.Dequeue());
                    }
                    //throw new NoCallBackException();
                }
                loopCount++;
            }


            //throw new TerminalFullException();               

        }
        
        private bool ConnectWire(Wire wire, Queue<Wire> queue)
        {
            Wire queuedWire;
            if (queue.Count > 0)
            {
                int limit = queue.Count;
                for (int i = 0; i < limit; i++)
                {
                    queuedWire = queue.Dequeue();
                    if (wire.Origin.Equals(queuedWire.Destination) && wire.Destination.Equals(queuedWire.Origin))
                    {
                        queuedWire.Connect();
                        diagram.Wires.Add(queuedWire);
                        return true;
                    }
                    else
                    {                        
                        queue.Enqueue(queuedWire);
                    }
                }
                queue.Enqueue(wire);
                return false;                
            }
            else
            {
                queue.Enqueue(wire);
                return false;
            }
        }
    }
}
