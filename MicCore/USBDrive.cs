using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MicCore
{
	public class USBDrive
	{
		public string Drive { get; }
		public string TotalFreeSpace { get; private set; }
		public string VolumeLabel { get; private set;}
		public IList<AudioFile> AudioFiles { get; private set; }

		protected DriveInfo driveInfo;

		public USBDrive(string drive)
		{
			Drive = drive;
			driveInfo = new DriveInfo(@drive);
			Refresh();
		}

		public void Refresh()
		{
			Update();
			SearchAudioFiles();
		}

		protected void Update() {
			TotalFreeSpace = driveInfo.TotalFreeSpace.ToString();
			VolumeLabel = driveInfo.VolumeLabel;
		}

		protected void SearchAudioFiles()
		{
			AudioFiles = new List<AudioFile>();
			PopulateAudioFiles(driveInfo.RootDirectory);
		}

		protected void PopulateAudioFiles(DirectoryInfo di)
		{
			string[] extensions = { "*.mp3", "*.wav"}; // Is not case sensitive
			try
			{
				extensions.ToList().ForEach(
					(ext) => di.GetFiles(ext).ToList().ForEach(
						(file) => AudioFiles.Add(new AudioFile(file))
					)
				);

				di.GetDirectories().ToList().ForEach(
					(dir) => PopulateAudioFiles(dir)
				);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
