using System;
using System.Collections.Generic;
using System.Management;

namespace MicCore
{
	public class MonitorUSBDrives
	{
		public event EventHandler DriveChange;

		public enum EventType
		{
			Inserted = 2,
			Removed = 3
		}

		public class DriveChangeArgs : EventArgs
		{
			public USBDrive Drive { get; }
			public string DriveName { get; }
			public EventType Type { get; }
			public DriveChangeArgs(USBDrive drive, string driveName, EventType type) {
				Drive = drive;
				DriveName = driveName;
				Type = type;
			}
		}

		public Dictionary<string,USBDrive> ConnectedUSBDrives { get; }

		// Not portable...
		// Source : https://stackoverflow.com/a/35588443
		public MonitorUSBDrives()
		{
			ConnectedUSBDrives = new Dictionary<string,USBDrive>();

			ManagementEventWatcher watcher = new ManagementEventWatcher();
			WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");

			watcher.EventArrived += handleVolumeChange;
			watcher.Query = query;
            watcher.Start();
		}

		protected void addUSBDrive(string driveName)
		{
			var drive = new USBDrive(driveName);
			ConnectedUSBDrives.Add(driveName, drive);
			if (DriveChange != null)
				DriveChange(this, new DriveChangeArgs(drive, driveName, EventType.Inserted));
		}

		protected void removeUSBDrive(string driveName) 
		{
			ConnectedUSBDrives.Remove(driveName);
			if (DriveChange != null)
				DriveChange(this, new DriveChangeArgs(null, driveName, EventType.Removed));
		}

		public void handleVolumeChange(object sender, EventArrivedEventArgs e)
		{
			string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
			EventType eventType = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

			switch (eventType)
			{
				case EventType.Inserted:
					addUSBDrive(driveName);
					break;
				case EventType.Removed:
					removeUSBDrive(driveName);
					break;
			}
		}

		public static void handleDriveChange(object o, EventArgs e)
		{
			var ev = e as DriveChangeArgs;
			Console.WriteLine("New event {0}", ev.Type.ToString());
			if (ev.Drive != null)
			{
				Console.WriteLine("Detected files {0}", ev.Drive.AudioFiles.Count);
				foreach (var file in ev.Drive.AudioFiles)
				{
					Console.WriteLine("{0} - {1} - {2}", file.FullName, file.Length, file.DirectoryName);
					try
					{
						System.IO.File.Move(@file.FullName, @"C:\Users\Azrael\Documents\Downloads\" + file.Name);
					}
					catch (System.IO.IOException err)
					{
						Console.WriteLine("Fichier corrompu {0}", err.ToString());
						try
						{
							System.IO.File.Delete(@file.FullName);
						}
						catch (Exception err2)
						{
							Console.WriteLine(err2.ToString());
						}
					}
					catch (UnauthorizedAccessException err) {
						Console.WriteLine("Problème de permissions {0}", err.ToString());
					}
					catch (Exception err)
					{
						Console.WriteLine(err.ToString());
					}
				}
			}
		}

		static void Main(string[] args)
		{
			var monitor = new MonitorUSBDrives();
			monitor.DriveChange += handleDriveChange;
			Console.ReadKey();
		}
	}
}
