using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MicCore
{
	public class USBDrive
	{
        public static string[] Extensions = { "*.mp3", "*.wav" }; // Is not case sensitive
		public string Drive { get; }
		public string TotalFreeSpace { get; private set; }
		public string VolumeLabel { get; private set;}
		public IList<AudioFile> AudioFiles { get; private set; }

		protected DriveInfo driveInfo;

		public USBDrive(string drive)
		{
			Drive = drive;
			driveInfo = new DriveInfo(@drive);
			AudioFiles = new List<AudioFile>();
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
			AudioFiles.Clear();
			PopulateAudioFiles(driveInfo.RootDirectory);
		}

		protected void PopulateAudioFiles(DirectoryInfo di)
		{
			try
			{
				USBDrive.Extensions.ToList().ForEach(
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
