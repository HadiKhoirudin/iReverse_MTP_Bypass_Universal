//BY HADI KHOIRUDIN, S.Kom.
using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace iReverse_MTP_Bypass_Universal
{
	public partial class Main
	{
		internal static Main SharedUI;
		public string Operation = "";
		public Main()
		{
			InitializeComponent();
			SharedUI = this;
		}

		public static void wellcome()
		{
			iReverse.RichLogs(" ", Color.Black, true, true);
			iReverse.RichLogs("► Software  " + "\t" + ": ", Color.Black, true, false);
			iReverse.RichLogs("MTP Bypass Universal V2.0", Color.Black, true, true);
			iReverse.RichLogs("► License  " + "\t" + ": ", Color.Black, true, false);
			iReverse.RichLogs("Freeware", Color.Black, true, true);
			iReverse.RichLogs("► Developer  " + "\t" + ": ", Color.Black, true, false);
			iReverse.RichLogs("Hadi Khoirudin, S.Kom", Color.Black, true, true);
			iReverse.RichLogs("  ==================================================", Color.Black, true, true);
			iReverse.RichLogs("► Websites  " + "\t" + ":  https://hadikhoirudin.github.io", Color.Black, true, true);
			iReverse.RichLogs("  ==================================================", Color.Black, true, true);
			iReverse.RichLogs("Note : ", Color.Black, false, true);
			iReverse.RichLogs("Make sure no adb.exe proccess running before click start.", Color.Black, false, false);

		}

		private void RichTextBox1_TextChanged(object sender, EventArgs e)
		{
			RichTextBox1.Invoke(new MethodInvoker(() =>
			{
								RichTextBox1.SelectionStart = RichTextBox1.Text.Length;
								RichTextBox1.ScrollToCaret();
			}));
		}

		private void Main_Closing(object sender, EventArgs e)
		{
			iReverse.ProcessKill();
			iReverse.Cleaner();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			wellcome();
			RadioButtonYouTube.Enabled = false;
			RadioButtonBrowser.Enabled = false;
			RadioButtonSettings.Enabled = false;
			RadioButtonADB.Enabled = false;
			RadioButtonCall.Enabled = false;
			RadioButtonDial.Enabled = false;
			RadioButtonStore.Enabled = false;
			RadioButtonFileManager.Enabled = false;

			ButtonStart.Enabled = false;
			iReverse.ProcessKill();
			iReverse.Cleaner();
		}

		private void ButtonIdentify_Click(object sender, EventArgs e)
		{
			RichTextBox1.Clear();

			if (iReverse.FindUSBMTP())
			{
				RadioButtonYouTube.Enabled = true;
				RadioButtonBrowser.Enabled = true;
				RadioButtonSettings.Enabled = true;
				RadioButtonADB.Enabled = true;
				RadioButtonCall.Enabled = true;
				RadioButtonDial.Enabled = true;
				RadioButtonStore.Enabled = true;
				RadioButtonFileManager.Enabled = true;

				ButtonStart.Enabled = true;

			}
			else
			{
				RadioButtonYouTube.Enabled = false;
				RadioButtonBrowser.Enabled = false;
				RadioButtonSettings.Enabled = false;
				RadioButtonADB.Enabled = false;
				RadioButtonCall.Enabled = false;
				RadioButtonDial.Enabled = false;
				RadioButtonStore.Enabled = false;
				RadioButtonFileManager.Enabled = false;

				ButtonStart.Enabled = false;

			}
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			iReverse.ProcessKill();
			RichTextBox1.Clear();

			iReverse.url = "";
			if (RadioButtonYouTube.Checked)
			{
				iReverse.url = "https://www.youtube.com/account_privacy";
				Operation = "Open YouTube";

			}
			else if (RadioButtonBrowser.Checked)
			{
				if (iReverse.Manufacturer.ToLower().Contains("samsung"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#samsung-browser";
				}
				else if (!iReverse.Manufacturer.ToLower().Contains("xiaomi") || !iReverse.Manufacturer.ToLower().Contains("samsung"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#xiaomi-browser";
				}
				else
				{
					iReverse.url = "https://hadikhoirudin.github.io/#universal-browser";
				}
				Operation = "Open Browser";

			}
			else if (RadioButtonSettings.Checked)
			{

				iReverse.url = "https://hadikhoirudin.github.io/#universal-settings";
				Operation = "Open Settings";

			}
			else if (RadioButtonFileManager.Checked)
			{
				if (iReverse.Manufacturer.ToLower().Contains("samsung"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#samsung-files";
				}
				else if (iReverse.Manufacturer.ToLower().Contains("xiaomi"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#xiaomi-files";
				}
				else
				{
					iReverse.url = "https://hadikhoirudin.github.io/#universal-files";
				}

				Operation = "Open File Manager";
			}
			
			else if (RadioButtonADB.Checked)
			{
				if (iReverse.Manufacturer.ToLower().Contains("samsung"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#samsung-adb";
				}
				else if (iReverse.Manufacturer.ToLower().Contains("xiaomi"))
				{
					iReverse.url = "https://hadikhoirudin.github.io/#xiaomi-adb";
				}
				else
				{
					iReverse.url = "https://hadikhoirudin.github.io/#universal-adb";
				}

				Operation = "Open ADB Settings";
			}
			else if (RadioButtonCall.Checked)
			{
				iReverse.url = "https://hadikhoirudin.github.io/#universal-call";
				Operation = "Open Caller";
			}
			
			else if (RadioButtonDial.Checked)
			{
				iReverse.url = "https://hadikhoirudin.github.io/#universal-call";
				Operation = "Open Dialer";
			}
			
			else if (RadioButtonStore.Checked)
			{

				if (iReverse.Manufacturer.ToLower().Contains("samsung"))
                {
                    iReverse.url = "https://hadikhoirudin.github.io/#samsung-store";
                }
                else if (iReverse.Manufacturer.ToLower().Contains("xiaomi"))
                {
                    iReverse.url = "https://hadikhoirudin.github.io/#xiaomi-store";
                }
                else
                {
                    iReverse.url = "https://hadikhoirudin.github.io/#universal-store";
                }

				Operation = "Open Store";
			}

			if (!string.IsNullOrEmpty(iReverse.url))
			{
				BackgroundWorkerMTP = new BackgroundWorker();
				BackgroundWorkerMTP.WorkerSupportsCancellation = true;
				BackgroundWorkerMTP.WorkerReportsProgress = true;
				BackgroundWorkerMTP.DoWork += MTPWorker;
				BackgroundWorkerMTP.RunWorkerCompleted += Completed;
				BackgroundWorkerMTP.RunWorkerAsync();
			}
		}

		private void MTPWorker(object sender, DoWorkEventArgs e)
		{
			string command = "-d " + "\"" + iReverse.VID.Replace("VID_", "").ToLower() + ":" + iReverse.PID.Replace("PID_", "").ToLower() + "\"" + " -D " + "\"" + "iReverse MTP Bypass Universal V2.0 \n@HadiK IT - [Hadi Khoirudin, S. Kom]" + "\"" + " -u " + "\"" + iReverse.url + "\"";
			iReverse.ProcessKill();
			iReverse.MTPFiles(BackgroundWorkerMTP, e);

			iReverse.RichLogs("Installing driver ... ", Color.Black, false, false);
			iReverse.Driver("install --inf=" + "\"" + iReverse.PackDir + "\\SAMSUNG_Android.inf" + "\"", BackgroundWorkerMTP, e);
			iReverse.RichLogs("[OK]", Color.Green, false, true);


			iReverse.RichLogs("Starting MTP Bypass Services ... ", Color.Black, false, false);
			if (!iReverse.LinuxAdk(command, BackgroundWorkerMTP, e))
			{
				iReverse.RichLogs("[Failed]", Color.Red, false, true);
			}
			else
			{
				iReverse.RichLogs("[OK]", Color.Green, false, true);
				iReverse.RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);
				iReverse.RichLogs("      SUCCESS!   PLEASE CHECK YOUR DEVICE SCREEN.                       ", Color.Blue, true);
				iReverse.RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);

				iReverse.Delay(3);

				wellcome();
			}

			iReverse.Driver("uninstall --inf=" + "\"" + iReverse.PackDir + "\\SAMSUNG_Android.inf" + "\"", BackgroundWorkerMTP, e);

		}

		private void Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			RadioButtonYouTube.Enabled = false;
			RadioButtonBrowser.Enabled = false;
			RadioButtonSettings.Enabled = false;
			RadioButtonADB.Enabled = false;
			RadioButtonCall.Enabled = false;
			RadioButtonDial.Enabled = false;
			RadioButtonStore.Enabled = false;
			RadioButtonFileManager.Enabled = false;

			ButtonStart.Enabled = false;

			iReverse.ProcessKill();
			iReverse.Cleaner();
		}

		private static Main _DefaultInstance;
		public static Main DefaultInstance
		{
			get
			{
				if (_DefaultInstance == null || _DefaultInstance.IsDisposed)
					_DefaultInstance = new Main();

				return _DefaultInstance;
			}
		}
	}

}