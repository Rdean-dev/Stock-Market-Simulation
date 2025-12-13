using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_InvertedHammers : Recognizer
    {

        public Recognizer_InvertedHammers() : base("Inverted Hammers", "Bullish Inverted Hammers", "Bearish Inverted Hammers", 1)
        {


        }

        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {
            aSmartCandlestick candle = smartCandlesticks[index];

            if (candle.isInvertedHammers)
            {
                patternIndices.Add(index);
                if (candle.isBullishInvertedHammers) variant1Indices.Add(index);
                if (candle.isBearishInvertedHammers) variant2Indices.Add(index);
                return true;
            }

            return false;

        }
    }
}
