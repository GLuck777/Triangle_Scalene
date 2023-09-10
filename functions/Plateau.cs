
using System.Data;

using System;
using System.Reflection.Metadata;
using System.Threading;

namespace Triangle_Scalene{
    class Plateau{

        Dictionary<Player, bool> DictPlayers = new Dictionary<Player, bool>(){};

        private InterfaceUI interfaceUI;

        public bool Verifone { get; private set; }

        // Dictionary<Player, List<Triangle>> DictPlayers = new Dictionary<Player, List<Triangle>>(){};

        public Plateau(InterfaceUI iUI){
            this.interfaceUI = iUI;
        }

        public void LoadPlayers(List<Player> listPlayers){
            foreach(Player p in listPlayers){
                // p.ShowCard(); // te permet d'avoir une visu sur les cartes
                // this.DictPlayers.Add(p, false);
                this.DictPlayers.Add(p, false);
            }
            Console.WriteLine("Demarrage GameField !");
            this.interfaceUI.WaitKeys();
            Console.Clear(); //important sert a reset la liste de carte
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
                this.interfaceUI.WriteLog("Partie démarrée"); ////ici 1
                Tour++;
                
                //interfaceUI.ShowGameLog(); // met joueur ne sert plus
                foreach (Player player in dicoPlayers.Keys){
                    // Console.WriteLine(player._Player);
                    this.interfaceUI.WriteLog("Gameplay::Début de tour"); ////ici 2
                    Console.WriteLine("Tour du "+player.Name+"...");
                    String temp = player.Name;
                    
                
                    
                    this.interfaceUI.CenterText("Taper sur un touche pour voir vos cartes disponibles et jouer");
                    //Zone d'essai
                    Int32 inputSelection = -1;
                    // string strInputSelection;
                    while (inputSelection == -1){
                        // inputSelection = Int32.Parse(strInputSelection);
                        // try {
                        inputSelection = this.interfaceUI.Askinput(player.Name); // donne 0 ou 1

                        // } catch {
                            // Console.Write("Probleme ici");
                        // }
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
                                            this.interfaceUI.WriteLog("Joueur1: "+ player.Name+" choisit sa carte : "+CarteJoueurUn._Name, infoTour); //ici 3
                                        } else {
                                            CarteJoueurDeux = interfaceUI.SelectionCard(player);
                                            this.interfaceUI.WriteLog("Joueur1: "+ player.Name+" choisit sa carte : "+CarteJoueurDeux._Name, infoTour);  //ici 3
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
                    string un;
                    string deux;
                    (un, deux) = interfaceUI.ShowPlayer(listPlayer);
                    this.interfaceUI.WriteLog("Début de la phase confrontation", infoTour); // ici 4             
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
                            interfaceUI.CenterText("La nouvelle liste du joueur 1: "+ un+" " + Listgagnejone.Count());
                            interfaceUI.CenterText("La liste du joueur 2: "+ deux+" " + Listgagnejtwo.Count());
                            //
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+ un+" "+Listgagnejone.Count()+
                            "\njoueur 2: "+ deux +""+ Listgagnejtwo.Count(), infoTour); // ici 5
                            //
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
                            interfaceUI.CenterText("La nouvelle liste du joueur 2: "+ deux+" " + Listgagnejtwo.Count());
                            interfaceUI.CenterText("La liste du joueur 1: "+ un+" " + Listgagnejone.Count());
                            //
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+ un+" "+Listgagnejone.Count()+
                            "\njoueur 2: "+ deux+" "+ Listgagnejtwo.Count()+"\nLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            //
                            interfaceUI.WaitKeys();
                        } else {
                            if (CarteJoueurUn._Effect == "Grande Revolution"){
                                Listgagnejone.Add(Bonus); //p.cardBonus = Bonus
                                //
                                this.interfaceUI.WriteLog(" Joueur 1 "+ un +" a obtenu la carte Bonus !", infoTour); // ici 6
                                //
                            }
                            if (CarteJoueurDeux._Effect == "Grande Revolution"){
                                Listgagnejtwo.Add(Bonus); //p.cardBonus = Bonus
                                //LOG//
                                this.interfaceUI.WriteLog(" Joueur 2 "+ deux +"a obtenu la carte Bonus !", infoTour); // ici 6
                                //
                            }
                            ListeGardeCarte.Add(CarteJoueurUn);
                            ListeGardeCarte.Add(CarteJoueurDeux);
                            Console.WriteLine("Egalité entre les cartes");
                            interfaceUI.CenterText("La liste qui garde les cartes: " + ListeGardeCarte.Count());
                            interfaceUI.CenterText("Liste du joueur 1: "+ un+" " + Listgagnejone.Count());
                            interfaceUI.CenterText("Liste du joueur 2: "+ deux+" " + Listgagnejtwo.Count());
                            //LOG//
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+"\nJoueur 1"+ un+" "+Listgagnejone.Count()+
                            "\njoueur 2: " + deux+" "+ Listgagnejtwo.Count()+"\nLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            //
                            interfaceUI.WaitKeys();
                        }
                    // Console.WriteLine("le jeu continue...");
                    this.interfaceUI.WriteLog("fin de confrontation", infoTour); // ici 6
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
                    this.interfaceUI.WriteLog("Fin de partie",infoTour); // ici 8
                    //Console.WriteLine("Fin du programme");
                    interfaceUI.WaitKeys();
                    // Thread.Sleep(60*10);
                    this.interfaceUI.WriteLog("fermeture du logiciel",infoTour); // ici 9
                    Thread.Sleep(60*60);
                    System.Environment.Exit(0);
                } else {
                    // Console.WriteLine("Continue le programme");
                    this.interfaceUI.WriteLog("Fin du tour", infoTour); // ici 7
                    PlayerChoice = true;
                }
            }
        }
        } //fin de fonction
       
} // Fin de namespace