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
		public IDictionary<Exercice, IList<AudioFile>> AlreadyImported { get; private set; }  

		PersistedData persisted;
		DirectoryInfo import;

		static Command instance;
		public static Command Instance { get { 
				if (instance == null) {
					instance = new Command();
					instance.Init();
				}
				return instance; 
			} 
		}

		private Command()
		{
			import = new DirectoryInfo("import");
			AlreadyImported = new Dictionary<Exercice, IList<AudioFile>>();
		}

		private void Init()
		{
			persisted = PersistedData.ReadXML("info.xml");
			if (!import.Exists) import.Create();
            ScanImported();
		}

		public void ScanImported()
		{
			AlreadyImported.Clear();

			import
				.EnumerateDirectories()
				.ToList()
				.ForEach(
					(di) => AlreadyImported[persisted.getOrAddExercice(di.Name)] = new List<AudioFile>()
				);

			AlreadyImported
				.Keys
				.ToList()
				.ForEach((Exercice e) =>
					USBDrive.Extensions
				         .ToList()
				         .ForEach((ext) =>
							new DirectoryInfo(Path.Combine(import.FullName, e.Name))
							.GetFiles(ext)
							.Select((FileInfo arg) => new AudioFile(arg))
							.ToList()
							.ForEach((AudioFile a) => AlreadyImported[e].Add(a))));
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
			ScanImported();
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

		public Student GetStudent(string name)
		{
			return persisted.getOrAddStudent(name);
		}

		public Exercice GetExercice(string name)
		{
			return persisted.getOrAddExercice(name);
		}
	}
}
