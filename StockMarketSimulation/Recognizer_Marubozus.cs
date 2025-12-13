using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_Marubozus : Recognizer
    {

        public Recognizer_Marubozus():base("Marubozus", "Bullish Marubozus", "Bearish Marubozus", 1)
        {

      
        }

        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {
            aSmartCandlestick candle = smartCandlesticks[index];

            if (candle.isMarubozus)
            {
                patternIndices.Add(index); 
                if (candle.isBullishMarubozus) variant1Indices.Add(index);
                if (candle.isBearishMarubozus) variant2Indices.Add(index);
                return true;
            }

            return false;


        }

    }
}
