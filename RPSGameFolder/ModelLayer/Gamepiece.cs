using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Gamepiece
    {
        //private double value {get;set;}
        public Rock rockPiece {get;set;}
        public Paper paperPiece {get;set;}
        public Scissors scissorPiece {get;set;}
        public Gamepiece(){
            this.rockPiece = new Rock(this);
            this.paperPiece = new Paper(this);
            this.scissorPiece = new Scissors(this);
        }
        public class Rock
        {
            private string RockName = "ROCK";
            public string Name{
                get{
                    return this.RockName;
                }
            }
            public Brick brickClass {get;set;}
            public ROCKS_IN_A_SACK rocks_in_a_sackClass {get;set;}
            private Gamepiece obj;
            public Rock(Gamepiece gamepieceClass){
                obj = gamepieceClass;
                this.brickClass = new Brick(this);
                this.rocks_in_a_sackClass = new ROCKS_IN_A_SACK(this);
            }

            /// <summary>
            /// This is the Rock type: Brick
            /// </summary>
            /// <value></value>
            public class Brick
            {
                //private Rock rockClass = new Rock();
                private string BRICKNAME = "BRICK";
                private double brick = 1.5;
                private Rock obj;
                public Brick(Rock rockClass){
                    obj = rockClass;
                }
                public double BRICK{
                    get{
                        return this.brick;
                    }
                }
                public string Name{
                    get{
                        return this.BRICKNAME;
                    }
                }
            }

            /// <summary>
            /// This is the Rock type: Rocks in a sack
            /// </summary>
            /// <value></value>
            public class ROCKS_IN_A_SACK{
                private string ROCKS_IN_SACKNAME = "ROCKS IN A SACK";
                private double rocks_in_sack = 1.3;
                private Rock obj;
                public ROCKS_IN_A_SACK(Rock rockClass){
                    obj = rockClass;
                }
                public double ROCKS_IN_SACK{
                    get{
                        return this.rocks_in_sack;
                    }
                }
                public string Name{
                    get{
                        return this.ROCKS_IN_SACKNAME;
                    }
                }
            }

            
        }//Rock Class

        public class Paper
        {
            private string PaperName = "PAPER";
            public An_Origami_Dagger daggerPiece {get;set;}
            public Shuriken shurikenPiece {get;set;}
            private Gamepiece obj;

            public Paper(Gamepiece gamepieceClass){
                obj = gamepieceClass;
                this.daggerPiece = new An_Origami_Dagger(this);
                this.shurikenPiece = new Shuriken(this);
            }
            public string Name{
                get{
                    return this.PaperName;
                }
            }

            /// <summary>
            /// This is the Paper type: Origami dagger
            /// </summary>
            /// <value></value>
            public class An_Origami_Dagger
            {
                private string DaggerName = "ORIGAMI DAGGER";
                private double origami_dagger = 2.1;
                private Paper obj;

                public An_Origami_Dagger(Paper paperClass){
                    obj = paperClass;
                }
                public double Origami_Dagger{
                    get{
                        return this.origami_dagger;
                    }
                }
                public string Name{
                    get{
                        return this.DaggerName;
                    }
                }
            }

            /// <summary>
            /// This is the Paper type: Graphine_Oxide_Paper Shuriken
            /// </summary>
            /// <value></value>
            public class Shuriken{
                private string ShurikenName = "SHURIKEN";
                public Notebook_Paper notebook_paperPiece {get;set;}
                public Graphine_Oxide_Paper GOPPiece {get;set;}
                private Paper obj;
                public Shuriken(Paper paperClass){
                    obj = paperClass;
                    this.notebook_paperPiece = new Notebook_Paper(this);
                    this.GOPPiece = new Graphine_Oxide_Paper(this);
                }
                public string Name{
                    get{
                        return this.ShurikenName;
                    }
                }
                public class Notebook_Paper{
                    private string Notebook_PaperShurikenName = "NOTEBOOK PAPER SHURIKEN";
                    private double Notebook_PaperShuriken = 1.2;
                    private Shuriken obj;
                    public Notebook_Paper(Shuriken shurikenClass){
                        obj = shurikenClass;
                    }
                    public double NOTEBOOK_PAPER_SHURIKEN{
                        get{
                            return this.Notebook_PaperShuriken;
                        }
                    }
                    public string Name{
                        get{
                            return this.Notebook_PaperShurikenName;
                        }
                    }
                }//End of Notebook paper shuriken
                public class Graphine_Oxide_Paper{
                    private string GOPShurikenName = "GRAPHINE OXIDE PAPER SHURIKEN";
                    private double graphine_oxide_paper = 2.3;
                    private Shuriken obj;
                    public Graphine_Oxide_Paper(Shuriken shurikenClass){
                        obj = shurikenClass;
                    }
                    public double _Graphine_Oxide_Paper{
                        get{
                            return this.graphine_oxide_paper;
                        }
                    }
                    public string Name{
                        get{
                            return this.GOPShurikenName;
                        }
                    }
                }//End of Graphine Oxide Paper Shuriken
                
            }

            
        }//Paper Class

        public class Scissors
        {
            private string ScissorsName = "SCISSORS";
            public Construction_Scissors scissorsPiece {get;set;}
            public Shears shearsPiece {get;set;}
            private Gamepiece obj;

            public Scissors(Gamepiece gamepieceClass){
                obj = gamepieceClass;
                this.scissorsPiece = new Construction_Scissors(this);
                this.shearsPiece = new Shears(this);
            }
            public string Name{
                get{
                    return this.ScissorsName;
                }
            }

            /// <summary>
            /// This is the Scissors type: Construction Scissors
            /// </summary>
            /// <value></value>
            public class Construction_Scissors
            {
                private string construction_ScissorsName = "Construction Scissors";
                private double construction_Scissors = 2.8;
                private Scissors obj;
                public Construction_Scissors(Scissors scissorsClass){
                    obj = scissorsClass;
                }
                public double CONSTRUCTION_SCISSORS{
                    get{
                        return this.construction_Scissors;
                    }
                }
                public string Name{
                    get{
                        return this.construction_ScissorsName;
                    }
                }
            }

            /// <summary>
            /// This is the Scissors type: Shears
            /// </summary>
            /// <value></value>
            public class Shears{
                private string shearsName = "SHEARS";
                private double shears = 3.5;
                private Scissors obj;
                public Shears(Scissors scissorsClass){
                    obj = scissorsClass;
                }
                public double SHEARS{
                    get{
                        return this.shears;
                    }
                }
                public string Name{
                    get{
                        return this.shearsName;
                    }
                }
            }
        }//Scissors Class
    }
}