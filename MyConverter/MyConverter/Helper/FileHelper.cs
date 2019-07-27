using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConverter
{
	public class FileHelper
	{
		private string FileName { get; set; }
		public FileHelper(string fileName)
		{
			this.FileName = fileName;
		}
		public Response ResponseReader()
		{
			string[] lines = File.ReadAllLines(FileName);
			var mydata = new List<Response>();
			var currentme = DateTime.Now;
			Response device = null;
			var totallines = lines.Length - 6;
			foreach (string line in lines)
			{
				if (line.Contains("80"))
				{
					device = new Response();
					device.Data = line;
					mydata.Add(device);
				}

			}
			return mydata[mydata.Count - 1] ?? null;
		}
	}
}
