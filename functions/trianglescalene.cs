using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Scalene 
{
    public class Triangle
    {
// childRandom = new Random();
		
        public string _Name;
        public string _Effect;
        public string _Description;
        public ushort _Number;
        public bool Utilise;
		public Triangle(string nom, string couleur, string effect = "",string description = "", ushort number=0, bool utilise=false,string set="default") //ushort de 0 à 65 535
        {
            this._Name = nom;
            //this.SetColor(couleur);
            this._Effect = effect;
            this._Description = description;
            this._Number = number;
            this.Utilise = utilise;

        }
        /*
        private void SetColor(string color){
            switch color{
                case "rouge":
                //Récupère rectanlge puis le color en rouge rgb(255,0,0)
                case "jaune":
                case "vert":

            }
        }*/
    }
    //Defini les players et leur set de carte
    public class Player
    {
        public string _Player { get; set; }
        private string Set { get; set; }

        public string Name {get; set;}

        public List<Triangle> listPioche = new List<Triangle>();

        Triangle cardBonus;


        public Player(string name, string set)
        {
            Name = name;
            Set = set;
            //this.GeneratePioche(ListCards);
        }

        void SetCardBonus(){

        }


        public void GeneratePioche(List<Triangle> listCards){
            if (Set == "A") {
                for (int i = 0; i <= 9; i++) {
                    //Console.WriteLine("card"+listCards[i]);
                    this.listPioche.Add(listCards[i]);
                }
            } else {
                for (int i = 10; i <= 19; i++) {
                    //Console.WriteLine("card"+listCards[i]);
                    this.listPioche.Add(listCards[i]);
                }
            }

            //test le set du player
            //selon ce set, une tranche de cartes sera récupéré
            //random de récupération des cartes dans la listePioche
        }

        public void ShowCard(){
            Console.WriteLine("-- "+this.Name);
            foreach(Triangle triangle in this.listPioche){
                Console.Write("Carte: "+triangle._Name);
                Console.Write(" Number: " + triangle._Number+"\n");
                Console.Write(" Effect: " + triangle._Effect+"\n");
            }
        }


        // Other properties, methods, events...
    }
}