using System;
using System.IO;
using System.Globalization;

namespace MicCore
{
	public class AudioFile
	{

		public FileInfo File { get; private set; }
		public bool Selected { get; set; }
		public string ImportedName { get; private set; }
		public Student AssociatedStudent { get; private set; }
		public DateTime AssociatedDatetime { get; private set; }
		public string OriginalFileName { get; private set; }

		CultureInfo provider;
		string dateFormat;

		public AudioFile(FileInfo file)
		{
			File = file;
			Selected = false;
			provider = CultureInfo.InvariantCulture;
			dateFormat = "yyyy-MM-dd_HH-mm-ss";
			Parse();
		}

		protected void Parse()
		{
			if (File == null) return;
			string[] fileName = File.Name.Split('.');
			if (fileName.Length < 4) return;

			AssociatedStudent = Command.Instance.GetStudent(fileName[0]);
			AssociatedDatetime = DateTime.ParseExact(fileName[1], dateFormat, provider);
			OriginalFileName = fileName[2] + "." + fileName[3];
		}

		public AudioFile SetImportedName(Student s, Exercice e)
		{
			ImportedName = 
				 s.Name
				 + "."
				 + DateTime.Now.ToString(dateFormat)
				 + "."
				 + File.Name;

			ImportedName = Path.Combine(e.Name, ImportedName);

			return this;
		}

		public string HumanReadableSize()
		{
			// Source: https://stackoverflow.com/a/4975942
			long byteCount = File.Length;
			string[] suf = { " o", " Ko", " Mo", " Go", " To", " Po", " Eo" }; //Longs run out around EB
			if (byteCount == 0)
				return "0" + suf[0];
			long bytes = Math.Abs(byteCount);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);
			return (Math.Sign(byteCount) * num).ToString() + suf[place];
		}
	}
}
