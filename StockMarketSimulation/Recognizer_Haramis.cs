using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_Haramis : Recognizer
    {

        public Recognizer_Haramis():base("Haramis", "Bullish Haramis", "Bearish Haramais", 2)
        {

      
        }

        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {
            if (index == 0) return false;

            aSmartCandlestick previous = smartCandlesticks[index - 1];
            aSmartCandlestick current = smartCandlesticks[index];

            bool isHarami = current.topOfBody <= previous.topOfBody && current.bottomOfBody >= previous.bottomOfBody;



            if (isHarami)
            {
                patternIndices.Add(index);
                if(current.isBullish) variant1Indices.Add(index);
                if(current.isBearish) variant2Indices.Add(index);
            }

            return isHarami;



        }

    }
}
