using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireWizard.Contoller
{
    public class DiagramFormatter
    {
        // A = Device ID.
        // B = Terminal ID.
        // C = First Destination Device ID.
        // D = First Destination Terminal ID.
        // E = Second Destination Device ID.
        // F = Second Destination Terminal ID.
        private string[] defaultMarkers = { "A", "B", "C", "D", "E", "F"};
        private string defaultDevice = "*A";
        private string defaultConnection = "B.C-D,E-F";
        private string[] lines;
        private string connectionFormat;
        private string deviceFormat;
        private string[] markers;
        private string[] starters, enders;

        public DiagramFormatter()
        {
            this.connectionFormat = defaultConnection;
            this.deviceFormat = defaultDevice;
            markers = defaultMarkers;
            SetFormat();
        }

        public DiagramFormatter(string filePath, string connectionFormat)
        {
            int i = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                lines[i++] = line;
            }
            this.connectionFormat = connectionFormat;
            this.deviceFormat = defaultDevice;
            markers = defaultMarkers;
            SetFormat();
            //ReadDiagram(lines, out Queue<Device> devices, out Queue<Wire> wires);
        }

        public DiagramFormatter(string filePath, string connectionFormat, string deviceFormat)
        {
            int i = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                lines[i++] = line;
            }
            this.connectionFormat = connectionFormat;
            this.deviceFormat = deviceFormat;
            markers = defaultMarkers;
            SetFormat();
        }
        public bool IsDevice(string line) 
        {
            string deviceStart = starters[0];
            string deviceEnd = enders[0];
            if (line.Contains(deviceStart) && line.Contains(deviceEnd))
            {
                return true;
            }
            return false;
        }
        public string ReadDevice(string line) 
        { 
            string deviceStart = starters[0];
            string deviceEnd = enders[0];
            if (IsDevice(line))
            {
                return GetSubstring(line, deviceStart, deviceEnd).Trim();
            }
            return "";
        }
        public bool IsTerminal(string line) 
        {
            string termStart = starters[0];
            string termEnd = enders[0];
            if(line.Contains(termStart) && line.Contains(termEnd))
            { return true; }
            else{ return false; }            
        }
        public string ReadTerminal(string line) 
        {
            string termStart = starters[1];
            string termEnd = enders[1];
            return GetSubstring(line, termStart, termEnd).Trim();
        }
        public bool HasConnection(string line)
        {
            string connStart = starters[1];
            string connMid = enders[2];
            if (line.Contains(connStart) && line.Contains(connMid))
            { return true; }
            else { return false; }
        }
        public bool HasTwoConnections(string line)
        {
            string connStart = starters[4];
            string connEnd = starters[6];
            return false;
        }
        public string ReadConnOneDevice(string line)
        {
            string connOneDevStart = starters[2];
            string connOneDevEnd = enders[2];
            return GetSubstring(line, connOneDevStart, connOneDevEnd).Trim();
        }
        public string ReadConnOneTerminal(string line)
        {
            string connOneTermStart = starters[3];
            string connOneTermEnd = enders[3];
            return GetSubstring(line, connOneTermStart, connOneTermEnd).Trim();
        }
        public string ReadConnTwoDevice(string line)
        {
            string connTwoDevStart = starters[4];
            string connTwoDevEnd = enders[4];
            return GetSubstring(line, connTwoDevStart, connTwoDevEnd).Trim();
        }
        public string ReadConnTwoTerminal(string line)
        {
            string connTwoTermStart = starters[5];
            string connTwoTermEnd = enders[5];
            return GetSubstring(line, connTwoTermStart, connTwoTermEnd).Trim();
        }
        public string GetSubstring(string line, string start, string end)
        {
            int startIndex;
            if (start == "") { startIndex = 0; }
            else { startIndex = line.IndexOf(start) + 1; }

            int length;
            if (end == "") { length = line.Length - startIndex; }
            else { length = line.IndexOf(end) - startIndex; }
            
            return line.Substring(startIndex, length);    
        }
        public void Read(string[]lines, out Queue<Device> devices, out Queue<Wire> wires)
        {   
                        
            

            
            string connOneTermStart = starters[3];
            string connOneTermEnd = enders[3];
            string connTwoDevStart = starters[4];
            string connTwoDevEnd = enders[4];
            string connTwoTermStart = starters[5];
            string connTwoTermEnd = enders[5];

            devices = new Queue<Device>();
            wires = new Queue<Wire>();

            foreach (string line in lines)
            {
                // If this line is empty, go to next.
                if (line.Trim().Equals(""))
                {
                    continue;
                }
                // If line contains device name, create device.
               else //When line is a connection string,
            {
                string str = "";
                // Get terminalID.
                int dotIndex = line.IndexOf('.');
                str = line.Substring(0, dotIndex);
                try { }
                catch (DuplicateTerminalIDException e) { }
            }
            }
        }

        private void SetFormat()
        {
            starters = new string[markers.Length];
            enders = new string[markers.Length];
            string str;
            // For every marker character,
            for (int i = 0; i < markers.Length; i++)
            {

                int index;
                // i == 0 is the index of the device name starter and ender.
                if (i == 0)
                {
                    index = deviceFormat.IndexOf(markers[i]);
                    if(index > 0)
                    {
                        starters[i] = deviceFormat.Substring(0, index).Trim();
                    }
                    else
                    {
                        starters[i] = "";
                    }
                    if(index < deviceFormat.Length - 1)
                    {
                        enders[i] = deviceFormat.Substring(index + 1).Trim(); 
                    }
                    else
                    {
                        enders[i] = "";
                    }
                }
                // After i == 0, assign connection starters and enders.
                else
                {   
                    // Find index of ith marker.
                    index = connectionFormat.IndexOf(markers[i]);
                    if(i == 1)
                    {

                        starters[i] = GetStarter(i, connectionFormat);
                        enders[i] = GetEnder(i, connectionFormat);
                    }
                    else if(i == markers.Length)
                    {
                        starters[i] = GetStarter(i, connectionFormat);
                        enders[i] = connectionFormat.Substring(index + 1, connectionFormat.Length - (index + 1));
                    }
                    else
                    {
                        // If first character of string, empty starter character.
                        if (index == 0)
                        {
                            starters[i] = "";
                            enders[i] = GetEnder(i, connectionFormat);
                        }
                        else if (index == connectionFormat.Length - 1)
                        {
                            enders[i] = "";
                            starters[i] = GetStarter(i, connectionFormat);
                        }
                        // When not the first or last character,
                        else
                        {
                            starters[i] = GetStarter(i, connectionFormat);
                            enders[i] = GetEnder(i, connectionFormat);                            
                        }
                    }
                    
                }
            }
        }

        private string GetStarter(int index, string connectionFormat)
        {
            int i = connectionFormat.IndexOf(markers[index]);
            if (i != 0)
            {
                string reverse = string.Concat(connectionFormat.Reverse());
                return GetEnder(index, reverse);
            }
            return "";
        }

        private string GetEnder(int index, string connectionFormat)
        {
            int i = connectionFormat.IndexOf(markers[index]);
            if(i != connectionFormat.Length - 1)
            {
                string after = connectionFormat.Substring(i + 1);
                string str = "";
                int strLength = 1;
                while (!markers.Any(s => str.Contains(s)))
                {
                    str = after.Substring(0, strLength++);
                }
                string marker = markers.First(s => str.Contains(s));
                str = after.Substring(0, strLength - marker.Length - 1);
                return str;
            }
            return "";
        }

        internal bool IsDeviceName(string line, string start, string end)
        {
            if (line.Contains(start) && line.Contains(end))
            {
                return true;
            }
            return false;
        }

        internal string GetDeviceName(string line, string start, string end)
        {
            int indexStart = line.IndexOf(start);
            int indexEnd = line.IndexOf(end);
            return line.Substring(indexStart + 1, indexEnd - indexStart - 1);
        }   
    }
}
