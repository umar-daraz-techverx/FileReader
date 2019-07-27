using MyConverter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConverter.Services
{
	public class DeviceDataService
	{
		private readonly ConvertContext _convertContext = null;
		public DeviceDataService()
		{
			_convertContext = new ConvertContext();		
		}

		public void RemoveAndAdd(DeviceData deviceData)
		{
			if (_convertContext.DeviceData.Any())
			{
				_convertContext.DeviceData.Remove(_convertContext.DeviceData.ToList().FirstOrDefault());
			}
			_convertContext.DeviceData.Add(deviceData);
			_convertContext.SaveChanges();
		}
	
	}
}
