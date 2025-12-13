using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public class Recognizer_Doji : Recognizer
    {

        public Recognizer_Doji():base("Doji", "Dragonfly Doji", "Gravestone Doji", 1)
        {

      
        }

        override public bool recognize(List<aSmartCandlestick> smartCandlesticks, int index)
        {

            aSmartCandlestick c = smartCandlesticks[index];

            if (c.isDoji)
            {
                patternIndices.Add(index);
                if (c.isDragonflyDoji) variant1Indices.Add(index);
                if (c.isGravestoneDoji) variant2Indices.Add(index);
                return true;
            }

            return false;

        }

    }
}
