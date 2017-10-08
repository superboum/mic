using System;
using MicCore;
using System.Collections.Generic;

namespace Mic
{
	public class ManageImportWindow
	{
		IDictionary<string, Gtk.Window> windows;

		public ManageImportWindow()
		{
			windows = new Dictionary<string, Gtk.Window>();
			var monitor = new MonitorUSBDrives();
			monitor.DriveChange += HandleDriveChange;
		}

		void OpenWindow(MonitorUSBDrives.DriveChangeArgs ev)
		{
			Gtk.Application.Invoke(delegate
			{
				ImportWindow iw = new ImportWindow(ev.Drive);
				iw.Show();
				windows.Add(ev.DriveName, iw);
			});
		}

		void CloseWindow(MonitorUSBDrives.DriveChangeArgs ev)
		{
			Gtk.Application.Invoke(delegate
			{
				if (windows.ContainsKey(ev.DriveName)) {
					var iw = windows[ev.DriveName];
					windows.Remove(ev.DriveName);
					iw.Hide();
					iw.Destroy();
				}
			});
		}

		void HandleDriveChange(object sender, EventArgs e)
		{
			MonitorUSBDrives.DriveChangeArgs ev = e as MonitorUSBDrives.DriveChangeArgs;
			if (ev.Type == MonitorUSBDrives.EventType.Inserted)
			{
				OpenWindow(ev);
			}
			else if (ev.Type == MonitorUSBDrives.EventType.Removed)
			{
				CloseWindow(ev);
			}
		}
	}
}
