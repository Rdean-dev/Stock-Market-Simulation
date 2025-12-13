using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_EngulfingPattern : Recognizer
    {

        public Recognizer_EngulfingPattern():base("Engulfing Pattern", "Bullish Engulfing Pattern", "Bearish Engulfing Pattern", 2)
        {

        }
        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {
            if (index == 0) return false;

            aSmartCandlestick previous = smartCandlesticks[index - 1];
            aSmartCandlestick current = smartCandlesticks[index];

            
            bool isEngulfing = current.topOfBody >= previous.topOfBody && current.bottomOfBody <= previous.bottomOfBody &&
                               current.bodyRange > previous.bodyRange;

            if (isEngulfing)
            {
                patternIndices.Add(index);
                if (previous.isBearish && current.isBullish) variant1Indices.Add(index); 
                if (previous.isBullish && current.isBearish) variant2Indices.Add(index); 
            }

            return isEngulfing;
        }

    }
}
