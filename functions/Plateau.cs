using System.Data;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;
using System.Threading;
using Triangle_Scalene.functions;
using System.Drawing;
//using System.Security.Cryptography;

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
            List<Triangle> Listgagnejun = new List<Triangle>() {};
            List<Triangle> Listgagnejdeux = new List<Triangle>() {};
            List<Triangle> ListeGardeCarte = new List<Triangle>() {};
            List<Triangle> ListCimetiere = new List<Triangle>() {};
            List<Player> listPlayer = new List<Player>(dicoPlayers.Keys){};

            // bool Verifone = false;
            // bool Veriftwo = false;
            Int16 Tour = -1;
            Console.WriteLine("here");
                this.interfaceUI.WriteLog("Partie démarrée"); ////ici 1
            while (PlayerChoice == true){
                Tour++;
                string infoTour = "Gameplay::" + Tour.ToString();
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
                                    // Table t = new Table();
                                    // t.CreateCase(player.listPioche);
                                    // t.DrawCase(interfaceUI);

                                        
                                    //     interfaceUI.CenterText("Quelle carte choississez-vous pour ce tour ?");
                                    //     interfaceUI.CenterText("Taper une commande entre 1 à "+ player.listPioche.Count()+":");
                                        if (player._Player == "Player 1") {
                                            CarteJoueurUn = interfaceUI.SelectionCard(player);
                                            this.interfaceUI.WriteLog("Joueur1: "+ player.Name+" choisit sa carte : "+CarteJoueurUn._Name, infoTour); //ici 3
                                        } else {
                                            CarteJoueurDeux = interfaceUI.SelectionCard(player);
                                            this.interfaceUI.WriteLog("Joueur2: "+ player.Name+" choisit sa carte : "+CarteJoueurDeux._Name, infoTour);  //ici 3
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
                } //fin for each Player list pioche

                Confrontation(CarteJoueurUn, CarteJoueurDeux, Bonus, listPlayer, Listgagnejun, Listgagnejdeux, ListeGardeCarte, ListCimetiere, infoTour, PlayerChoice);
                
                 /*Pour terminer la partie entière 
                (situation ou les deux joueurs n'ont plus de carte dans leur main --> 
                Mis par defaul a 20 pour le moment*/
                if (GetGameStatement()){
                    //return;
                    // if (Listgagnejun.Count()+Listgagnejdeux.Count() > 19 && ListeGardeCarte.Count() == 0){ 
                        Console.WriteLine("Attention Le jeu s'arrete !!!");
                        PlayerChoice = false;
                        Int32 ResultPlayer1 = Listgagnejun.Count();
                        Int32 ResultPlayer2 = Listgagnejdeux.Count();
                        interfaceUI.EndGame(ResultPlayer1, ResultPlayer2);
                        this.interfaceUI.WriteLog("Fin de partie",infoTour); // ici 8
                        //Console.WriteLine("Fin du programme");
                        interfaceUI.WaitKeys();
                        // Thread.Sleep(60*10);
                        this.interfaceUI.WriteLog("fermeture du logiciel",infoTour); // ici 9
                        Thread.Sleep(60*60);
                        
                        p.Run(p);
                        // System.Environment.Exit(0);
                    } else {
                        // Console.WriteLine("Continue le programme");
                        this.interfaceUI.WriteLog("Fin du tour\n", infoTour); // ici 7
                        PlayerChoice = true;
                    }
                
            }
        }

        void Confrontation(Triangle CarteJoueurUn, 
        Triangle CarteJoueurDeux, 
        Triangle Bonus, 
        List<Player> listPlayer, 
        List<Triangle> Listgagnejun, 
        List<Triangle> Listgagnejdeux, 
        List<Triangle> ListeGardeCarte, 
        List<Triangle> ListCimetiere, 
        string infoTour, 
        bool PlayerChoice){
            Program p = new Program();
            EffectCard ec = new EffectCard();
            // ColorLine cL = new ColorLine();
            bool Cheval = false;
            if (CarteJoueurUn.Utilise && CarteJoueurDeux.Utilise){    
                    string un;
                    string deux;
                    (un, deux) = interfaceUI.ShowPlayer(listPlayer);
                    this.interfaceUI.WriteLog("Début de la phase confrontation", infoTour); // ici 4             
                    string WinCard = p.ActiveEffect(CarteJoueurUn, CarteJoueurDeux, listPlayer[0], listPlayer[1], Listgagnejun, Listgagnejdeux);
                        if (WinCard == "P1"){
                            this.interfaceUI.WriteLog("Le joueur 1 "+ un+" a gagné cette manche!");
                            if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejun.Add(garde);
                                }
                                    ListeGardeCarte.Clear();
                            }


                            
                            Listgagnejun.Add(CarteJoueurUn);
                            Listgagnejun.Add(CarteJoueurDeux);
                            
                            ///////////////////////////////////////////////////////
                            // Cheval de troie en cours pour joueur 1
                            // Listgagnejun qui va perdre la moitié de ses cartes 
                            if (CarteJoueurDeux._Effect == "Cheval de troie"){
                                ec.Cheval_de_troie(CarteJoueurUn, listPlayer[0], Listgagnejun, Listgagnejdeux); // première list est debité vers la deuxieme
                                Cheval = true;
                            // this.interfaceUI.CenterText("L'effet [Cheval de troie] a été activé pour le joueur 2: "+ deux+" la moitié de ses cartes ont été redistribué à "+ un);
                            }
                            ///////////////////////////////////////////////////////


                            //Log (fin de confrontation)
                            interfaceUI.CenterText(ColorLine.Color_Orange+ColorLine.Text_Bold+"Le joueur 1 "+ un +" a gagné contre " +CarteJoueurDeux._Name + " grace à "+ CarteJoueurUn._Name+" !"+ColorLine.ResetBold+ColorLine.ResetAll);
                            if (Cheval) {
                                interfaceUI.CenterText(ColorLine.Color_Yellow+ColorLine.ResetItalic+"Oh non! le joueur 1 "+un+ " s'est fait avoir par un cheval de troie !, il va perdre la moitié des cartes gagnés"+ColorLine.ResetItalic+ColorLine.ResetAll);
                                this.interfaceUI.WriteLog("Oh non! le joueur 1 "+un+ " s'est fait avoir par un cheval de troie !, il va perdre la moitié des cartes gagnés", infoTour);
                            }
                            interfaceUI.CenterText("La nouvelle liste du joueur 1: "+ un+" " + Listgagnejun.Count());
                            interfaceUI.CenterText("La liste du joueur 2: "+ deux+" " + Listgagnejdeux.Count());
                            interfaceUI.CenterText("La liste qui garde les cartes: " + ListeGardeCarte.Count());
                            //
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+
                            "\n\t\t\t\t\tJoueur 1: "+ un+" "+Listgagnejun.Count()+
                            "\n\t\t\t\t\tjoueur 2: "+ deux +" "+ Listgagnejdeux.Count() +
                            "\n\t\t\t\t\tLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            //
                            interfaceUI.WaitKeys();
                        } else if (WinCard == "P2"){
                            this.interfaceUI.WriteLog("Le joueur 2 "+ deux+" a gagné cette manche!");
                            if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejdeux.Add(garde);
                                }
                                    ListeGardeCarte.Clear();
                            }
                            Listgagnejdeux.Add(CarteJoueurUn);
                            Listgagnejdeux.Add(CarteJoueurDeux);

                            ///////////////////////////////////////////////////////
                            // Cheval de troie en cours pour joueur 2
                            // Listgagnejdeux qui va perdre la moitié de ses cartes 
                            if (CarteJoueurUn._Effect == "Cheval de troie"){
                                ec.Cheval_de_troie(CarteJoueurUn, listPlayer[1], Listgagnejdeux, Listgagnejun); // première list est debité vers la deuxieme
                                // this.interfaceUI.CenterText("L'effet [Cheval de troie] a été activé pour le joueur 2: "+ deux+" la moitié de ses cartes ont été redistribué à "+ un);
                                Cheval = true;
                            }
                            ///////////////////////////////////////////////////////

                            if (Cheval) {
                                interfaceUI.CenterText(ColorLine.Color_Yellow+ColorLine.ResetItalic+"Oh non! le joueur 2 "+deux+ " s'est fait avoir par un cheval de troie !, il va perdre la moitié des cartes gagnés"+ColorLine.ResetItalic+ColorLine.ResetAll);
                                this.interfaceUI.WriteLog("Oh non! le joueur 2 "+deux+ " s'est fait avoir par un cheval de troie !, il va perdre la moitié des cartes gagnés", infoTour);
                            }

                            interfaceUI.CenterText(ColorLine.Color_Cyan+ColorLine.Text_Bold+"Le joueur 2 "+ deux +" a gagné contre " +CarteJoueurUn._Name + " grace à "+ CarteJoueurDeux._Name+" !"+ColorLine.ResetBold+ColorLine.ResetAll);


                            interfaceUI.CenterText("La liste du joueur 1: "+ un+" " + Listgagnejun.Count());
                            interfaceUI.CenterText("La nouvelle liste du joueur 2: "+ deux+" " + Listgagnejdeux.Count());
                            interfaceUI.CenterText("La liste qui garde les cartes: " + ListeGardeCarte.Count());
                            //
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+
                            "\n\t\t\t\t\tJoueur 1: "+ un+" "+Listgagnejun.Count()+
                            "\n\t\t\t\t\tjoueur 2: "+ deux+" "+ Listgagnejdeux.Count()+
                            "\n\t\t\t\t\tLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            //
                            interfaceUI.WaitKeys();
                        } else {
                            this.interfaceUI.WriteLog("Aucun joueur n'a remporté cette manche!");
                            interfaceUI.CenterText(ColorLine.Color_Red+ColorLine.Text_Bold+"Egalité entre les cartes: "+ CarteJoueurUn._Name +" et "+ CarteJoueurDeux._Name+ColorLine.ResetBold+ColorLine.ResetAll);
                            // Effet de carte Grande Revoluton, Récupère la carte BONUS
                            if (CarteJoueurUn._Effect == "Grande Revolution"){
                                // Si la carte Bonus existe alors Add.(Bonus)
                                if (Bonus != null) {
                                    Listgagnejun.Add(Bonus); //p.cardBonus = Bonus
                                    Bonus = null; //
                                }
                                //
                                this.interfaceUI.WriteLog("[Grande Revolution]: Joueur 1: "+ un +" a obtenu la carte Bonus !", infoTour); // ici 6
                                //
                            }
                            if (CarteJoueurDeux._Effect == "Grande Revolution"){
                                if (Bonus != null) {
                                    Listgagnejdeux.Add(Bonus); //p.cardBonus = Bonus
                                    Bonus = null; //
                                }
                                //LOG//
                                this.interfaceUI.WriteLog("[Grande Revolution]: Joueur 2: "+ deux +" a obtenu la carte Bonus !", infoTour); // ici 6
                                //
                            }
                            // Carte Croissance Explosive récupère toutes les cartes de la zone garde carte 
                            //(les cartes en combat ne sont pas pris en compte)
                            if (CarteJoueurUn._Effect == "Croissance Explosive"){
                                //
                                    this.interfaceUI.WriteLog(" Joueur 1: "+ un +" a activé [Croissance Explosive] ! \n"+
                                    "Il récupère les cartes gardées dans la zone garde carte !", infoTour); // ici 6
                                //
                                if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejun.Add(garde);
                                }
                                ListeGardeCarte.Clear();
                            }
                            }
                            if (CarteJoueurDeux._Effect == "Croissance Explosive"){
                                //
                                    this.interfaceUI.WriteLog(" Joueur 2: "+ un +" a activé [Croissance Explosive] ! \n"+
                                    "Il récupère les cartes gardées dans la zone garde carte !", infoTour); // ici 6
                                //
                                if (ListeGardeCarte.Count() > 0){
                                foreach (Triangle garde in ListeGardeCarte) {
                                    Listgagnejdeux.Add(garde);
                                }
                                ListeGardeCarte.Clear();
                            }

                            }
                            // Card effect Exil for players
                            if ((CarteJoueurUn._Effect == "Exil") || (CarteJoueurDeux._Effect == "Exil")){
                                if (CarteJoueurUn._Effect == "Exil"){
                                    ListCimetiere.Add(CarteJoueurDeux);
                                    ListeGardeCarte.Add(CarteJoueurUn);
                                    //
                                    this.interfaceUI.WriteLog(" Joueur 1: "+ un +" a utilsé [Exil] pour exiler la carte adverse !", infoTour); // ici 6
                                    interfaceUI.CenterText("Carte Exilée: "+ CarteJoueurDeux + "nombre cartes: "  + ListCimetiere.Count());
                                    //
                                }
                                if (CarteJoueurDeux._Effect == "Exil"){
                                    ListCimetiere.Add(CarteJoueurUn);
                                    ListeGardeCarte.Add(CarteJoueurDeux);
                                    //LOG//
                                    this.interfaceUI.WriteLog(" Joueur 2: "+ deux +" a utilsé [Exil] pour exiler la carte adverse !", infoTour); // ici 6
                                    interfaceUI.CenterText("Carte Exilée: "+ CarteJoueurUn  + "nombre cartes: "+ ListCimetiere.Count());
                                    
                                    //
                                }
                            } else {
                                ListeGardeCarte.Add(CarteJoueurUn);
                                ListeGardeCarte.Add(CarteJoueurDeux);
                            }
                            
                            
                            interfaceUI.CenterText("La liste qui garde les cartes: " + ListeGardeCarte.Count());
                            interfaceUI.CenterText("Liste du joueur 1: "+ un+" " + Listgagnejun.Count());
                            interfaceUI.CenterText("Liste du joueur 2: "+ deux+" " + Listgagnejdeux.Count());
                            //LOG//
                            this.interfaceUI.WriteLog("Détail sur les cartes de joueurs : "+
                            "\n\t\t\t\t\tJoueur 1: "+ un+" "+Listgagnejun.Count()+
                            "\n\t\t\t\t\tjoueur 2: " + deux+" "+ Listgagnejdeux.Count()+
                            "\n\t\t\t\t\tLa liste qui garde les cartes: " + ListeGardeCarte.Count(), infoTour); // ici 5
                            if ((CarteJoueurUn._Effect == "Exil") || (CarteJoueurDeux._Effect == "Exil")){
                                this.interfaceUI.WriteLog("\n\t\t\t\t\tCarte mise au cimtiere: "+ListCimetiere.Count(), infoTour);
                            }
                            
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
        }
        //Pour finir le jeu
        bool GetGameStatement(){
            bool isGameOver = false;
            foreach(Player player in this.DictPlayers.Keys){
                if (player.listPioche.Count() == 0){
                    isGameOver = true;
                }
            }
            return isGameOver;
        }

    } //fin de classe
       
} // Fin de namespace