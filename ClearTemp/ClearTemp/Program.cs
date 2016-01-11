using System;
using System.IO;

namespace ClearTemp
{
	class Program
	{
		static void Main(string[] args)
		{
			//string path = Environment.CurrentDirectory;
			string path = @"C: \Users\zhaoz\Documents\GitHubVisualStudio";

			DirFolder(path, "x64");
			DirFolder(path, "debug");
			DirFolder(path, ".vs");
			DirFolder(path, "bin");
			DirFolder(path, "obj");
			DeleteFile(path, "sdf");
			Console.ReadLine();
		}

		public static void DirFolder(string path, string dir)
		{
			foreach (string d in Directory.GetFileSystemEntries(path))
			{
				if (!File.Exists(d))
				{
					string[] array = d.Split(new char[] { '\\' });
					string end = array[array.Length - 1];
					if (end == dir)
					{
						DeleteFolder(d);
						Console.WriteLine(d);
					}
					DirFolder(d, dir);
				}
			}
		}

		public static void DeleteFile1(string path)
		{
			foreach (string d in Directory.GetFileSystemEntries(path))
			{
				if (File.Exists(d))
				{
					string[] array = d.Split(new char[] { '.' });
					string fileend = array[array.Length - 1];
				
					try
					{
						File.Delete(d);
						Console.WriteLine(d);
					}
					catch (Exception ex) { }
				}
				else
				{
					DeleteFile1(d);
				}
			}
		}

		public static void DeleteFile(string path, string filefilter)
		{
			foreach (string d in Directory.GetFileSystemEntries(path))
			{
				if (File.Exists(d))
				{
					string[] array = d.Split(new char[] { '.' });
					string fileend = array[array.Length - 1];
					if (fileend.ToLower() == filefilter)
					{
						try
						{
							File.Delete(d);
							Console.WriteLine(d);
						}
						catch (Exception ex) { }
					}
				}
				else
				{
					DeleteFile(d, filefilter);
				}
			}
		}

		public static void DeleteFolder(string dir)
		{
			foreach (string d in Directory.GetFileSystemEntries(dir))
			{
				if (File.Exists(d))
				{
					FileInfo fi = new FileInfo(d);
					if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
					{
						fi.Attributes = FileAttributes.Normal;
					}
					try
					{
						File.Delete(d);
						Console.WriteLine(d);
					}
					catch (Exception ex) { }
				}
				else
				{
					DeleteFolder(d);////递归删除子文件夹
				}
				try
				{
					Directory.Delete(d);
					Console.WriteLine(d);
				}
				catch (Exception ex) { }
			}
		}
	}
}
