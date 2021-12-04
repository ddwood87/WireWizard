using System;
using System.Windows.Forms;
namespace DiagramForm
{
    public partial class DiagramForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.wireDevicesButton = new System.Windows.Forms.Button();
            this.errorTextBox = new System.Windows.Forms.RichTextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.errorListLabel = new System.Windows.Forms.Label();
            this.wireCountLabel = new System.Windows.Forms.Label();
            this.wireScheduleButton = new System.Windows.Forms.Button();
            this.wireSortRadio = new System.Windows.Forms.GroupBox();
            this.radioDestID = new System.Windows.Forms.RadioButton();
            this.radioOriginID = new System.Windows.Forms.RadioButton();
            this.radioWireID = new System.Windows.Forms.RadioButton();
            this.wireScheduleFile = new System.Windows.Forms.Label();
            this.openScheduleButton = new System.Windows.Forms.Button();
            this.wireSortRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(430, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.Browse_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(84, 29);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(324, 23);
            this.fileTextBox.TabIndex = 1;
            // 
            // wireDevicesButton
            // 
            this.wireDevicesButton.Location = new System.Drawing.Point(84, 73);
            this.wireDevicesButton.Name = "wireDevicesButton";
            this.wireDevicesButton.Size = new System.Drawing.Size(148, 23);
            this.wireDevicesButton.TabIndex = 2;
            this.wireDevicesButton.Text = "Point-to-Point Check";
            this.wireDevicesButton.UseVisualStyleBackColor = true;
            this.wireDevicesButton.Click += new System.EventHandler(this.WireDevices_Click);
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(84, 122);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(251, 207);
            this.errorTextBox.TabIndex = 3;
            this.errorTextBox.Text = "";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(5, 33);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(73, 15);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "Diagram File";
            // 
            // errorListLabel
            // 
            this.errorListLabel.AutoSize = true;
            this.errorListLabel.Location = new System.Drawing.Point(13, 122);
            this.errorListLabel.Name = "errorListLabel";
            this.errorListLabel.Size = new System.Drawing.Size(53, 15);
            this.errorListLabel.TabIndex = 5;
            this.errorListLabel.Text = "Error List";
            // 
            // wireCountLabel
            // 
            this.wireCountLabel.Location = new System.Drawing.Point(358, 314);
            this.wireCountLabel.Name = "wireCountLabel";
            this.wireCountLabel.Size = new System.Drawing.Size(100, 15);
            this.wireCountLabel.TabIndex = 7;
            // 
            // wireScheduleButton
            // 
            this.wireScheduleButton.Location = new System.Drawing.Point(379, 352);
            this.wireScheduleButton.Name = "wireScheduleButton";
            this.wireScheduleButton.Size = new System.Drawing.Size(160, 31);
            this.wireScheduleButton.TabIndex = 8;
            this.wireScheduleButton.Text = "Create Wire Schedule";
            this.wireScheduleButton.UseVisualStyleBackColor = true;
            this.wireScheduleButton.Click += new System.EventHandler(this.WireSchedule_Click);
            // 
            // wireSortRadio
            // 
            this.wireSortRadio.Controls.Add(this.radioDestID);
            this.wireSortRadio.Controls.Add(this.radioOriginID);
            this.wireSortRadio.Controls.Add(this.radioWireID);
            this.wireSortRadio.Location = new System.Drawing.Point(84, 335);
            this.wireSortRadio.Name = "wireSortRadio";
            this.wireSortRadio.Size = new System.Drawing.Size(274, 50);
            this.wireSortRadio.TabIndex = 9;
            this.wireSortRadio.TabStop = false;
            this.wireSortRadio.Text = "Sort by";
            // 
            // radioDestID
            // 
            this.radioDestID.AutoSize = true;
            this.radioDestID.Location = new System.Drawing.Point(167, 23);
            this.radioDestID.Name = "radioDestID";
            this.radioDestID.Size = new System.Drawing.Size(99, 19);
            this.radioDestID.TabIndex = 2;
            this.radioDestID.TabStop = true;
            this.radioDestID.Text = "Destination ID";
            this.radioDestID.UseVisualStyleBackColor = true;
            // 
            // radioOriginID
            // 
            this.radioOriginID.AutoSize = true;
            this.radioOriginID.Location = new System.Drawing.Point(87, 23);
            this.radioOriginID.Name = "radioOriginID";
            this.radioOriginID.Size = new System.Drawing.Size(72, 19);
            this.radioOriginID.TabIndex = 1;
            this.radioOriginID.TabStop = true;
            this.radioOriginID.Text = "Origin ID";
            this.radioOriginID.UseVisualStyleBackColor = true;
            // 
            // radioWireID
            // 
            this.radioWireID.AutoSize = true;
            this.radioWireID.Location = new System.Drawing.Point(7, 23);
            this.radioWireID.Name = "radioWireID";
            this.radioWireID.Size = new System.Drawing.Size(63, 19);
            this.radioWireID.TabIndex = 0;
            this.radioWireID.TabStop = true;
            this.radioWireID.Text = "Wire ID";
            this.radioWireID.UseVisualStyleBackColor = true;
            // 
            // wireScheduleFile
            // 
            this.wireScheduleFile.AutoSize = true;
            this.wireScheduleFile.Location = new System.Drawing.Point(84, 399);
            this.wireScheduleFile.Name = "wireScheduleFile";
            this.wireScheduleFile.Size = new System.Drawing.Size(0, 15);
            this.wireScheduleFile.TabIndex = 10;
            this.wireScheduleFile.Visible = false;
            // 
            // openScheduleButton
            // 
            this.openScheduleButton.Location = new System.Drawing.Point(84, 432);
            this.openScheduleButton.Name = "openScheduleButton";
            this.openScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.openScheduleButton.TabIndex = 11;
            this.openScheduleButton.Text = "Open File";
            this.openScheduleButton.UseVisualStyleBackColor = true;
            this.openScheduleButton.Visible = false;
            this.openScheduleButton.Click += new EventHandler(OpenSchedule_Click);
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 466);
            this.Controls.Add(this.openScheduleButton);
            this.Controls.Add(this.wireScheduleFile);
            this.Controls.Add(this.wireSortRadio);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.wireDevicesButton);
            this.Controls.Add(this.errorListLabel);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.wireScheduleButton);
            this.Controls.Add(this.wireCountLabel);
            this.Name = "DiagramForm";
            this.Text = "Wire Wizard";
            this.wireSortRadio.ResumeLayout(false);
            this.wireSortRadio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void UpdateFields()
        {
            this.fileTextBox.Text = this.filePath;
            this.errorTextBox.Text = this.errorString;
            if (w != null)
            {
                this.wireCountLabel.Text = "Wire Count: " + w.Diagram.WireCount.ToString();
                this.wireScheduleFile.Visible = true;
                if(w.ScheduleFilePath != null)
                {
                    wireScheduleFile.Text = w.ScheduleFilePath;
                    wireScheduleFile.Visible = true;
                    openScheduleButton.Visible = true;
                }
            }
        }

        #endregion

        private Button browseButton;
        private TextBox fileTextBox;
        private Button wireDevicesButton;
        private RichTextBox errorTextBox;
        private Label fileNameLabel;
        private Label errorListLabel;
        private Label wireCountLabel;
        private Button wireScheduleButton;
        private GroupBox wireSortRadio;
        private RadioButton radioDestID;
        private RadioButton radioOriginID;
        private RadioButton radioWireID;
        private Label wireScheduleFile;
        private Button openScheduleButton;
    }
}

