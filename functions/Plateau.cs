
using System.Data;
// using Internal;
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
            Triangle Cardjoueurone;
            Triangle Cardjoueurtwo;
            string result="resultat";
           
            //Listgagne<Triangle>
            Triangle Bonus = p.cardBonus;
            Console.WriteLine("test2: "+ Bonus);
            List<Triangle> Listgagnejone = new List<Triangle>() {};
            List<Triangle> Listgagnejtwo = new List<Triangle>() {};
            List<Triangle> ListeGardeCarte = new List<Triangle>() {};
            List<Player> listPlayer = new List<Player>(dicoPlayers.Keys){};

            bool Verifone = false;
            bool Veriftwo = false;
            // Int16 PlayerChoice = -1;
            // const ushort LPosMessage = 15;
            Int16 Tour = 0;
            Console.WriteLine("here");
            while (PlayerChoice == true){
                Tour++;
                
                //interfaceUI.ShowGameLog(); // met joueur ne sert plus
                foreach (Player player in dicoPlayers.Keys){
                    // Console.WriteLine(player._Player);
                    Console.WriteLine("Tour du "+player.Name+"...");
                    String temp = player.Name;
                    
                
                    
                    interfaceUI.CenterText("Taper sur un touche pour voir vos cartes disponibles et jouer");
                    //Zone d'essai
                    Int32 inputSelection = -1;
                    string strInputSelection;
                    while (inputSelection == -1){
                        Console.Clear();
                        interfaceUI.CenterText(player.Name+" à vos cartes!");
                        Console.WriteLine();
                        interfaceUI.CenterText("[0]-Interrompre la partie",8);
                        Console.WriteLine();
                        interfaceUI.CenterText("[1]-Choisir une carte",8);
                        Console.WriteLine();
                        strInputSelection = Console.ReadLine();
                        try{
                            inputSelection = Int32.Parse(strInputSelection);
                        } catch {
                            Console.WriteLine("Something went wrong");

                        }
                        //inputSelection = interfaceUI.Askinput();
                        }
                    /////////////////Fin de zone de texte ///////////////////////////////////////
                    ///// Selection de la carte par tableau
                    // interfaceUI.WaitKeys();
                        Console.WriteLine("selections: " + inputSelection);
                        switch (inputSelection){
                        case 0:
                            PlayerChoice = false;
                            interfaceUI.CenterText("La partie à été interrompue");
                            break;
                        case 1:
                            try{
                                Console.Clear();
                                PlayerChoice = false;
                                if (!PlayerChoice ){
                                    Table t = new Table();
                                    t.CreateCase(player.listPioche);
                                    t.DrawCase(interfaceUI);

                                        /*
                                        interfaceUI.CenterText("Quelle carte choississez-vous pour ce tour ?");
                                        interfaceUI.CenterText("Taper une commande entre 1 à "+ player.listPioche.Count()+":");
                                        
                                        String Newinput = Console.ReadLine();
                                        Console.Clear();
                                        try {
                                            Int16 PlayerCard; 
                                            PlayerCard = Int16.Parse(Newinput);
                                            if (PlayerCard > 0 && PlayerCard <= 10){
                                                if (player.Name == "Player 1") {
                                                    Console.WriteLine("Cher "+temp);
                                                    Console.WriteLine("vous avez choisi la carte "+PlayerCard);

                                                    Cardjoueurone = player.listPioche[PlayerCard-1];
                                                    if (!string.IsNullOrEmpty(Cardjoueurone._Name)){
                                                        Verifone = true;
                                                    }
                                                    player.listPioche.Remove(player.listPioche[PlayerCard-1]); // Fonctionne ?
                                                    t.UpdateCard(Cardjoueurone); //NEW
                                                    //Fin d'aperçu
                                                    Console.WriteLine("Appuyez pour continuer");
                                                    interfaceUI.WaitKeys();
                                                    Console.Clear(); //test
                                                } else {
                                                    
                                                    Console.WriteLine("Cher "+temp);
                                                    Console.WriteLine("vous avez choisi la carte "+PlayerCard);

                                                    Cardjoueurtwo = player.listPioche[PlayerCard-1];
                                                    if (!string.IsNullOrEmpty(Cardjoueurtwo._Name)){
                                                        Veriftwo = true;
                                                    }
                                                    
                                                    player.listPioche.Remove(player.listPioche[PlayerCard-1]); // Fonctionne ?
                                                    t.UpdateCard(Cardjoueurtwo); //NEW
                                                    //Fin d'aperçu
                                                    Console.WriteLine("Appuyez pour continuer");
                                                    interfaceUI.WaitKeys();
                                                    Console.Clear(); //test
                                                }
                                                // if (!string.IsNullOrEmpty(Cardjoueurone._Name) && (!string.IsNullOrEmpty(Cardjoueurtwo._Name){
                                                //     Console.WriteLine("Une erreur s'est produite");
                                                // }
                                                
                                        
                                        }
                                        } catch {
                                            Console.WriteLine("Bad try!");
                                            PlayerChoice = true;
                                        }*/
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
                        interfaceUI.CenterText("Appuyez sur une touche");
                        interfaceUI.WaitKeys();
                    }
                }
                /*Pour terminer la partie entière 
                (situation ou les deux joueurs n'ont plus de carte dans leur main --> 
                Mis par defaul a 20 pour le moment*/
                if (Tour == 4){ 
                    Console.WriteLine("Fin du programme");
                    Thread.Sleep(60*10);
                    System.Environment.Exit(0);
                } else {
                    PlayerChoice = true;
                }
            }
            
        } //fin de fonction
       
} // Fin de namespace