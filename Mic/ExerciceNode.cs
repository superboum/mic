using System;
namespace Mic
{
	[Gtk.TreeNode(ListOnly = true)]
	public class ExerciceNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue(Column = 0)]
		public string Name { get; }

		[Gtk.TreeNodeValue(Column = 1)]
		public int StudentNumber { get; }

		[Gtk.TreeNodeValue(Column = 2)]
		public int FilesNumber { get; }

		public ExerciceNode(string name, int studentNumber, int filesNumber)
		{
			Name = name;
			StudentNumber = studentNumber;
			FilesNumber = filesNumber;
		}
	}
}
