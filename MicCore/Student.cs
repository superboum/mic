using System;
namespace MicCore
{
	public class Student
	{
		public string Name;

		public Student(){}
		public Student(string name)
		{
			Name = name;
		}

		public override string ToString() => Name;
	}
}
