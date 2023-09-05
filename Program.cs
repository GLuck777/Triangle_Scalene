
using System;
using System.Reflection.Metadata;
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
            this.interfaceUI.WriteLog("Logiciel démarré");
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
            this.ListCards.Add(new Triangle(nom:"Roi Art", couleur:"jaune", effect:"Roi", description:ExplainEffect("Roi"), number:3, set:"A"));
            //Reine KILL Roi
            this.ListCards.Add(new Triangle(nom:"Reine Gen", couleur:"jaune",effect:"Reine", description:ExplainEffect("Reine"), number:3, set:"A"));
            //Prince Kill Reine
            this.ListCards.Add(new Triangle(nom:"Prince Port", couleur:"jaune",effect:"Prince", description:ExplainEffect("Prince"), number:3, set:"A"));
            //Section Chevalier
            //Chevalier #1
            this.ListCards.Add(new Triangle(nom:"Chevalier Rev", couleur:"vert", effect:"", number:2, set:"A"));
            //Chevalier #2
            this.ListCards.Add(new Triangle(nom:"Chevalier Norm", couleur:"vert", effect:"", number:2, set:"A"));
            //Section Assassin
            this.ListCards.Add(new Triangle(nom:"Assassin J", couleur:"violet", number:1, set:"A"));
            //Assassin
            this.ListCards.Add(new Triangle(nom:"Assassin A", couleur:"violet", number:1, set:"A"));
            //Section Paysan X3
            this.ListCards.Add(new Triangle(nom:"paysan Trol", couleur:"rouge", effect:"Exil", description:ExplainEffect("Exil"), number:0, set:"A"));
            this.ListCards.Add(new Triangle(nom:"paysan Rez", couleur:"rouge", effect:"Reinitialisation", description:ExplainEffect("Reinitialisation"), number:0, set:"A"));
            this.ListCards.Add(new Triangle(nom:"paysan Ult", couleur:"rouge", effect:"Hero invincible", description:ExplainEffect("Hero invincible"), number:100, set:"A"));
            
            //SetB Main Faible
            //Section Famille Royale
            //Roi KILL Prince
            this.ListCards.Add(new Triangle(nom:"Roi Her", couleur:"jaune",effect:"Roi", description:ExplainEffect("Roi"), number:3, set:"B"));
            //Reine KILL Roi
            this.ListCards.Add(new Triangle(nom:"Reine Tuil", couleur:"jaune",effect:"Reine", description:ExplainEffect("Reine"), number:3, set:"B"));
            //Prince Kill Reine
            this.ListCards.Add(new Triangle(nom:"Prince Or", couleur:"jaune", effect:"Prince", description:ExplainEffect("Prince"), number:3, set:"B"));
            //Section Chevalier
            //Chevalier #1
            this.ListCards.Add(new Triangle(nom:"Chevalier Mul", couleur:"vert", effect:"", set:"B", number:2));
            //Section Assassin
            //Assassin #1
            this.ListCards.Add(new Triangle(nom:"Assassin T", couleur:"violet", number:1, set:"B"));
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
        public string ActiveEffect(Triangle CarteJoueurUn, Triangle CarteJoueurDeux) {
            EffectCard ec = new EffectCard();
            bool result;
            //Recuperer cartechoisie par les deux joueurs --> <Triangle>?
            /*
                Permet d'activer les effets d'une carte
            */
            ushort ActiveCardA;
            ushort ActiveCardB;
            if (CarteJoueurUn._Effect == "Hero_invincible") {
                return "P1";
            }
            if (CarteJoueurUn._Effect == "Hero_invincible") {
                return "P2";
            }
            if (CarteJoueurUn._Number == 1 && CarteJoueurDeux._Number == 3){
                return "P1";
            }
            if (CarteJoueurUn._Number == 3 && CarteJoueurDeux._Number == 1){
                return "P2"; 
            }
            if ((CarteJoueurUn._Number > CarteJoueurDeux._Number) && !((CarteJoueurUn._Number == 1 && CarteJoueurDeux._Number==0) || (CarteJoueurUn._Number == 0 && CarteJoueurDeux._Number == 1))){
                return "P1";
            } 
            if ((CarteJoueurUn._Number < CarteJoueurDeux._Number) && !((CarteJoueurUn._Number == 1 && CarteJoueurDeux._Number==0) || (CarteJoueurUn._Number == 0 && CarteJoueurDeux._Number == 1))){
                return "P2";
            } 
            
            if ((CarteJoueurUn._Number == CarteJoueurDeux._Number) || (CarteJoueurUn._Number == 1 && CarteJoueurDeux._Number==0) || (CarteJoueurUn._Number == 0 && CarteJoueurDeux._Number == 1)){
                if (CarteJoueurUn._Effect == "" && CarteJoueurDeux._Effect == ""){
                    return "P3"; //_Name1 + _Name2;
                }
                if (CarteJoueurUn._Effect != "" ) {
                    switch (CarteJoueurUn._Effect) {
                    case "Croissance_Explosive":
                    ec.Croissance_Explosive(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    ActiveCardA = 1;
                    Console.WriteLine(ActiveCardA);
                    break;

                    case "Grande_Revolution":
                    ec.Grande_Revolution(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    ActiveCardA = 2;
                    Console.WriteLine(ActiveCardA);
                    break;

                    case "Cheval_de_troie": 
                    ec.Cheval_de_troie(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    ActiveCardA = 3;
                    Console.WriteLine(ActiveCardA);
                    break;

                    case "Exil": 
                    ec.Exil(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    ActiveCardA = 4;
                    Console.WriteLine(ActiveCardA);
                    break;

                    case "Reinitialisation": 
                    ec.Reinitialisation(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    ActiveCardA = 5;
                    Console.WriteLine(ActiveCardA);
                    break;

                    case "Roi":
                    result = ec.Roi(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    if (result){
                        return "P1";
                    }
                    //ActiveCardA = 7;
                    break;
                    case "Reine":
                    result = ec.Reine(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    if (result){
                        return "P1";
                    }
                    // ActiveCardA = 8;
                    break;
                    case "Prince":
                    result = ec.Prince(CarteJoueurUn._Name, CarteJoueurDeux._Name);
                    if (result){
                        return "P1";
                    }
                    // ActiveCardA = 9;
                    break;
                    }
                } else {
                    ActiveCardA = 0;
                }
                if (CarteJoueurDeux._Effect != "" ) {
                    switch (CarteJoueurDeux._Effect) {
                    case "Croissance_Explosive":
                    ec.Croissance_Explosive(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    ActiveCardB = 1;
                    Console.WriteLine(ActiveCardB);
                    break;
                    case "Grande_Revolution":
                    ec.Grande_Revolution(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    ActiveCardB = 2;
                    Console.WriteLine(ActiveCardB);
                    break;
                    case "Cheval_de_troie": 
                    ec.Cheval_de_troie(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    ActiveCardB = 3;
                    Console.WriteLine(ActiveCardB);
                    break;
                    case "Exil": 
                    ec.Exil(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    ActiveCardB = 4;
                    Console.WriteLine(ActiveCardB);
                    break;
                    case "Reinitialisation": 
                    ec.Reinitialisation(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    ActiveCardB = 5;
                    Console.WriteLine(ActiveCardB);
                    break;
                    case "Roi":
                    result = ec.Roi(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    if (result){
                        return "P2";
                    }
                    // ActiveCardB = 7;
                    break;
                    case "Reine":
                    result = ec.Reine(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    if (result){
                        return "P2";
                    }
                    //ActiveCardB = 8;
                    break;
                    case "Prince":
                    result = ec.Prince(CarteJoueurDeux._Name, CarteJoueurUn._Name);
                    if (result){
                        return "P2";
                    }
                    //ActiveCardB = 9;
                    break;
                    }
                } else {
                    ActiveCardB = 0;
                    Console.WriteLine(ActiveCardB);
                }
                
               
            }
            // Console.WriteLine("P0");
            return "P3";
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
