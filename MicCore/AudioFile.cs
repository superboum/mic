using System;
using System.IO;

namespace MicCore
{
	public class AudioFile
	{

		public FileInfo File { get; private set; }
		public bool Selected { get; set; }
		public string ImportedName { get; private set; }

		public AudioFile(FileInfo file)
		{
			File = file;
			Selected = false;
		}

		public AudioFile SetImportedName(Student s, Exercice e)
		{
			ImportedName = 
				 s.Name
				 + "."
				 + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
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
