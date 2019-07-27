using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConverter.Context
{
	public class ConvertContext : DbContext
	{
		public ConvertContext() : base("Data Source=.;Initial Catalog=DeviceDB;Integrated Security=True")
		{

		}
		public DbSet<DeviceData> DeviceData { get; set; }
	}
}
