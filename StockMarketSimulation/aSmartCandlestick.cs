using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Market_Simulation
{
    public class aSmartCandlestick : aCandlestick
    {

        public Boolean isBullish;
        public Boolean isBearish;
        public Boolean isNeutral;
        public Boolean isDoji;
        public Boolean isDragonflyDoji;
        public Boolean isGravestoneDoji;
        public Boolean isBullishDoji;
        public Boolean isBearishDoji;
        public Boolean isMarubozus;
        public Boolean isBullishMarubozus;
        public Boolean isBearishMarubozus;
        
        public Boolean isHammers;
        public Boolean isBullishHammers;
        public Boolean isBearishHammers;
        
        public Boolean isInvertedHammers;
        public Boolean isBullishInvertedHammers;
        public Boolean isBearishInvertedHammers;
        public Decimal range;
        public Decimal bodyRange;
        public Decimal upperTailRange;
        public Decimal lowerTailRange;
        public Decimal topOfBody;
        public Decimal bottomOfBody;

        public void computeProperties() 
        { 
            isBullish = Close > Open;
            isBearish = Close < Open;
            isNeutral = Close == Open;

            topOfBody = Math.Max(Open, Close);
            bottomOfBody = Math.Min(Open, Close);
            range = High - Low;
            bodyRange = Math.Abs(Open - Close);
            upperTailRange = High - topOfBody;
            lowerTailRange = bottomOfBody - Low;

            isDoji = 20 * bodyRange <= range;
            isDragonflyDoji = isDoji && upperTailRange == 0 && lowerTailRange > bodyRange && topOfBody == High ;
            isGravestoneDoji = isDoji && lowerTailRange == 0 && upperTailRange > bodyRange && bottomOfBody == Low;

            isMarubozus = upperTailRange <= 0.05m * range && lowerTailRange <= 0.05m * range;


            isBullishMarubozus = isMarubozus && isBullish;
            isBearishMarubozus = isMarubozus && isBearish;

            isHammers = lowerTailRange >= 2 * bodyRange && upperTailRange <= 0.3m * bodyRange;
            isBullishHammers = isHammers && isBullish;
            isBearishHammers = isHammers && isBearish;


            isInvertedHammers = upperTailRange >= 2 * bodyRange && lowerTailRange <= bodyRange;
            isBullishInvertedHammers = isInvertedHammers && isBullish;
            isBearishInvertedHammers = isInvertedHammers && isBearish;





        }


        public aSmartCandlestick(): base()
        {
            computeProperties();
        }
        
        public aSmartCandlestick(string line): base(line) 
        {
            computeProperties();
        }

        public aSmartCandlestick(DateTime Date, decimal Open, decimal High, decimal Low, decimal Close, ulong Volume) : base(Date, Open, High, Low, Close, Volume)
        {
            computeProperties();
        }

        public aSmartCandlestick(aCandlestick cs): base(cs) 
        {
            computeProperties();
        }

        public aSmartCandlestick(aSmartCandlestick scs) : base(scs)
        {
            isBullish = scs.isBullish;
            isBearish = scs.isBearish;
            isNeutral = scs.isNeutral;

            range = scs.range;
            bodyRange = scs.bodyRange;
            upperTailRange = scs.upperTailRange;
            lowerTailRange = scs.lowerTailRange;
            topOfBody = scs.topOfBody;
            bottomOfBody = scs.bottomOfBody;
            computeProperties();
        }
    }
}
