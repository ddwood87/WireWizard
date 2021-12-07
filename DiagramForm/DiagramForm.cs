using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using WireWizard.Contoller;

namespace DiagramForm
{
    public partial class DiagramForm : Form
    {
        WireWizard.WireWizard w;
        DiagramFormatter df;
        string[] chars;
        string filePath;
        string errorString;
        
        // Constructor initializes new form. and creates formatter, sets format to default.
        public DiagramForm()
        {
            df = new DiagramFormatter();
            InitializeComponent();            
            DefaultFormat();
        }

        // This method runs when the 'Browse' button is clicked.
        // An open file dialogue is opened to select a file path.
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                if (!dialog.FileName.Equals(this.filePath))
                {
                    this.filePath = dialog.FileName;
                    w = null;
                }                
            }            
            UpdateFields();
        }

        // This method runs when the 'Point-to-Point Check' button is clicked.
        // This action builds the diagram and reports problems.
        private void WireDevices_Click(object sender, EventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(filePath) || !filePath.Substring(filePath.Length - 4).Equals(".txt"))
                {
                    errorString = "You must select a '.txt' file for input.";
                }
                else {
                    if (w == null) { w = new WireWizard.WireWizard(filePath, df); }
                    string str = w.NoCallBackReport();
                    str += w.DupDeviceReport();
                    if (string.IsNullOrEmpty(str))
                    {
                        str = "There were no errors to report.";
                    }
                    errorString = str;
                }
            }
            catch (Exception ex)
            {
                // Message user if diagram build fails.
                errorString = "The format entered does not match some of your diagram.";
            }
            UpdateFields();
        }

        // This method runs when the 'Create Wire Schedule' button is clicked.
        // Wire list is sorted according to radio buttons and writes to a file.
        private void WireSchedule_Click(object sender, EventArgs e)
        {
            int compareKey = 0;
            {
                if (radioWireID.Checked)
                {
                    compareKey = 0;
                }
                else if(radioOriginID.Checked)
                {
                    compareKey = 1;
                }
                else if (radioDestID.Checked)
                {
                    compareKey = 2;
                }
                w.WireScheduleSort(compareKey);
                w.WriteWireFile();
            }
            UpdateFields();
        }

        // This method runs when the 'Open File' button is clicked.
        // The text file is opened for viewing.
        private void OpenSchedule_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = @w.ScheduleFilePath;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        // This method runs when the 'Default' button is clicked.
        // The diagram format is set to default.
        private void defaultFormatButton_Click(object sender, EventArgs e)
        {
            DefaultFormat();
            UpdateFields();
        }

        // This method runs when the 'Set Format' button is clicked.
        // The format is set as the user has entered.
        private void setFormatButton_Click(object sender, EventArgs e)
        {
            AssignChars();
            df.DeviceFormat = df.BuildDeviceFormat(chars);
            df.ConnectionFormat = df.BuildConnectionFormat(chars);
            UpdateFields();
        }

        // Helper method to set default format.
        public void DefaultFormat()
        {
            df.DefaultFormat();
            chars = df.GetSeparators();
        }

        // Helper method to set chars array.
        private void AssignChars()
        {
            chars = new string[]{ char0.Text,
                                  char1.Text,
                                  char2.Text,
                                  char3.Text,
                                  char4.Text,
                                  char5.Text,
                                  char6.Text,
                                  char7.Text };            
        }

        // This method updates fields that are shown to the view.
        private void UpdateFields()
        {
            char0.Text = chars[0];
            char1.Text = chars[1];
            char2.Text = chars[2];
            char3.Text = chars[3];
            char4.Text = chars[4];
            char5.Text = chars[5];
            char6.Text = chars[6];
            char7.Text = chars[7];
            fileTextBox.Text = filePath;
            errorTextBox.Text = errorString;
            deviceExample.Text = df.ExampleDevice();
            connectionExample.Text = df.ExampleConnection();
            if (w != null)
            {
                wireCountLabel.Text = "Wire Count: " + w.Diagram.WireCount.ToString();
                wireCountLabel.Visible = true;
                if (w.ScheduleFilePath != null)
                {
                    wireScheduleFile.Text = w.ScheduleFilePath;
                    wireScheduleFile.Visible = true;
                    openScheduleButton.Visible = true;
                }
            }
            else
            {
                wireCountLabel.Visible = false;
                wireScheduleFile.Visible = false;
                openScheduleButton.Visible = false;
            }
        }
        
        // This method runs when the clear button is pressed.
        // Clears fields to default.
        private void clearButton_Click(object sender, EventArgs e)
        {
            filePath = "";
            errorString = "";
            w = null;
            chars = null;
            DefaultFormat();
            UpdateFields();
        }
    }
}
