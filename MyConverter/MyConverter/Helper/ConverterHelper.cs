using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConverter
{
	public class ConverterHelper
	{
		/// <summary>
		/// Convert Pseudo IP address to System No
		/// </summary>
		/// <param name="ip"> Pseudo IP address, if you receive 0x37, 0xE3, 0x00, 0x A0, then please give param value55.227.0.160</param>
		/// <returns>System No</returns>
		public static string IPToNumber(string ip)
		{
			long iHight = 0;
			string sTemp = null;
			try
			{
				string[] sIp = ip.Split(new char[] { '.' }, 4);
				byte[] bSimNo = new byte[sIp.Length];
				for (int i = 0; i < bSimNo.Length; i++)
				{
					bSimNo[i] = Convert.ToByte(sIp[i]);
				}
				if ((bSimNo[0] & 0x80) != 0)
				{
					iHight = iHight + 8;
				}
				bSimNo[0] = Convert.ToByte(bSimNo[0] & 0x7F);
				if ((bSimNo[1] & 0x80) != 0)
				{
					iHight = iHight + 4;
				}
				bSimNo[1] = Convert.ToByte(bSimNo[1] & 0x7F);
				if ((bSimNo[2] & 0x80) != 0)
				{
					iHight = iHight + 2;

				}
				bSimNo[2] = Convert.ToByte(bSimNo[2] & 0x7F);
				if ((bSimNo[3] & 0x80) != 0)
				{
					iHight = iHight + 1;
				}
				bSimNo[3] = Convert.ToByte(bSimNo[3] & 0x7F);
				sTemp = "1" + Convert.ToString(30 + iHight) + bSimNo[0].ToString("00")
					+ bSimNo[1].ToString("00") + bSimNo[2].ToString("00") + bSimNo[3].ToString("00");
			}
			catch
			{
				sTemp = null;
			}
			return sTemp;
		}

		/// <summary>
		/// Convert System No to Pseudo IP address
		/// </summary>
		/// <param name="sim">System No, for example: 13555990032</param>
		/// <returns> Pseudo IP address</returns>
		public string NumToIp(string sim)
		{
			string[] Temp = new string[4];
			int iHigt;
			switch (sim.Length)
			{
				case 11:
					Temp[0] = sim.Substring(3, 2);
					Temp[1] = sim.Substring(5, 2);
					Temp[2] = sim.Substring(7, 2);
					Temp[3] = sim.Substring(9, 2);
					iHigt = Convert.ToInt32(sim.Substring(1, 2)) - 30;
					break;
				case 10:
					Temp[0] = sim.Substring(2, 2);
					Temp[1] = sim.Substring(4, 2);
					Temp[2] = sim.Substring(6, 2);
					Temp[3] = sim.Substring(8, 2);
					iHigt = Convert.ToInt32(sim.Substring(0, 2)) - 30;
					break;
				case 9:
					Temp[0] = sim.Substring(1, 2);

					Temp[1] = sim.Substring(3, 2);
					Temp[2] = sim.Substring(5, 2);
					Temp[3] = sim.Substring(7, 2);
					iHigt = Convert.ToInt32(sim.Substring(0, 1));
					break;
				default:
					switch (sim.Length)
					{
						case 8:
							return NumToIp("140" + sim);
						case 7:
							return NumToIp("1400" + sim);
						case 6:
							return NumToIp("14000" + sim);
						case 5:
							return NumToIp("140000" + sim);
						case 4:
							return NumToIp("1400000" + sim);
						case 3:
							return NumToIp("14000000" + sim);
						case 2:
							return NumToIp("140000000" + sim);
						case 1:
							return NumToIp("1400000000" + sim);
						default:
							return "";
					}

			}
			int[] sIp = new int[4];

			if ((iHigt & 0x08) != 0)
				sIp[0] = Convert.ToInt32(Temp[0]) | 128;
			else
				sIp[0] = Convert.ToInt32(Temp[0]);

			if ((iHigt & 0x04) != 0)
				sIp[1] = Convert.ToInt32(Temp[1]) | 128;
			else
				sIp[1] = Convert.ToInt32(Temp[1]);

			if ((iHigt & 0x02) != 0)
				sIp[2] = Convert.ToInt32(Temp[2]) | 128;
			else

				sIp[2] = Convert.ToInt32(Temp[2]);

			if ((iHigt & 0x01) != 0)
				sIp[3] = Convert.ToInt32(Temp[3]) | 128;
			else
				sIp[3] = Convert.ToInt32(Temp[3]);

			return sIp[0] + "." + sIp[1] + "." + sIp[2] + "." + sIp[3];
		}

		/// <summary>
		/// Get calibration value
		/// </summary>
		/// <param name="tmp">the whole package data</param>
		/// <param name="len">the length which will be used to calculate the calibration value </param>
		/// <returns> calibration value </returns>
		public static byte GetCheckXor(byte[] tmp, int len)
		{
			byte A = 0;
			for (int i = 0; i < len; i++)
			{
				A ^= tmp[i];
			}
			return A;
		}

		/// <summary>
		/// Convert System No to Pseudo IP address
		/// </summary>
		/// <param name="sim">System No, for example: 13 55 59 90 032</param>
		/// <returns> Pseudo IP address</returns>
		public static string HexToIP(string ip)
		{
			var mylisr = ip.Split(' ');
			string returnIP = "";
			foreach (var item in mylisr)
			{
				returnIP = returnIP+"."+Convert.ToInt32(item, 16);
			}
			return returnIP.Substring(1, returnIP.Length-1);
		}
		
		public static string LocationConveter(string location)
		{
			//006 degree 36.518 minute=6.0+36.518/60.00=6.60863
			int count = 0;
			string head = "";
			string tail = "";
			int tailcount = 0;
			foreach (var item in location)
			{
				if(count<3)
				{
					head += item;
				}
				else
				{
					if (tailcount == 2)
					{
						tail = tail+"."+item;
					}
					else
					{
						tail += item;
					}
					tailcount++;
				}
				count++;
			}
			head = Reverse(head);
			head = head.Insert(1, ".");
			return ""+(Convert.ToDouble(head) + (Convert.ToDouble(tail) / 60.00));
		}

		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public DeviceData deviceDataConvetr(string data)
		{
			var dd = new DeviceData();
			var tempres = data.Split(' ');
			dd.Header = tempres[0] + " " + tempres[1];
			dd.MainOrder = tempres[2];
			dd.Length = tempres[3] + " " + tempres[4];
			dd.PseudoIPaddress = tempres[5] + " " + tempres[6] + " " + tempres[7] + " " + tempres[8];
			dd.Date = tempres[9] + tempres[10] + tempres[11];
			dd.Time = tempres[12] + tempres[13] + tempres[14];
			dd.Latitude = tempres[15] + tempres[16] + tempres[17] + tempres[18];
			dd.Longitude = tempres[19] + tempres[20] + tempres[21] + tempres[22];
			dd.Speed = tempres[23] + tempres[24];
			dd.Angle = tempres[25] + tempres[26];
			dd.GPSstatus = tempres[27];
			dd.Detectionsettingstatus = tempres[28];
			dd.Ignitionstatus = tempres[29];
			dd.Oilresistance = Convert.ToInt32(tempres[30], 16) + "" + Convert.ToInt32(tempres[31], 16);
			dd.Voltage = "";
			dd.Mileage = "";
			dd.Temperature = "";
			dd.Calibration = "";
			dd.Footer = tempres[tempres.Count() - 2];
			dd.DeviceNumber = ConverterHelper.IPToNumber(ConverterHelper.HexToIP(dd.PseudoIPaddress));
			dd.Lat = ConverterHelper.LocationConveter(dd.Latitude);
			dd.Lan = ConverterHelper.LocationConveter(dd.Longitude);
			return dd;
		}
	}
}
