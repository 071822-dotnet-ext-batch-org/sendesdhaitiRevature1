using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Game : Player
    {
        //This class represents the Game model class
        public Guid GameID = Guid.NewGuid();
        //Can directly reference Play becuase in the same name space
        public DateTime DATEPLAYED {get;set;} = DateTime.Now;
        public Player GameWinner {get; set;} = new Player();
        public int GameTies {get; set;}
        public Gamepiece gamePieces {get;set;}
        public List<Round> Rounds {get;set;} = new List<Round>();
         public Player Player1 {get;set;} = new Player();
        public Player Player2 {get;set;} = new Player("Mutant347", "Micheal", "Scott");
        public Game(){
            
        }
        
    }
}