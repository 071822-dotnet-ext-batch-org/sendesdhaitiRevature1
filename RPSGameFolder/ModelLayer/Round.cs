using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Round
    {
        //This class represents the Round model class
        private int roundNumber {get;set;} = 0;
        public int RoundNumber{
            get{
                return this.roundNumber;
            }
            set{
                this.roundNumber = roundNumber++;
            }
        }
    }
}