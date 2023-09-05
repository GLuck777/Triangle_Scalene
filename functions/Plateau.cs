
using System.Data;

using System;
using System.Reflection.Metadata;
using System.Threading;

namespace Triangle_Scalene{
    class Plateau{

        Dictionary<Player, bool> DictPlayers = new Dictionary<Player, bool>(){};

        public bool Verifone { get; private set; }

        // Dictionary<Player, List<Triangle>> DictPlayers = new Dictionary<Player, List<Triangle>>(){};

        public void LoadPlayers(List<Player> listPlayers){
            foreach(Player p in listPlayers){
                // p.ShowCard(); // te permet d'avoir une visu sur les cartes
                // this.DictPlayers.Add(p, false);
                this.DictPlayers.Add(p, false);
            }
            Console.WriteLine("Demarrage GameField !");
            InterfaceUI interfaceUI = new InterfaceUI();
            interfaceUI.WaitKeys();
            Console.Clear();
            this.GameCenter(DictPlayers);
            // this.NewGameCenter(DictPlayers); 
            // InterfaceUI.WaitKeys();
        }

        //Charge les joueurs 
        public void AddPlayers(List<Player> listPlayer){
            ushort index = 0;
            foreach(Player p in listPlayer){
                this.DictPlayers.Add(p,(index==0));
                index++;
            }
        }

