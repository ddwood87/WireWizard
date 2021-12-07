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
        private string connectionFormat;
        private string deviceFormat;
        private string[] markers;
        private string[] starters, enders;

        // Accessors.
        public string ConnectionFormat
        {
            get { return connectionFormat; }
            set { connectionFormat = value;
                  SetFormat();
                }
        }
        public string DeviceFormat
        {
            get { return deviceFormat; }
            set { 
                deviceFormat = value;
                SetFormat();
            }
        }

        // Default constructor.
        public DiagramFormatter()
        {
            this.connectionFormat = defaultConnection;
            this.deviceFormat = defaultDevice;
            markers = defaultMarkers;
            SetFormat();
        }

        // Sets the formatter to default values.
        public void DefaultFormat()
        {
            deviceFormat = defaultDevice;
            connectionFormat = defaultConnection;
            SetFormat();
        }

        // This method returns true if the line has a device name.
        // param string file line.
        // returns boolean true if the line is a device ID.
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

        // This method gets the device ID from a line.
        // param string file line.
        // returns string device ID.
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

        // This method gets the separator characters used in the format.
        // returns string array containing separator characters.
        public string[] GetSeparators()
        {
            string[] separators = new string[8];
            int s = 0;
            separators[s++] = starters[0];
            separators[s++] = enders[0];
            for (int i = 1; i < starters.Length; i++)
            {
                if (starters[i] == enders[i - 1])
                {
                    separators[s++] = starters[i];
                }
                else
                {
                    separators[s++] = enders[i - 1] + starters[i];
                    if (i == starters.Length - 1)
                    {
                        separators[s++] = enders[i];
                    }
                }
            }
            return separators;            
        }

        // This method builds a Device name string using separators.
        // param separators
        // returns string device ID file line.
        public string BuildDeviceFormat(string[] separators)
        {
            string str = "";
            str += separators[0] + markers[0] + separators[1];
            return str;
        }

        // This method builds a connection line string using separators.
        // param separators
        // returns string terminal connection detail.
        public string BuildConnectionFormat(string[] separators)
        {
            string str = "";
            for (int i = 2; i < separators.Length; i++)
            {
                str += separators[i];
                if(i <= markers.Length)
                {
                    str += markers[i-1];
                }
            }
            return str;
        }

        // This method checks if a file line is a terminal detail.
        // param string file line
        // returs boolean true if the line has a terminal.
        public bool IsTerminal(string line) 
        {
            string termStart = starters[1];
            string termEnd = enders[1];
            if(line.Contains(termStart) && line.Contains(termEnd))
            { return true; }
            else{ return false; }            
        }

        // This method reads the terminal ID from a connection string.
        // param string file line
        // returns string terminal ID.
        public string ReadTerminal(string line) 
        {
            string termStart = starters[1];
            string termEnd = enders[1];
            return GetSubstring(line, termStart, termEnd).Trim();
        }

        // This method checks that a line has a connection.
        // param string file line
        // returns boolean true if the line contains a connection.
        public bool HasConnection(string line)
        {
            string connStart = starters[1];
            string connMid = enders[2];
            if (line.Contains(connStart) && line.Contains(connMid))
            { return true; }
            else { return false; }
        }

        // This method checks that a line has two connections.
        // param string file line
        // returns boolean true if the line contains two connections.
        public bool HasTwoConnections(string line)
        {
            string connStart = starters[4];
            string connEnd = enders[5];
            if (line.Contains(connStart))
            {
                return true;
            }
            return false;
        }

        // This method reads the first connection device from a terminal string.
        // param string file line
        // returns string first connection device ID.
        public string ReadConnOneDevice(string line)
        {
            string connOneDevStart = starters[2];
            string connOneDevEnd = enders[2];
            return GetSubstring(line, connOneDevStart, connOneDevEnd).Trim();
        }

        // This method reads the first connection terminal from a terminal string.
        // param string file line
        // returns string first connection terminal ID.
        public string ReadConnOneTerminal(string line)
        {
            string connOneTermStart = starters[3];
            string connOneTermEnd = line.Contains(enders[3]) ? enders[3]: "";
            
            return GetSubstring(line, connOneTermStart, connOneTermEnd).Trim();
        }

        // This method reads the second connection device from a terminal string.
        // param string file line
        // returns string second connection device ID.
        public string ReadConnTwoDevice(string line)
        {
            string connTwoDevStart = starters[4];
            string connTwoDevEnd = enders[4];
            int index = line.IndexOf(connTwoDevStart);
            string str = line.Substring(index);
            return GetSubstring(str, connTwoDevStart, connTwoDevEnd).Trim();
        }

        // This method reads the second connection terminal from a terminal string.
        // param string file line
        // returns string second connection terminal ID.
        public string ReadConnTwoTerminal(string line)
        {
            string connTwoTermStart = starters[5];
            string connTwoTermEnd = enders[5];
            int index = line.LastIndexOf(connTwoTermStart);
            string str = line.Substring(index);
            return GetSubstring(str, connTwoTermStart, connTwoTermEnd).Trim();
        }

        // This method gets a substring between specified starter and ender.
        // param string file line, string starter, string ender
        // returns string between starter and ender characters.
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

        // This method sets the starters and enders arrays to the selected characters.
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

        // This method gets a starter of an index from the format string.
        // params int index of starter, string connection format.
        // returns string starter characters.
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

        // This method gets an ender of an index from the format string.
        // params int index of ender, string connection format.
        // returns string ender characters.
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

        // This method gets the device ID for a destination ID.
        // params string destination
        // returns string device ID of destination.
        public string DestinationDeviceID(string destination)
        {
            string termSep = starters[3];
            if (destination.Contains(termSep))
            {
                int i = destination.IndexOf(termSep);
                return destination.Substring(0, i);
            }
            return destination;
        }

        // This method gets the terminal ID for a destination ID.
        // params string destination
        // returns string terminal ID of destination. 
        public string DestinationTerminalID(string destination)
        {
            string termSep = starters[3];
            if (destination.Contains(termSep))
            {
                int i = destination.IndexOf(termSep);
                return destination.Substring(i+1);
            }
            return destination;
        }

        // This method provides a sample device ID string of the current format.
        // returns string device ID example.
        public string ExampleDevice()
        {
            string name = "AA";
            return starters[0] + name + enders[0];            
        }

        // This method provides a sample terminal detail string of the current format.
        // returns string terminal detail example.
        public string ExampleConnection()
        {
            string termID = "1";
            string dest1dev = "BA";
            string dest1term = "4";
            string dest2dev = "TA";
            string dest2term = "2";
            string[] strings = new string[] { termID, dest1dev, dest1term, dest2dev, dest2term };
            string result = "";
            for (int i = 1; i < starters.Length; i++)
            {
                result += starters[i] + strings[i - 1];
            }
            return result;
        }
    }
}
