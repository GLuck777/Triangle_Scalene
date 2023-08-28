using System;
using System.Runtime.CompilerServices;
// using Triangle_Scalene; // appel du package

namespace Triangle_Scalene
{
    class Program
    {
        public List<Triangle> ListCards = new List<Triangle>() {};
        public List<Player> ListPlayers = new List<Player>() {};

        public Program programObject;

        public Triangle cardBonus;
        public Players players = new Players();
        InterfaceUI interfaceUI = new InterfaceUI();
        
        static void Main(string[] args) {
            // game loop*
            Program p = new Program();
            p.Run(p);
            //Mis en place des players et récupération des sets
            /*
            p.LoadGameData();
            p.GenerateCards();*/

        }

        // fonction utilisé pour débuter l'interface UI se trouvant dans Interface.cs
        // Début du code...
        // Avec cette fonction on obtient le 2 pour générer les personnages 
        void Run(Program p){
            this.interfaceUI.IntroMessage();
            programObject = p;
            programObject.LoadGameData();
            programObject.PlayGame(p.players);

        }

        public void LoadGameData(){
            Int16 PLayerNumber = interfaceUI.GetPlayerNumber();
            this.GenerateCards();

            players.AddPlayer(PLayerNumber, ListCards);
        }

        /*la où fini actuellement notre code (ne comprte pas encore l'appel du Plateau car non-fonctionnel)
        il comporte une fonction ayant pour objectif de montrer les cartes que chaque possède, 
        c'est un moyen de verifier le bon fonctionnement du code jusqu'à present*/
        private void PlayGame(Players players){
            Plateau plateau = new Plateau();
            plateau.LoadPlayers(players.ListPlayers); 
        }

