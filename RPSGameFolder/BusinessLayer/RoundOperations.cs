using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public class RoundOperations
    {
        public static int SetRound(){
            Round round = new Round();
            return round.RoundNumber++;
        }
        
    }
}