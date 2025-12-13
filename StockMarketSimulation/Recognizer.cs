using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market_Simulation
{
    public abstract class Recognizer
    {
        //constructor that takes string for patternname pn and pattern size ps
        
        public int patternSize;
        public string patternName;
        public List<int> patternIndices;
        public string patternVariant1;
        public string patternVariant2;
        public List<int> variant1Indices;
        public List<int> variant2Indices;

        public Recognizer()
        {
            patternSize = 0;
            patternName = "?!";
            patternVariant1 = "?!";
            patternVariant2 = "?!";
            patternIndices = new List<int>();
            variant1Indices = new List<int>();
            variant2Indices = new List<int>();
        }

        public Recognizer(string pn, string pv1, string pv2, int ps)
        {
            patternSize = ps;
            patternName = pn;
            patternVariant1 = pv1;
            patternVariant2 = pv2;
            patternIndices = new List<int>();
            variant1Indices = new List<int>();
            variant2Indices = new List<int>();

        }

        public abstract bool recognize(List<aSmartCandlestick> smartCandlestick, int index);
    }
}
