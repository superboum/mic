using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace MicCore
{
	public class PersistedData
	{
		public List<Student> Students { get; private set; }
		public List<Exercice> Exercices { get; private set; }

		[XmlIgnore]
		public bool Dirty { get; private set; }

		public PersistedData()
		{
			Students = new List<Student>();
			Exercices = new List<Exercice>();
			Dirty = false;
		}

		public Student getOrAddStudent(string name)
		{
			var student = Students.Find((s) => s.Name == name);
			if (student == null)
			{
				Dirty = true;
				student = new Student(name);
				Students.Add(student);
			}
			return student;
		}

		public Exercice getOrAddExercice(string name)
		{
			var exercice = Exercices.Find((e) => e.Name == name);
			if (exercice == null)
			{
				Dirty = true;
				exercice = new Exercice(name);
				Exercices.Add(exercice);
			}
			return exercice;
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
			if (data.Dirty)
			{
				data.Dirty = false;
				var writer = new XmlSerializer(typeof(PersistedData));
				var file = File.Create(path);

				writer.Serialize(file, data);
				file.Close();
			}
		}
	}
}
