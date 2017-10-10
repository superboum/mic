using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace MicCore
{
	public class PersistedData
	{
		public List<Student> Students;
		public List<Exercice> Exercices;

		public PersistedData()
		{
			Students = new List<Student>();
			Exercices = new List<Exercice>();
		}

		public static PersistedData ReadXML(string path)
		{
			var reader = new XmlSerializer(typeof(PersistedData));
			if (File.Exists(path))
			{
				var file = new StreamReader(path);
				var data = reader.Deserialize(file) as PersistedData;
				file.Close();
				return data == null ? new PersistedData() : data;
			}
			return new PersistedData();
		}

		public static void WriteXML(string path, PersistedData data)
		{
			var writer = new XmlSerializer(typeof(PersistedData));
			var file = File.Create(path);

			writer.Serialize(file, data);
			file.Close();
		}
	}
}
