//BY HADI KHOIRUDIN, S.Kom.
using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Management;

namespace iReverse_MTP_Bypass_Universal
{
	internal static class iReverse
	{
		public static string PackDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)) + "\\" + "PackDir";
		public static string PackDirX64 = PackDir + "\\" + "amd64";
		public static string PackDirX86 = PackDir + "\\" + "x86";
		public static string url = "";
		public static string DeviceName = "";
		public static string Drivers = "";
		public static string Manufacturer = "";
		public static string DeviceID = "";
		public static string ClassGuid = "";
		public static string VID = "";
		public static string PID = "";
		public static string VID_PID = "";

		public static void Delay(double dblSecs)
		{
			DateTime.Now.AddSeconds(0.0000115740740740741d);
			var dateTime = DateTime.Now.AddSeconds(0.0000115740740740741d);
			var dateTime1 = dateTime.AddSeconds(dblSecs);
			while (DateTime.Compare(DateTime.Now, dateTime1) <= 0)
				Application.DoEvents();
		}

		public static void RichLogs(string msg, Color colour, bool isBold, bool NextLine = false)
		{
			Main.SharedUI.RichTextBox1.Invoke(new MethodInvoker(() =>
			{
											  Main.SharedUI.RichTextBox1.SelectionStart = Main.SharedUI.RichTextBox1.Text.Length;
											  Color selectionColor = Main.SharedUI.RichTextBox1.SelectionColor;
											  Main.SharedUI.RichTextBox1.SelectionColor = colour;
											  if (isBold)
											  {
												  Main.SharedUI.RichTextBox1.SelectionFont = new Font(Main.SharedUI.RichTextBox1.Font, FontStyle.Bold);
											  }
											  else
											  {
												  Main.SharedUI.RichTextBox1.SelectionFont = new Font(Main.SharedUI.RichTextBox1.Font, FontStyle.Regular);
											  }
											  Main.SharedUI.RichTextBox1.AppendText(msg);
											  Main.SharedUI.RichTextBox1.SelectionColor = selectionColor;
											  if (NextLine)
											  {
												  if (Main.SharedUI.RichTextBox1.TextLength > 0)
												  {
													  Main.SharedUI.RichTextBox1.AppendText("\r\n");
												  }
											  }
			}));
		}
		public static bool FindUSBMTP()
		{
			try
			{
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE PNPClass LIKE '%WPD%' ");
				foreach (ManagementObject queryObj in searcher.Get())
				{
					if (!string.IsNullOrEmpty(queryObj["Name"].ToString()))
					{
						DeviceName = Convert.ToString(queryObj["Name"]);
						Manufacturer = Convert.ToString(queryObj["Manufacturer"]);
						DeviceID = Convert.ToString(queryObj["DeviceID"]);
						ClassGuid = Convert.ToString(queryObj["ClassGuid"]).ToUpper();

						string[] _strArrays = DeviceID.Split(new char[] {'\\'});

						string[] __strArrays = _strArrays[1].Split(new char[] {'&'});

						if (__strArrays[0] != "WPDBUSENUM")
						{ 
						VID = __strArrays[0];
						PID = __strArrays[1];
						VID_PID = VID + "&" + PID;

						RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);
						RichLogs("                           FOUND MTP USB DEVICE                         ", Color.Green, true, true);
						RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);
						RichLogs("Device Name : " + DeviceName, Color.Black, false, true);
						RichLogs("Vendor Name : " + Manufacturer, Color.Black, false, true);
						RichLogs("Device ID       : " + DeviceID, Color.Black, false, true);
						RichLogs("Device GUID  : " + ClassGuid, Color.Black, false, true);

						return true;
						}
					}
				}
				RichLogs(" ", Color.Black, false, true);
				RichLogs(" ", Color.Black, false, true);
				RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);
				RichLogs("                       CAN'T FOUND MTP USB DEVICE                       ", Color.Crimson, true, true);
				RichLogs("------------------------------------------------------------------------------------------------------------------------", Color.Black, false, true);

				Delay(5);

				Main.wellcome();

				return false;
			}
			catch (ManagementException err)
			{

				return false;
			}
		}
		public static void MTPFiles(BackgroundWorker worker, DoWorkEventArgs e)
		{
			if (!Directory.Exists(PackDir))
			{
				Directory.CreateDirectory(PackDir);
				File.WriteAllBytes(PackDir + "\\cyggcc_s-1.dll", Properties.Resources.cyggcc_s_1);
				File.WriteAllBytes(PackDir + "\\cyggcs_s-1.dll", Properties.Resources.cyggcs_s_1);
				File.WriteAllBytes(PackDir + "\\cygusb-1.0.dll", Properties.Resources.cygusb_1_0);
				File.WriteAllBytes(PackDir + "\\cygwin1.dll", Properties.Resources.cygwin1);
				File.WriteAllBytes(PackDir + "\\install_x64.exe", Properties.Resources.install_x64);
				File.WriteAllBytes(PackDir + "\\install_x86.exe", Properties.Resources.install_x86);
				File.WriteAllBytes(PackDir + "\\linux-adk.exe", Properties.Resources.linux_adk);
			}
			
			if (!Directory.Exists(PackDirX64))
			{
				Directory.CreateDirectory(PackDirX64);
				File.WriteAllBytes(PackDirX64 + "\\libusb-1.0_x86.dll", Properties.Resources.amd64_libusb_1_0_x86);
				File.WriteAllBytes(PackDirX64 + "\\libusb0.dll", Properties.Resources.amd64_libusb0);
				File.WriteAllBytes(PackDirX64 + "\\libusb0.sys", Properties.Resources.amd64_libusb0_sys);
				File.WriteAllBytes(PackDirX64 + "\\libusb0_x86.dll", Properties.Resources.amd64_libusb0_x86);
				File.WriteAllBytes(PackDirX64 + "\\libusbK.dll", Properties.Resources.amd64_libusbK);
				File.WriteAllBytes(PackDirX64 + "\\libusbK.sys", Properties.Resources.amd64_libusbK_sys);
				File.WriteAllBytes(PackDirX64 + "\\WdfCoInstaller01009.dll", Properties.Resources.amd64_WdfCoInstaller01009);
				File.WriteAllBytes(PackDirX64 + "\\WdfCoInstaller01011.dll", Properties.Resources.amd64_WdfCoInstaller01011);
				File.WriteAllBytes(PackDirX64 + "\\winusbcoinstaller2.dll", Properties.Resources.amd64_winusbcoinstaller2);
			}
			if (!Directory.Exists(PackDirX86))
			{
				Directory.CreateDirectory(PackDirX86);
				File.WriteAllBytes(PackDirX86 + "\\libusb0.dll", Properties.Resources.x86_libusb0);
				File.WriteAllBytes(PackDirX86 + "\\libusb0.sys", Properties.Resources.x86_libusb0_sys);
				File.WriteAllBytes(PackDirX86 + "\\libusb0_x86.dll", Properties.Resources.x86_libusb0_x86);
				File.WriteAllBytes(PackDirX86 + "\\libusbK.dll", Properties.Resources.x86_libusbK);
				File.WriteAllBytes(PackDirX86 + "\\libusbK.sys", Properties.Resources.x86_libusbK_sys);
				File.WriteAllBytes(PackDirX86 + "\\WdfCoInstaller01009.dll", Properties.Resources.x86_WdfCoInstaller01009);
				File.WriteAllBytes(PackDirX86 + "\\WdfCoInstaller01011.dll", Properties.Resources.x86_WdfCoInstaller01011);
				File.WriteAllBytes(PackDirX86 + "\\winusbcoinstaller2.dll", Properties.Resources.x86_winusbcoinstaller2);
			}
			

			if (File.Exists(PackDir + "\\SAMSUNG_Android.inf"))
			{
				File.Delete(PackDir + "\\SAMSUNG_Android.inf");
			}
			
			if (File.Exists(PackDir + "\\SAMSUNG_Android.cat"))
			{
				File.Delete(PackDir + "\\SAMSUNG_Android.cat");
				File.WriteAllBytes(PackDir + "\\SAMSUNG_Android.cat", Properties.Resources.cat_SAMSUNG_Android);
			}
			
			if (File.Exists(PackDir + "\\SAMSUNG.cat"))
			{
				File.Delete(PackDir + "\\SAMSUNG.cat");
				File.WriteAllBytes(PackDir + "\\SAMSUNG.cat", Properties.Resources.cat_SAMSUNG);
			}

			Console.WriteLine(";");
			Console.WriteLine(";++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

			string Inf = "";
			if (Manufacturer.ToLower().Contains("andromax"))
			{
				Inf = Properties.Resources.SAMSUNG_Android.Replace("#DeviceName#", DeviceName).Replace("#Manufacturer#", Manufacturer).Replace("#DeviceID#", VID_PID).Replace("#ClassGuid#", ClassGuid);
			}
			else if (Manufacturer.ToLower().Contains("infinix"))
			{
				Inf = Properties.Resources.SAMSUNG_Android.Replace("#DeviceName#", DeviceName).Replace("#Manufacturer#", Manufacturer).Replace("#DeviceID#", VID_PID).Replace("#ClassGuid#", ClassGuid);
			}
			else if (Manufacturer.ToLower().Contains("xiaomi"))
			{
				Inf = Properties.Resources.SAMSUNG_Android.Replace("#DeviceName#", DeviceName).Replace("#Manufacturer#", Manufacturer).Replace("#DeviceID#", VID_PID).Replace("#ClassGuid#", ClassGuid);
			}
			else
			{
				Inf = Properties.Resources.SAMSUNG.Replace("#DeviceName#", DeviceName).Replace("#Manufacturer#", Manufacturer).Replace("#DeviceID#", VID_PID).Replace("#ClassGuid#", ClassGuid);
			}

			Console.WriteLine(Inf);
			Console.WriteLine(";");
			Console.WriteLine(";++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

			using (TextWriter writer = new StreamWriter(PackDir + "\\SAMSUNG_Android.inf", false, System.Text.Encoding.UTF8))
			{
				writer.NewLine = "\n";
				writer.Write(Inf.ToString());
			}
		}
		public static bool LinuxAdk(string cmd, BackgroundWorker worker, DoWorkEventArgs ee)
		{
			bool flag = true;
			Console.WriteLine("");
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Linux-adk Command : " + PackDir + "\\linux-adk.exe" + cmd);
			ProcessStartInfo LinuxAdkExe = new ProcessStartInfo(PackDir + "\\linux-adk.exe", cmd)
			{
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = false,
				Verb = "runas",
				WorkingDirectory = PackDir,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};

			using (Process process = Process.Start(LinuxAdkExe))
			{
				Console.WriteLine(cmd);
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

				if (worker.CancellationPending)
				{
					process.Dispose();
					ee.Cancel = true;

				}
				else
				{
					process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
					{
														   string args = e.Data ?? string.Empty;

														   if (!string.IsNullOrEmpty(args))
														   {
															   Console.WriteLine(args);
															   if (args.Contains("Unable to open device..."))
															   {
																   flag = false;
															   }
															   else if (args.Contains("Error getting protocol"))
															   {
																   flag = false;
															   }
														   }
					};

					process.WaitForExit();
				}
			}
			Console.WriteLine("");
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			return flag;
		}
		public static bool Driver(string cmd, BackgroundWorker worker, DoWorkEventArgs ee)
		{
			bool flag = true;
			string installler = null;

			if (Environment.Is64BitOperatingSystem)
			{
				installler = "\\install_x64.exe ";
			}
			else
			{
				installler = "\\install_x86.exe ";
			}

			Console.WriteLine("");
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Driver Command : " + PackDir + installler + cmd);

			ProcessStartInfo DriverExe = new ProcessStartInfo(PackDir + installler, cmd)
			{
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = false,
				Verb = "runas",
				WorkingDirectory = PackDir,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};

			using (Process process = Process.Start(DriverExe))
			{
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine(cmd);
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

				if (worker.CancellationPending)
				{
					process.Dispose();
					ee.Cancel = true;

				}
				else
				{
					process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
					{
														   string args = e.Data ?? string.Empty;

														   if (!string.IsNullOrEmpty(args))
														   {
															   Console.WriteLine(args);
														   }
					};
					process.WaitForExit();
				}
			}
			Console.WriteLine("");
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			return flag;
		}
		public static void ProcessKill()
		{
			string[] array = new string[] {"adb", "adb.exe", "fastboot", "fastboot.exe", "install_x86", "install_x86.exe", "install_x64", "install_x64.exe", "linux-adk", "linux-adk.exe"};

			foreach (string text in array)
			{
				Process[] processes = Process.GetProcesses();

				foreach (Process process in processes)
				{

					if (process.ProcessName.ToLower() == text.ToLower())
					{
						process.Kill();
						process.WaitForExit();
						process.Dispose();
					}
				}

			}
		}
		public static void Cleaner()
		{
			if (File.Exists(PackDir + "\\linux-adk.exe"))
			{
				DirectoryInfo directory = new DirectoryInfo(Path.GetDirectoryName(PackDir + "\\linux-adk.exe"));
				foreach (FileInfo File in directory.EnumerateFiles())
				{
					File.Delete();
				}
				foreach (DirectoryInfo subDirectory in directory.EnumerateDirectories())
				{
					subDirectory.Delete(true);
				}
				directory.Delete(true);
			}
		}
	}

}