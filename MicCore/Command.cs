using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MicCore
{
	public class Command
	{
		public IList<Student> Students { get { return persisted.Students; } }
		public IList<Exercice> Exercices { get { return persisted.Exercices; } }

		DirectoryInfo import;
		PersistedData persisted;

		public Command()
		{
			persisted = PersistedData.ReadXML("info.xml");
			import = new DirectoryInfo("import");
			if (!import.Exists) import.Create();
		}

		public void Import(string student, string ex, USBDrive drive)
		{
			var files = drive.AudioFiles;
			Student s = persisted.getOrAddStudent(student);
			Exercice e = persisted.getOrAddExercice(ex);
			SavePersistedData();

			files
				.Where((AudioFile a) => a.Selected).ToList()
				.Select((AudioFile a) => a.SetImportedName(s,e)).ToList()
				.ForEach((AudioFile a) => ImportFile(a));

			drive.Refresh();
		}

		protected void ImportFile(AudioFile a)
		{
			var source = a.File.FullName;
			var destination = Path.Combine(import.FullName, a.ImportedName);

			var destFi = new FileInfo(destination);
			if (!destFi.Directory.Exists) destFi.Directory.Create();

			File.Move(source, destination);
		}

		public void SavePersistedData()
		{
			PersistedData.WriteXML("info.xml", persisted);
		}
	}
}
