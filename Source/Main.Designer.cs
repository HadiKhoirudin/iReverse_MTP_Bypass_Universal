using System.IO;
using System.ComponentModel;

//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace iReverse_MTP_Bypass_Universal
{
	public partial class Main : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ButtonIdentify = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonStore = new System.Windows.Forms.RadioButton();
            this.RadioButtonDial = new System.Windows.Forms.RadioButton();
            this.RadioButtonCall = new System.Windows.Forms.RadioButton();
            this.RadioButtonADB = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileManager = new System.Windows.Forms.RadioButton();
            this.RadioButtonSettings = new System.Windows.Forms.RadioButton();
            this.RadioButtonBrowser = new System.Windows.Forms.RadioButton();
            this.RadioButtonYouTube = new System.Windows.Forms.RadioButton();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.BackgroundWorkerMTP = new System.ComponentModel.BackgroundWorker();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonIdentify
            // 
            this.ButtonIdentify.Location = new System.Drawing.Point(6, 19);
            this.ButtonIdentify.Name = "ButtonIdentify";
            this.ButtonIdentify.Size = new System.Drawing.Size(66, 54);
            this.ButtonIdentify.TabIndex = 0;
            this.ButtonIdentify.Text = "Identify";
            this.ButtonIdentify.UseVisualStyleBackColor = true;
            this.ButtonIdentify.Click += new System.EventHandler(this.ButtonIdentify_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.RichTextBox1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(375, 129);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Logs :";
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox1.Location = new System.Drawing.Point(7, 19);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RichTextBox1.Size = new System.Drawing.Size(362, 104);
            this.RichTextBox1.TabIndex = 0;
            this.RichTextBox1.Text = "";
            this.RichTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RadioButtonStore);
            this.GroupBox2.Controls.Add(this.RadioButtonDial);
            this.GroupBox2.Controls.Add(this.RadioButtonCall);
            this.GroupBox2.Controls.Add(this.RadioButtonADB);
            this.GroupBox2.Controls.Add(this.RadioButtonFileManager);
            this.GroupBox2.Controls.Add(this.RadioButtonSettings);
            this.GroupBox2.Controls.Add(this.RadioButtonBrowser);
            this.GroupBox2.Controls.Add(this.RadioButtonYouTube);
            this.GroupBox2.Controls.Add(this.ButtonStart);
            this.GroupBox2.Controls.Add(this.ButtonIdentify);
            this.GroupBox2.Location = new System.Drawing.Point(12, 147);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(375, 107);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Commands : ";
            // 
            // RadioButtonStore
            // 
            this.RadioButtonStore.AutoSize = true;
            this.RadioButtonStore.Enabled = false;
            this.RadioButtonStore.Location = new System.Drawing.Point(290, 79);
            this.RadioButtonStore.Name = "RadioButtonStore";
            this.RadioButtonStore.Size = new System.Drawing.Size(79, 17);
            this.RadioButtonStore.TabIndex = 4;
            this.RadioButtonStore.TabStop = true;
            this.RadioButtonStore.Text = "Open Store";
            this.RadioButtonStore.UseVisualStyleBackColor = true;
            // 
            // RadioButtonDial
            // 
            this.RadioButtonDial.AutoSize = true;
            this.RadioButtonDial.Enabled = false;
            this.RadioButtonDial.Location = new System.Drawing.Point(182, 79);
            this.RadioButtonDial.Name = "RadioButtonDial";
            this.RadioButtonDial.Size = new System.Drawing.Size(94, 17);
            this.RadioButtonDial.TabIndex = 3;
            this.RadioButtonDial.TabStop = true;
            this.RadioButtonDial.Text = "Open Dial Pad";
            this.RadioButtonDial.UseVisualStyleBackColor = true;
            // 
            // RadioButtonCall
            // 
            this.RadioButtonCall.AutoSize = true;
            this.RadioButtonCall.Enabled = false;
            this.RadioButtonCall.Location = new System.Drawing.Point(78, 79);
            this.RadioButtonCall.Name = "RadioButtonCall";
            this.RadioButtonCall.Size = new System.Drawing.Size(71, 17);
            this.RadioButtonCall.TabIndex = 2;
            this.RadioButtonCall.TabStop = true;
            this.RadioButtonCall.Text = "Open Call";
            this.RadioButtonCall.UseVisualStyleBackColor = true;
            // 
            // RadioButtonADB
            // 
            this.RadioButtonADB.AutoSize = true;
            this.RadioButtonADB.Enabled = false;
            this.RadioButtonADB.Location = new System.Drawing.Point(0, 79);
            this.RadioButtonADB.Name = "RadioButtonADB";
            this.RadioButtonADB.Size = new System.Drawing.Size(76, 17);
            this.RadioButtonADB.TabIndex = 2;
            this.RadioButtonADB.TabStop = true;
            this.RadioButtonADB.Text = "Open ADB";
            this.RadioButtonADB.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFileManager
            // 
            this.RadioButtonFileManager.AutoSize = true;
            this.RadioButtonFileManager.Enabled = false;
            this.RadioButtonFileManager.Location = new System.Drawing.Point(182, 50);
            this.RadioButtonFileManager.Name = "RadioButtonFileManager";
            this.RadioButtonFileManager.Size = new System.Drawing.Size(115, 17);
            this.RadioButtonFileManager.TabIndex = 1;
            this.RadioButtonFileManager.TabStop = true;
            this.RadioButtonFileManager.Text = "Open File Manager";
            this.RadioButtonFileManager.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSettings
            // 
            this.RadioButtonSettings.AutoSize = true;
            this.RadioButtonSettings.Enabled = false;
            this.RadioButtonSettings.Location = new System.Drawing.Point(78, 50);
            this.RadioButtonSettings.Name = "RadioButtonSettings";
            this.RadioButtonSettings.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonSettings.TabIndex = 1;
            this.RadioButtonSettings.TabStop = true;
            this.RadioButtonSettings.Text = "Open Settings";
            this.RadioButtonSettings.UseVisualStyleBackColor = true;
            // 
            // RadioButtonBrowser
            // 
            this.RadioButtonBrowser.AutoSize = true;
            this.RadioButtonBrowser.Enabled = false;
            this.RadioButtonBrowser.Location = new System.Drawing.Point(182, 22);
            this.RadioButtonBrowser.Name = "RadioButtonBrowser";
            this.RadioButtonBrowser.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonBrowser.TabIndex = 1;
            this.RadioButtonBrowser.TabStop = true;
            this.RadioButtonBrowser.Text = "Open Browser";
            this.RadioButtonBrowser.UseVisualStyleBackColor = true;
            // 
            // RadioButtonYouTube
            // 
            this.RadioButtonYouTube.AutoSize = true;
            this.RadioButtonYouTube.Checked = true;
            this.RadioButtonYouTube.Enabled = false;
            this.RadioButtonYouTube.Location = new System.Drawing.Point(78, 22);
            this.RadioButtonYouTube.Name = "RadioButtonYouTube";
            this.RadioButtonYouTube.Size = new System.Drawing.Size(98, 17);
            this.RadioButtonYouTube.TabIndex = 1;
            this.RadioButtonYouTube.TabStop = true;
            this.RadioButtonYouTube.Text = "Open YouTube";
            this.RadioButtonYouTube.UseVisualStyleBackColor = true;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Enabled = false;
            this.ButtonStart.Location = new System.Drawing.Point(303, 19);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(66, 54);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // BackgroundWorkerMTP
            // 
            this.BackgroundWorkerMTP.WorkerReportsProgress = true;
            this.BackgroundWorkerMTP.WorkerSupportsCancellation = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 269);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iReverse MTP Bypass Universal V2.0 - @HadiK IT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Closing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		internal Button ButtonIdentify;
		internal GroupBox GroupBox1;
		internal GroupBox GroupBox2;
		internal RadioButton RadioButtonFileManager;
		internal RadioButton RadioButtonSettings;
		internal RadioButton RadioButtonBrowser;
		internal RadioButton RadioButtonYouTube;
		internal Button ButtonStart;
		internal RichTextBox RichTextBox1;
		internal System.ComponentModel.BackgroundWorker BackgroundWorkerMTP;
        internal RadioButton RadioButtonStore;
        internal RadioButton RadioButtonDial;
        internal RadioButton RadioButtonCall;
        internal RadioButton RadioButtonADB;
    }

}