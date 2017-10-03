﻿using System;
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
		public IList<FileInfo> AudioFiles { get; private set; }

		protected DriveInfo driveInfo;

		public USBDrive(string drive)
		{
			Drive = drive;
			driveInfo = new DriveInfo(@drive);
			AudioFiles = new List<FileInfo>();
			Update();
			SearchAudioFiles();
		}

		public void Update() {
			TotalFreeSpace = driveInfo.TotalFreeSpace.ToString();
			VolumeLabel = driveInfo.VolumeLabel;
		}

		protected void PopulateAudioFiles(DirectoryInfo di)
		{
			string[] extensions = { "*.mp3", "*.wav"}; // Is not case sensitive
			extensions.ToList().ForEach(
				(ext) => di.GetFiles(ext).ToList().ForEach(
					(file) => AudioFiles.Add(file)
				)
			);
			
			di.GetDirectories().ToList().ForEach(
				(dir) => PopulateAudioFiles(dir)
			);
		}

		public void SearchAudioFiles()
		{
			PopulateAudioFiles(driveInfo.RootDirectory);
		}
	}
}
