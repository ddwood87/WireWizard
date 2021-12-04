using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using WireWizard;
namespace DiagramForm
{
    public partial class DiagramForm : Form
    {
        WireWizard.WireWizard w;
        string filePath;
        string errorString;
        
        //int wireCount;
        public DiagramForm()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = dialog.FileName;
                w = null;
            }
            UpdateFields();
        }

        private void WireDevices_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath) || !filePath.Substring(filePath.Length - 4).Equals(".txt"))
            {
                errorString = "You must select a '.txt' file for input.";
            }
            else {
                if(w == null) { w = new WireWizard.WireWizard(filePath); }                
                List<string> lines = new List<string>();
                string str = w.NoCallBackReport();
                str += w.DupDeviceReport();
                if (string.IsNullOrEmpty(str))
                {
                    str = "There were no errors to report.";
                }
                errorString = str;
                
            }
            UpdateFields();
        }
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
                w.WireSchedule(compareKey);
            }
            UpdateFields();
        }
        private void OpenSchedule_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = @w.ScheduleFilePath;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
    }
}
