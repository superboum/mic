using System;
using System.Collections.Generic;

namespace MicCore
{
	public class Command
	{
		public IList<Student> Students { get { return persisted.Students; } }
		public IList<Exercice> Exercices { get { return persisted.Exercices; } }

		private PersistedData persisted;

		public Command()
		{
			persisted = PersistedData.ReadXML("info.xml");
		}

		public void SavePersistedData()
		{
			PersistedData.WriteXML("info.xml", persisted);
		}
	}
}
