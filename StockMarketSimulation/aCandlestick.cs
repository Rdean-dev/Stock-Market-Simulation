using System;
using System.Globalization;


namespace Stock_Market_Simulation
{
	public class aCandlestick
	{

		public DateTime Date { get; set; }
		public decimal Open { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public decimal Close { get; set; }
		public ulong Volume { get; set; }

		private static char[] delmiters = { ',', '"' };

		public aCandlestick() { }

		public aCandlestick(DateTime Date, decimal Open, decimal High, decimal Low, decimal Close, ulong Volume)
		{
			this.Date = Date;
			this.Open = Open;
			this.High = High;
			this.Low = Low;
			this.Close = Close;
			this.Volume = Volume;
		}

		public aCandlestick(aCandlestick otherCandlestick)
		{
			this.Date = otherCandlestick.Date;
			this.Open = otherCandlestick.Open;
			this.High = otherCandlestick.High;
			this.Low = otherCandlestick.Low;
			this.Close = otherCandlestick.Close;
			this.Volume = otherCandlestick.Volume;
		}

		public aCandlestick(string line)
		{
			CultureInfo provider = CultureInfo.InvariantCulture;
			String[] strings = line.Split(delmiters, StringSplitOptions.RemoveEmptyEntries);

			string DateString = strings[2];

			Date = DateTime.ParseExact(DateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			Open = Convert.ToDecimal(strings[3]);
			High = Convert.ToDecimal(strings[4]);
			Low = Convert.ToDecimal(strings[5]);
			Close = Convert.ToDecimal(strings[6]);
			Volume = Convert.ToUInt64(strings[7]);

		}
	}
}