        public void GameCenter(Dictionary<Player, bool> dicoPlayers) {
            bool PlayerChoice = true;
            Program p = new Program();
            InterfaceUI interfaceUI = new InterfaceUI();
            Triangle CarteJoueurUn;
            Triangle CarteJoueurDeux;
            CarteJoueurUn = null;
            CarteJoueurDeux = null;
            //string result="resultat";

           
            //Listgagne<Triangle>
            Triangle Bonus = p.cardBonus;
            Console.WriteLine("test2: "+ Bonus);
            List<Triangle> Listgagnejone = new List<Triangle>() {};
            List<Triangle> Listgagnejtwo = new List<Triangle>() {};
            List<Triangle> ListeGardeCarte = new List<Triangle>() {};
            List<Player> listPlayer = new List<Player>(dicoPlayers.Keys){};

            // bool Verifone = false;
            // bool Veriftwo = false;
            Int16 Tour = 0;
            string infoTour = "Gameplay::" + Tour.ToString();
            Console.WriteLine("here");
            while (PlayerChoice == true){
                interfaceUI.WriteLog("Partie démarrée"); ////ici 1
                Tour++;
                
                //interfaceUI.ShowGameLog(); // met joueur ne sert plus
                foreach (Player player in dicoPlayers.Keys){
                    // Console.WriteLine(player._Player);
                    interfaceUI.WriteLog("Gameplay::Début de tour"); ////ici 2
                    Console.WriteLine("Tour du "+player.Name+"...");
                    String temp = player.Name;
                    
                
                    
                    interfaceUI.CenterText("Taper sur un touche pour voir vos cartes disponibles et jouer");
                    //Zone d'essai
                    Int32 inputSelection = -1;
                    // string strInputSelection;
                    while (inputSelection == -1){
                        Console.Clear();
                        interfaceUI.CenterText(player.Name+" à vos cartes!");
                        Console.WriteLine();
                        interfaceUI.CenterText("[0]-Interrompre la partie",8);
                        Console.WriteLine();
                        interfaceUI.CenterText("[1]-Choisir une carte",8);
                        Console.WriteLine();
                        // strInputSelection = Console.ReadLine();
                        try{
                                // inputSelection = Int32.Parse(strInputSelection);
                                inputSelection = interfaceUI.Askinput();
                        }catch {
                                Console.WriteLine("Something went wrong");

                        }
                    }
                    /////////////////Fin de zone de texte ///////////////////////////////////////
                    ///// Selection de la carte par tableau
                    // interfaceUI.WaitKeys();
                    
                        // Console.WriteLine("selections: " + inputSelection);
                        switch (inputSelection){
                        case 0:
                            PlayerChoice = false;
                            interfaceUI.CenterText("La partie à été interrompue");
                            System.Environment.Exit(0);
                            break;
                        case 1:
                            try{
                                Console.Clear();
                                PlayerChoice = false;
                                if (!PlayerChoice ){
                                    Table t = new Table();
                                    t.CreateCase(player.listPioche);
                                    t.DrawCase(interfaceUI);

                                        
                                        interfaceUI.CenterText("Quelle carte choississez-vous pour ce tour ?");
                                        interfaceUI.CenterText("Taper une commande entre 1 à "+ player.listPioche.Count()+":");
                                        if (player.Name == "Player 1") {
                                            CarteJoueurUn = interfaceUI.SelectionCard(player);
                                            interfaceUI.WriteLog("Joueur1 choisit sa carte : "+CarteJoueurUn._Name, infoTour); //ici 3
                                        } else {
                                            CarteJoueurDeux = interfaceUI.SelectionCard(player);
                                            interfaceUI.WriteLog("Joueur1 choisit sa carte : "+CarteJoueurDeux._Name, infoTour);  //ici 3
                                        }
                                } else {
                                        Console.WriteLine("Entrée invalide...");
                                        Thread.Sleep(60*15);
                                        Console.Clear();
                                        PlayerChoice = true;
                                }
                            
                            } catch {
                                Console.WriteLine("Une erreur s'est produite");
                            }
                            break;
                        }
                        //interfaceUI.CenterText("Appuyez sur une touche");
                        //interfaceUI.WaitKeys();
                }
                
                /*Pour terminer la partie entière 
                (situation ou les deux joueurs n'ont plus de carte dans leur main --> 
                Mis par defaul a 20 pour le moment*/
                // Console.WriteLine("card1 "+CarteJoueurUn.Utilise+"card2 "+CarteJoueurDeux.Utilise);
                if (CarteJoueurUn.Utilise && CarteJoueurDeux.Utilise){    
                    interfaceUI.WriteLog("Début de la phase confrontation", infoTour); // ici 4             
                    string WinCard = p.ActiveEffect(CarteJoueurUn, CarteJoueurDeux);
                        if (WinCard == "P1"){
                            if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejone.Add(garde);
                                }
                            }
                            Listgagnejone.Add(CarteJoueurUn);
                            Listgagnejone.Add(CarteJoueurDeux);
                            //Log (fin de confrontation)
                            Console.WriteLine("Le joueur1 a gagné contre " +CarteJoueurDeux._Name + " grace à "+ CarteJoueurUn._Name+" !");
                            interfaceUI.CenterText("La nouvelle liste du joueur 1: " + Listgagnejone.Count());
                            interfaceUI.CenterText("La liste du joueur 2: " + Listgagnejtwo.Count());
                            interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+Listgagnejone.Count()+"\njoueur 2: " + Listgagnejtwo.Count(), infoTour); // ici 5
                            interfaceUI.WaitKeys();
                        } else if (WinCard == "P2"){
                            if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejtwo.Add(garde);
                                }
                            }
                            Listgagnejtwo.Add(CarteJoueurUn);
                            Listgagnejtwo.Add(CarteJoueurDeux);
                            Console.WriteLine("Le joueur2 a gagné contre " +CarteJoueurUn._Name + " grace à "+ CarteJoueurDeux._Name+" !");
                            interfaceUI.CenterText("La nouvelle liste du joueur 2: " + Listgagnejtwo.Count());
                            interfaceUI.CenterText("La liste du joueur 1: " + Listgagnejone.Count());
                            interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+Listgagnejone.Count()+"\njoueur 2: " + Listgagnejtwo.Count()+"\nLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            interfaceUI.WaitKeys();
                        } else {
                            ListeGardeCarte.Add(CarteJoueurUn);
                            ListeGardeCarte.Add(CarteJoueurDeux);
                            Console.WriteLine("Egalité entre les cartes");
                            interfaceUI.CenterText("La liste qui garde les cartes: " + ListeGardeCarte.Count());
                            interfaceUI.CenterText("Liste du joueur 1: " + Listgagnejone.Count());
                            interfaceUI.CenterText("Liste du joueur 2: " + Listgagnejtwo.Count());
                            interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+Listgagnejone.Count()+"\njoueur 2: " + Listgagnejtwo.Count()+"\nLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            interfaceUI.WaitKeys();
                        }
                    // Console.WriteLine("le jeu continue...");
                    interfaceUI.WriteLog("fin de confrontation", infoTour); // ici 6
                    CarteJoueurUn = null;
                    CarteJoueurDeux = null;
                } else {
                    PlayerChoice = true;
                }
                if (Listgagnejone.Count()+Listgagnejtwo.Count() > 19){ 
                    Console.WriteLine("Attention Le jeu s'arrete !!!");
                    PlayerChoice = false;
                    Int32 ResultPlayer1 = Listgagnejone.Count();
                    Int32 ResultPlayer2 = Listgagnejtwo.Count();
                    interfaceUI.EndGame(ResultPlayer1, ResultPlayer2);
                    interfaceUI.WriteLog("Fin de partie",infoTour); // ici 8
                    //Console.WriteLine("Fin du programme");
                    interfaceUI.WaitKeys();
                    // Thread.Sleep(60*10);
                    interfaceUI.WriteLog("fermeture du logiciel",infoTour); // ici 9
                    Thread.Sleep(60*60);
                    System.Environment.Exit(0);
                } else {
                    // Console.WriteLine("Continue le programme");
                    interfaceUI.WriteLog("Fin du tour", infoTour); // ici 7
                    PlayerChoice = true;
                }
            }
        }
        } //fin de fonction
       
} // Fin de namespace