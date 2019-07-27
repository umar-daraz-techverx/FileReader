
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConverter
{
	class Program
	{

		static readonly string textFile = @"C:\Users\UmerDraz\Downloads\Tank\command_22_Jul_2019.txt";
		static void Main(string[] args)
		{
			var FileHelper = new FileHelper();
			FileHelper.FileName = textFile;
			var respone = new ConverterHelper().deviceDataConvetr(FileHelper.ResponseReader().Data);
			Console.ReadKey();

			
		}
	}







	



}
