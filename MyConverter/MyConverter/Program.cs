
using MyConverter.Services;
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
			new DeviceDataService().RemoveAndAdd(new ConverterHelper().deviceDataConvetr(new FileHelper(textFile).ResponseReader().Data));
			Console.WriteLine("response Save Succesfully.....");
			Console.ReadKey();

			
		}
	}







	



}
