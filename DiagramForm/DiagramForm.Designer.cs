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
            this.deviceID = new System.Windows.Forms.Label();
            this.char0 = new System.Windows.Forms.TextBox();
            this.char1 = new System.Windows.Forms.TextBox();
            this.char2 = new System.Windows.Forms.TextBox();
            this.char7 = new System.Windows.Forms.TextBox();
            this.char6 = new System.Windows.Forms.TextBox();
            this.char5 = new System.Windows.Forms.TextBox();
            this.char4 = new System.Windows.Forms.TextBox();
            this.char3 = new System.Windows.Forms.TextBox();
            this.terminalID = new System.Windows.Forms.Label();
            this.dest1Device = new System.Windows.Forms.Label();
            this.dest1Terminal = new System.Windows.Forms.Label();
            this.dest2Device = new System.Windows.Forms.Label();
            this.dest2Terminal = new System.Windows.Forms.Label();
            this.deviceFormatLabel = new System.Windows.Forms.Label();
            this.termFormatLabel = new System.Windows.Forms.Label();
            this.formatInstructionLabel = new System.Windows.Forms.Label();
            this.defaultFormatButton = new System.Windows.Forms.Button();
            this.setFormatButton = new System.Windows.Forms.Button();
            this.diagramFormatGroup = new System.Windows.Forms.GroupBox();
            this.deviceExample = new System.Windows.Forms.Label();
            this.connectionExample = new System.Windows.Forms.Label();
            this.exampleDescription = new System.Windows.Forms.Label();
            this.exampleGroup = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.wireSortRadio.SuspendLayout();
            this.diagramFormatGroup.SuspendLayout();
            this.exampleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(437, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.Browse_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(91, 29);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(324, 23);
            this.fileTextBox.TabIndex = 1;
            // 
            // wireDevicesButton
            // 
            this.wireDevicesButton.Location = new System.Drawing.Point(84, 157);
            this.wireDevicesButton.Name = "wireDevicesButton";
            this.wireDevicesButton.Size = new System.Drawing.Size(148, 23);
            this.wireDevicesButton.TabIndex = 2;
            this.wireDevicesButton.Text = "Point-to-Point Check";
            this.wireDevicesButton.UseVisualStyleBackColor = true;
            this.wireDevicesButton.Click += new System.EventHandler(this.WireDevices_Click);
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(84, 186);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(251, 207);
            this.errorTextBox.TabIndex = 3;
            this.errorTextBox.Text = "";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 33);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(73, 15);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "Diagram File";
            // 
            // errorListLabel
            // 
            this.errorListLabel.AutoSize = true;
            this.errorListLabel.Location = new System.Drawing.Point(12, 189);
            this.errorListLabel.Name = "errorListLabel";
            this.errorListLabel.Size = new System.Drawing.Size(53, 15);
            this.errorListLabel.TabIndex = 5;
            this.errorListLabel.Text = "Error List";
            // 
            // wireCountLabel
            // 
            this.wireCountLabel.Location = new System.Drawing.Point(374, 378);
            this.wireCountLabel.Name = "wireCountLabel";
            this.wireCountLabel.Size = new System.Drawing.Size(100, 15);
            this.wireCountLabel.TabIndex = 7;
            // 
            // wireScheduleButton
            // 
            this.wireScheduleButton.Location = new System.Drawing.Point(374, 416);
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
            this.wireSortRadio.Location = new System.Drawing.Point(84, 397);
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
            this.wireScheduleFile.Location = new System.Drawing.Point(84, 452);
            this.wireScheduleFile.MinimumSize = new System.Drawing.Size(200, 0);
            this.wireScheduleFile.Name = "wireScheduleFile";
            this.wireScheduleFile.Size = new System.Drawing.Size(200, 15);
            this.wireScheduleFile.TabIndex = 10;
            this.wireScheduleFile.Text = "scheduleFileName";
            this.wireScheduleFile.Visible = false;
            // 
            // openScheduleButton
            // 
            this.openScheduleButton.Location = new System.Drawing.Point(84, 480);
            this.openScheduleButton.Name = "openScheduleButton";
            this.openScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.openScheduleButton.TabIndex = 11;
            this.openScheduleButton.Text = "Open File";
            this.openScheduleButton.UseVisualStyleBackColor = true;
            this.openScheduleButton.Visible = false;
            this.openScheduleButton.Click += new System.EventHandler(this.OpenSchedule_Click);
            // 
            // deviceID
            // 
            this.deviceID.AutoSize = true;
            this.deviceID.Location = new System.Drawing.Point(133, 12);
            this.deviceID.MaximumSize = new System.Drawing.Size(55, 0);
            this.deviceID.MinimumSize = new System.Drawing.Size(55, 30);
            this.deviceID.Name = "deviceID";
            this.deviceID.Size = new System.Drawing.Size(55, 30);
            this.deviceID.TabIndex = 20;
            this.deviceID.Text = "Device ID";
            this.deviceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // char0
            // 
            this.char0.Location = new System.Drawing.Point(107, 17);
            this.char0.MaximumSize = new System.Drawing.Size(20, 4);
            this.char0.MinimumSize = new System.Drawing.Size(20, 4);
            this.char0.Name = "char0";
            this.char0.Size = new System.Drawing.Size(20, 23);
            this.char0.TabIndex = 12;
            this.char0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char1
            // 
            this.char1.Location = new System.Drawing.Point(194, 17);
            this.char1.MaximumSize = new System.Drawing.Size(20, 4);
            this.char1.MinimumSize = new System.Drawing.Size(20, 4);
            this.char1.Name = "char1";
            this.char1.Size = new System.Drawing.Size(20, 23);
            this.char1.TabIndex = 13;
            this.char1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char2
            // 
            this.char2.Location = new System.Drawing.Point(107, 54);
            this.char2.MaximumSize = new System.Drawing.Size(20, 4);
            this.char2.MinimumSize = new System.Drawing.Size(20, 4);
            this.char2.Name = "char2";
            this.char2.Size = new System.Drawing.Size(20, 23);
            this.char2.TabIndex = 14;
            this.char2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char7
            // 
            this.char7.Location = new System.Drawing.Point(542, 56);
            this.char7.MaximumSize = new System.Drawing.Size(20, 4);
            this.char7.MinimumSize = new System.Drawing.Size(20, 4);
            this.char7.Name = "char7";
            this.char7.Size = new System.Drawing.Size(20, 23);
            this.char7.TabIndex = 15;
            this.char7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char6
            // 
            this.char6.Location = new System.Drawing.Point(455, 54);
            this.char6.MaximumSize = new System.Drawing.Size(20, 4);
            this.char6.MinimumSize = new System.Drawing.Size(20, 4);
            this.char6.Name = "char6";
            this.char6.Size = new System.Drawing.Size(20, 23);
            this.char6.TabIndex = 16;
            this.char6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char5
            // 
            this.char5.Location = new System.Drawing.Point(368, 54);
            this.char5.MaximumSize = new System.Drawing.Size(20, 4);
            this.char5.MinimumSize = new System.Drawing.Size(20, 4);
            this.char5.Name = "char5";
            this.char5.Size = new System.Drawing.Size(20, 23);
            this.char5.TabIndex = 17;
            this.char5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char4
            // 
            this.char4.Location = new System.Drawing.Point(281, 54);
            this.char4.MaximumSize = new System.Drawing.Size(20, 4);
            this.char4.MinimumSize = new System.Drawing.Size(20, 4);
            this.char4.Name = "char4";
            this.char4.Size = new System.Drawing.Size(20, 23);
            this.char4.TabIndex = 18;
            this.char4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char3
            // 
            this.char3.Location = new System.Drawing.Point(194, 54);
            this.char3.MaximumSize = new System.Drawing.Size(20, 4);
            this.char3.MinimumSize = new System.Drawing.Size(20, 4);
            this.char3.Name = "char3";
            this.char3.Size = new System.Drawing.Size(20, 23);
            this.char3.TabIndex = 19;
            this.char3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // terminalID
            // 
            this.terminalID.AutoSize = true;
            this.terminalID.Location = new System.Drawing.Point(133, 51);
            this.terminalID.MaximumSize = new System.Drawing.Size(55, 0);
            this.terminalID.MinimumSize = new System.Drawing.Size(55, 30);
            this.terminalID.Name = "terminalID";
            this.terminalID.Size = new System.Drawing.Size(55, 30);
            this.terminalID.TabIndex = 21;
            this.terminalID.Text = "Terminal ID";
            this.terminalID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dest1Device
            // 
            this.dest1Device.AutoSize = true;
            this.dest1Device.Location = new System.Drawing.Point(220, 51);
            this.dest1Device.MaximumSize = new System.Drawing.Size(55, 0);
            this.dest1Device.MinimumSize = new System.Drawing.Size(55, 30);
            this.dest1Device.Name = "dest1Device";
            this.dest1Device.Size = new System.Drawing.Size(55, 30);
            this.dest1Device.TabIndex = 22;
            this.dest1Device.Text = "Dest 1 Device";
            this.dest1Device.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dest1Terminal
            // 
            this.dest1Terminal.AutoSize = true;
            this.dest1Terminal.Location = new System.Drawing.Point(307, 51);
            this.dest1Terminal.MaximumSize = new System.Drawing.Size(55, 0);
            this.dest1Terminal.MinimumSize = new System.Drawing.Size(55, 30);
            this.dest1Terminal.Name = "dest1Terminal";
            this.dest1Terminal.Size = new System.Drawing.Size(55, 30);
            this.dest1Terminal.TabIndex = 23;
            this.dest1Terminal.Text = "Dest 1 Terminal";
            this.dest1Terminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dest2Device
            // 
            this.dest2Device.AutoSize = true;
            this.dest2Device.Location = new System.Drawing.Point(394, 51);
            this.dest2Device.MaximumSize = new System.Drawing.Size(55, 0);
            this.dest2Device.MinimumSize = new System.Drawing.Size(55, 30);
            this.dest2Device.Name = "dest2Device";
            this.dest2Device.Size = new System.Drawing.Size(55, 30);
            this.dest2Device.TabIndex = 24;
            this.dest2Device.Text = "Dest 2 Device";
            this.dest2Device.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dest2Terminal
            // 
            this.dest2Terminal.AutoSize = true;
            this.dest2Terminal.Location = new System.Drawing.Point(481, 51);
            this.dest2Terminal.MaximumSize = new System.Drawing.Size(55, 0);
            this.dest2Terminal.MinimumSize = new System.Drawing.Size(55, 30);
            this.dest2Terminal.Name = "dest2Terminal";
            this.dest2Terminal.Size = new System.Drawing.Size(55, 30);
            this.dest2Terminal.TabIndex = 25;
            this.dest2Terminal.Text = "Dest 2 Terminal";
            this.dest2Terminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceFormatLabel
            // 
            this.deviceFormatLabel.AutoSize = true;
            this.deviceFormatLabel.Location = new System.Drawing.Point(17, 20);
            this.deviceFormatLabel.Margin = new System.Windows.Forms.Padding(0);
            this.deviceFormatLabel.MaximumSize = new System.Drawing.Size(85, 0);
            this.deviceFormatLabel.Name = "deviceFormatLabel";
            this.deviceFormatLabel.Size = new System.Drawing.Size(83, 15);
            this.deviceFormatLabel.TabIndex = 26;
            this.deviceFormatLabel.Text = "Device Format";
            // 
            // termFormatLabel
            // 
            this.termFormatLabel.AutoSize = true;
            this.termFormatLabel.Location = new System.Drawing.Point(7, 59);
            this.termFormatLabel.Margin = new System.Windows.Forms.Padding(0);
            this.termFormatLabel.MaximumSize = new System.Drawing.Size(95, 0);
            this.termFormatLabel.Name = "termFormatLabel";
            this.termFormatLabel.Size = new System.Drawing.Size(93, 15);
            this.termFormatLabel.TabIndex = 27;
            this.termFormatLabel.Text = "Terminal Format";
            // 
            // formatInstructionLabel
            // 
            this.formatInstructionLabel.AutoSize = true;
            this.formatInstructionLabel.Location = new System.Drawing.Point(237, 20);
            this.formatInstructionLabel.Name = "formatInstructionLabel";
            this.formatInstructionLabel.Size = new System.Drawing.Size(346, 15);
            this.formatInstructionLabel.TabIndex = 28;
            this.formatInstructionLabel.Text = "Enter the seperator characters for your diagram or select Default.";
            // 
            // defaultFormatButton
            // 
            this.defaultFormatButton.Location = new System.Drawing.Point(604, 74);
            this.defaultFormatButton.Name = "defaultFormatButton";
            this.defaultFormatButton.Size = new System.Drawing.Size(75, 23);
            this.defaultFormatButton.TabIndex = 29;
            this.defaultFormatButton.Text = "Default";
            this.defaultFormatButton.UseVisualStyleBackColor = true;
            this.defaultFormatButton.Click += new System.EventHandler(this.defaultFormatButton_Click);
            // 
            // setFormatButton
            // 
            this.setFormatButton.Location = new System.Drawing.Point(604, 114);
            this.setFormatButton.Name = "setFormatButton";
            this.setFormatButton.Size = new System.Drawing.Size(75, 23);
            this.setFormatButton.TabIndex = 30;
            this.setFormatButton.Text = "Set Format";
            this.setFormatButton.UseVisualStyleBackColor = true;
            this.setFormatButton.Click += new System.EventHandler(this.setFormatButton_Click);
            // 
            // diagramFormatGroup
            // 
            this.diagramFormatGroup.Controls.Add(this.formatInstructionLabel);
            this.diagramFormatGroup.Controls.Add(this.termFormatLabel);
            this.diagramFormatGroup.Controls.Add(this.deviceFormatLabel);
            this.diagramFormatGroup.Controls.Add(this.dest2Terminal);
            this.diagramFormatGroup.Controls.Add(this.dest2Device);
            this.diagramFormatGroup.Controls.Add(this.dest1Terminal);
            this.diagramFormatGroup.Controls.Add(this.dest1Device);
            this.diagramFormatGroup.Controls.Add(this.terminalID);
            this.diagramFormatGroup.Controls.Add(this.deviceID);
            this.diagramFormatGroup.Controls.Add(this.char3);
            this.diagramFormatGroup.Controls.Add(this.char4);
            this.diagramFormatGroup.Controls.Add(this.char5);
            this.diagramFormatGroup.Controls.Add(this.char6);
            this.diagramFormatGroup.Controls.Add(this.char7);
            this.diagramFormatGroup.Controls.Add(this.char2);
            this.diagramFormatGroup.Controls.Add(this.char1);
            this.diagramFormatGroup.Controls.Add(this.char0);
            this.diagramFormatGroup.Location = new System.Drawing.Point(12, 58);
            this.diagramFormatGroup.Name = "diagramFormatGroup";
            this.diagramFormatGroup.Size = new System.Drawing.Size(586, 93);
            this.diagramFormatGroup.TabIndex = 31;
            this.diagramFormatGroup.TabStop = false;
            this.diagramFormatGroup.Text = "Enter Diagram Format";
            // 
            // deviceExample
            // 
            this.deviceExample.AutoSize = true;
            this.deviceExample.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deviceExample.Location = new System.Drawing.Point(5, 20);
            this.deviceExample.Name = "deviceExample";
            this.deviceExample.Size = new System.Drawing.Size(96, 15);
            this.deviceExample.TabIndex = 32;
            this.deviceExample.Text = "Device Example";
            // 
            // connectionExample
            // 
            this.connectionExample.AutoSize = true;
            this.connectionExample.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.connectionExample.Location = new System.Drawing.Point(5, 44);
            this.connectionExample.Name = "connectionExample";
            this.connectionExample.Size = new System.Drawing.Size(120, 15);
            this.connectionExample.TabIndex = 33;
            this.connectionExample.Text = "Connection Example";
            // 
            // exampleDescription
            // 
            this.exampleDescription.AutoSize = true;
            this.exampleDescription.Location = new System.Drawing.Point(131, 17);
            this.exampleDescription.MaximumSize = new System.Drawing.Size(150, 0);
            this.exampleDescription.Name = "exampleDescription";
            this.exampleDescription.Size = new System.Drawing.Size(118, 45);
            this.exampleDescription.TabIndex = 34;
            this.exampleDescription.Text = "These strings should match your diagram format";
            // 
            // exampleGroup
            // 
            this.exampleGroup.BackColor = System.Drawing.SystemColors.Control;
            this.exampleGroup.Controls.Add(this.exampleDescription);
            this.exampleGroup.Controls.Add(this.connectionExample);
            this.exampleGroup.Controls.Add(this.deviceExample);
            this.exampleGroup.Location = new System.Drawing.Point(394, 186);
            this.exampleGroup.Name = "exampleGroup";
            this.exampleGroup.Size = new System.Drawing.Size(255, 69);
            this.exampleGroup.TabIndex = 35;
            this.exampleGroup.TabStop = false;
            this.exampleGroup.Text = "Example Strings";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(604, 28);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 36;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 515);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.exampleGroup);
            this.Controls.Add(this.defaultFormatButton);
            this.Controls.Add(this.setFormatButton);
            this.Controls.Add(this.diagramFormatGroup);
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
            this.diagramFormatGroup.ResumeLayout(false);
            this.diagramFormatGroup.PerformLayout();
            this.exampleGroup.ResumeLayout(false);
            this.exampleGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label deviceID;
        private TextBox char0;
        private TextBox char1;
        private TextBox char2;
        private TextBox char7;
        private TextBox char6;
        private TextBox char5;
        private TextBox char4;
        private TextBox char3;
        private Label terminalID;
        private Label dest1Device;
        private Label dest1Terminal;
        private Label dest2Device;
        private Label dest2Terminal;
        private Label deviceFormatLabel;
        private Label termFormatLabel;
        private Label formatInstructionLabel;
        private Button defaultFormatButton;
        private Button setFormatButton;
        private GroupBox diagramFormatGroup;
        private Label deviceExample;
        private Label connectionExample;
        private Label exampleDescription;
        private GroupBox exampleGroup;
        private Button clearButton;
    }
}

