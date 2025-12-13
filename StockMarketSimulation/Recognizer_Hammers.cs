using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_Hammers : Recognizer
    {

        public Recognizer_Hammers():base("Hammers", "Bullish Hammers", "Bearish Hammers", 1)
        {

      
        }

        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {
            aSmartCandlestick candle = smartCandlesticks[index];

            if (candle.isHammers)
            {
                patternIndices.Add(index);
                if (candle.isBullishHammers) variant1Indices.Add(index);
                if (candle.isBearishHammers) variant2Indices.Add(index);
                return true;
            }

            return false; 
        }

    }
}