        void GenerateCards() {
            /*
                Génère toutes les instances de cartes possibles
            */
            
            //SetA Main Forte
            //Section Famille Royale
            //Roi KILL Prince
            this.ListCards.Add(new Triangle(nom:"Roi Art", couleur:"jaune", effect:"Roi", description:ExplainEffect("Roi"), number:2, set:"A"));
            //Reine KILL Roi
            this.ListCards.Add(new Triangle(nom:"Reine Gen", couleur:"jaune",effect:"Reine", description:ExplainEffect("Reine"), number:2, set:"A"));
            //Prince Kill Reine
            this.ListCards.Add(new Triangle(nom:"Prince Port", couleur:"jaune",effect:"Prince", description:ExplainEffect("Prince"), number:2, set:"A"));
            //Section Chevalier
            //Chevalier #1
            this.ListCards.Add(new Triangle(nom:"Chevalier Rev", couleur:"vert", effect:"", number:1, set:"A"));
            //Chevalier #2
            this.ListCards.Add(new Triangle(nom:"Chevalier Norm", couleur:"vert", effect:"", number:1, set:"A"));
            //Section Assassin
            this.ListCards.Add(new Triangle(nom:"Assassin J", couleur:"violet", number:0, set:"A"));
            //Assassin
            this.ListCards.Add(new Triangle(nom:"Assassin A", couleur:"violet", number:0, set:"A"));
            //Section Paysan X3
            this.ListCards.Add(new Triangle(nom:"paysan Trol", couleur:"rouge", effect:"Exil", description:ExplainEffect("Exil"), number:0, set:"A"));
            this.ListCards.Add(new Triangle(nom:"paysan Rez", couleur:"rouge", effect:"Reinitialisation", description:ExplainEffect("Reinitialisation"), number:0, set:"A"));
            this.ListCards.Add(new Triangle(nom:"paysan Ult", couleur:"rouge", effect:"Hero invincible", description:ExplainEffect("Hero invincible"), number:100, set:"A"));
            
            //SetB Main Faible
            //Section Famille Royale
            //Roi KILL Prince
            this.ListCards.Add(new Triangle(nom:"Roi Her", couleur:"jaune",effect:"Roi", description:ExplainEffect("Roi"), number:2, set:"B"));
            //Reine KILL Roi
            this.ListCards.Add(new Triangle(nom:"Reine Tuil", couleur:"jaune",effect:"Reine", description:ExplainEffect("Reine"), number:2, set:"B"));
            //Prince Kill Reine
            this.ListCards.Add(new Triangle(nom:"Prince Or", couleur:"jaune", effect:"Prince", description:ExplainEffect("Prince"), number:2, set:"B"));
            //Section Chevalier
            //Chevalier #1
            this.ListCards.Add(new Triangle(nom:"Chevalier Mul", couleur:"vert", effect:"", set:"B", number:1));
            //Section Assassin
            //Assassin #1
            this.ListCards.Add(new Triangle(nom:"Assassin T", couleur:"violet", number:0, set:"B"));
            //Section Paysan X5
            this.ListCards.Add(new Triangle(nom:"paysan Gra", couleur:"rouge", effect:"Croissance Explosive", description:ExplainEffect("Croissance Explosive"), number:0, set:"B"));
            this.ListCards.Add(new Triangle(nom:"paysan Red", couleur:"rouge", effect:"Grande Revolution", description:ExplainEffect("Grande Revolution"), number:0, set:"B"));
            this.ListCards.Add(new Triangle(nom:"paysan Rot", couleur:"rouge", effect:"Cheval de troie", description:ExplainEffect("Cheval de troie"), number:0, set:"B"));
            this.ListCards.Add(new Triangle(nom:"paysan nul", couleur:"rouge", number:0, set:"B"));
            this.ListCards.Add(new Triangle(nom:"paysan lat", couleur:"rouge", number:0, set:"B"));
            //BONUS Card

            this.cardBonus = new Triangle(nom:"BONUS", couleur:"white", effect:"",number:0, set:"");
            /*
            for (ushort i=0;i<22;i++){
            };*/
        }
        public string ExplainEffect(string effect) {
            /*
                Appeler pour obtenir l'effet d'une carte à partir de son (nom?)
            */
            string text = "";
            switch (effect) {
                case "Croissance Explosive":
                    text = "Accroit le nombre de Carte Gagnées";
                    // text = "Croissance_Explosive\rAccroit le nombre de Carte Gagnées";
                    break;
                case "Grande Revolution":
                    text = "Récupère la carte Bonus";
                    // text = "Grande_Revolution\rRécupère la carte Bonus";
                    break;
                case "Cheval de troie": 
                    text = "Récupère la moitié des cartes gagnées de l'adversaire";
                    // text = "Cheval_de_troie\rRécupère la moitié des cartes gagnées de l'adversaire";
                    break;
                case "Exil": 
                    text = "Exil une carte de la main de l'adversaire";
                    // text = "Exil\rexil une carte de la main de l'adversaire";
                    break;
                case "Reinitialisation": 
                    text = "Prend les cartes gagnée de l'adversaire et le remets dans les mains correspondantes";
                    // text = "Reinitialisation\rPrend les cartes gagnée de l'adversaire et le remets dans les mains correspondantes";
                    break;
                case "Hero invincible": 
                    text = "Peut vaincre toutes les cartes";
                    // text = "Hero_invincible\rPeut vaincre toutes les cartes";
                    break;
                case "Roi":
                    text = "Si contre Prince, gagne.";
                    // text = "Roi\rsi contre Prince, gagne.";
                    break;
                case "Reine":
                    text = "Si contre Roi, gagne.";
                    // text = "Reine\rsi contre Roi, gagne.";
                    break;
                case "Prince":
                    text = "Si contre Reine, gagne.";
                    // text = "Prince\rSi contre Reine, gagne.";
                    break;
            }
            return text;
        }
        public string ActiveEffect(string Name1, ushort Number1, string Name2, ushort Number2, string Effect1="", string Effect2="") {
            /*
                Permet d'activer les effets d'une carte
            */
            ushort ActiveCardA;
            ushort ActiveCardB;

            if (Number1 > Number2){
                return Name1;
            } 
            if (Number1 < Number2){
                return Name2;
            } 
            if (Number1 == Number2) {
                if (Effect1 == "" && Effect2 == ""){
                    return null; //_Name1 + _Name2;
                }
                if (Effect1 != "" ) {
                    switch (Effect1) {
                    case "Croissance_Explosive":
                    ActiveCardA = 1;
                    break;
                    case "Grande_Revolution": 
                    ActiveCardA = 2;
                    break;
                    case "Cheval_de_troie": 
                    ActiveCardA = 3;
                    break;
                    case "Exil": 
                    ActiveCardA = 4;
                    break;
                    case "Reinitialisation": 
                    ActiveCardA = 5;
                    break;
                    case "Hero_invincible": 
                    ActiveCardA = 6;
                    break;
                    case "Roi":
                    ActiveCardA = 7;
                    break;
                    case "Reine":
                    ActiveCardA = 8;
                    break;
                    case "Prince":
                    ActiveCardA = 9;
                    break;
                    }
                } else {
                    ActiveCardA = 0;
                }
                if (Effect2 != "" ) {
                    switch (Effect2) {
                    case "Croissance_Explosive":
                    ActiveCardB = 1;
                    break;
                    case "Grande_Revolution": 
                    ActiveCardB = 2;
                    break;
                    case "Cheval_de_troie": 
                    ActiveCardB = 3;
                    break;
                    case "Exil": 
                    ActiveCardB = 4;
                    break;
                    case "Reinitialisation": 
                    ActiveCardB = 5;
                    break;
                    case "Hero_invincible": 
                    ActiveCardB = 6;
                    break;
                    case "Roi":
                    ActiveCardB = 7;
                    break;
                    case "Reine":
                    ActiveCardB = 8;
                    break;
                    case "Prince":
                    ActiveCardB = 9;
                    break;
                    }
                } else {
                    ActiveCardB = 0;
                }
                if (Effect1 == "Hero_invincible") {
                    return Name1;
                }
                if (Effect2 == "Hero_invincible") {
                    return Name2;
                }
               
            }
            
            return "si contre Reine, gagne.";
        }
        public Triangle GetCard(string name){
            /*
                Permet de récupérer une carte Triangle à partir
                de son nom spécifique
            */
            foreach(Triangle triangle in this.ListCards){
                Console.WriteLine(triangle._Number);
                Console.WriteLine(triangle._Name);
                Console.WriteLine(triangle._Effect);
                Console.WriteLine(triangle._Description);


                // if (triangle._Name == name){
                //     return triangle; 
                // }
            }
            return null;
        }
    }
}
