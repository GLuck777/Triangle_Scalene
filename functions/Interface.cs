
using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Collections;
using System.IO.Enumeration;
using Microsoft.VisualBasic;
using Triangle_Scalene.functions;


/*
This file contains a C# class witch is dedicated for the output console
*/

namespace Triangle_Scalene
{
    class InterfaceUI{

        private string fName = "";

        const ushort MAX_PLAYER = 2;

        // public Plateau plateau; 
        public Int16 GetPlayerNumber(){
            Int16 PlayerNumber = -1;
            const ushort LeftPosMessage = 15;
            // this.plateau.AddPlayers(listPlayers);

            while (PlayerNumber == -1){
                Console.Clear();
                this.CenterText("Taper le numéro de commande selon votre choix:");
                Console.WriteLine();
                this.CenterText("[1]-Voir les règles", LeftPosMessage);
                Console.WriteLine();
                this.CenterText("[2]-Démarrer une partie (2 joueurs obliger)", LeftPosMessage);
                Console.WriteLine();
                this.CenterText("[3]-Voir les relations entre les cartes (effets)", LeftPosMessage);
                Console.WriteLine();
                this.CenterText("[0]-Quitter", LeftPosMessage);
                // String input = Console.ReadLine();
                string input;
                do {
                    input = Console.ReadLine();
                } while (input == null);
                try{
                    
                        PlayerNumber = Int16.Parse(input);
                    
                    switch (PlayerNumber){
                        case 0:
                            this.ExitMessage();
                            System.Environment.Exit(0);
                            break;
                        case 1:
                            Console.Clear();
                            this.ShowRules();
                            PlayerNumber = -1;
                            break;
                        case 2:
                            Console.Clear();
                            // this.GameInterface(PlayerNumber, listPlayers);
                            return PlayerNumber;
                            // PlayerNumber = -1;
                            // break;
                        case 3:
                            Console.Clear();
                            this.ShowCardsEffect();
                            PlayerNumber = -1;
                            break;
                        default:
                            Console.WriteLine("Invalid input...");
                            Thread.Sleep(60*10);
                            Console.Clear();
                            PlayerNumber = -1;
                            break;

                    }
                } catch {
                    this.OnError("Une erreur s'est produite");
                }
            }
            return PlayerNumber;
        }

        public void ShowCardsEffect(){
            /*
                Montre les effets de carte
            */
            List<string> listLines = new List<string>(){
                "**Puissance des Cartes :**\n",
                "*Au sein de la Famille Royale:*",
                    "prince <-- roi  ",
                    "Roi <-- Reine",
                    "reine <-- Prince\n",
                    "Famille royale <-- Assassin",
                    "Assassin <-- Chevalier",
                    "Chevalier <-- Famille Royale\n",
                    "Paysans <-- Famille royale",
                    "Paysans <-- Chevalier",
                    "Paysans /--\\ Paysans",
                    "Paysans /--\\ Assassin\n",
                    "Les paysans peuvent prendre avantage dans le combat selon leurs effets !",
                    "(À savoir que les effets ne peuvent être activés que dans une égalité de cartes, sauf exception de Hero Invincible et Cheval de Troie)\n",
                    "**Effets de Carte**\n",
                    "Croissance Explosive = Accroît le nombre de Carte Gagnées",
                    "Grande Revolution = Récupère la carte Bonus",
                    "Cheval de Troie = Récupère la moitié des cartes gagnées de l'adversaire",
                    "Exil = Exil une carte de la main de l'adversaire",
                    "Réinitialisation = Prend les cartes gagnée de l'adversaire et le remets dans les mains correspondantes",
                    "Hero invincible = Peut vaincre toutes les cartes",
                    "Roi = Si contre Prince, gagne.",
                    "Reine = Si contre Roi, gagne.",
                    "Prince = Si contre Reine, gagne."
            };

            const int maximumFormtSpecial = 15; //15
            int countLine = 0;

            foreach(string line in listLines){
                if (countLine < maximumFormtSpecial){
                    if (countLine == 0){

                        Console.Write(ColorLine.Color_Green+ColorLine.Text_Bold);
                        this.CenterText(line);
                        Console.Write(ColorLine.ResetBold+ColorLine.ResetAll);

                    } else if (countLine == 14) {
                        Console.Write(ColorLine.Color_Green+ColorLine.Text_Bold);
                        this.CenterText(line);
                        Console.Write(ColorLine.ResetBold+ColorLine.ResetAll);

                    } else {
                        this.CenterText(line);
                    }
                } else {
                    this.CenterText(line, 40);
                }
                countLine++;
                /*
                if (iLines != listLines.Count()){
                    Console.WriteLine();
                }*/
            }
            string s = "Appuyez sur n'importe quel touche pour retourner sur le menu";
            Console.WriteLine();
            this.CenterText(s);
            this.WaitKeys();
        }

        public void ShowGameLog(){
           
        }
        public void EndGame(Int32 player1, Int32 player2){
            Console.Clear();
            if (player1 > player2){
                this.CenterText("Le joueur 1 gagne");
                this.CenterText("Resultat du Joueur 1 : " + player1);
                this.CenterText("Resultat du Joueur 2 : " + player2);
            } else if (player1 < player2){
                this.CenterText("Le joueur 2 gagne");
                this.CenterText("Resultat du Joueur 1 : " + player1);
                this.CenterText("Resultat du Joueur 2 : " + player2);
            } else {
                this.CenterText("Tout les joueurs ont perdues...");
                this.CenterText("Resultat du Joueur 1 : " + player1);
                this.CenterText("Resultat du Joueur 2 : " + player2);
            }
            this.WaitKeys();
        }
        
        private Triangle PlayerChooseCard(Player p){
            /*
                Renvois la carte choisis par le joueur
            */
            Int32 indexCardSelected = 0;
            ushort indexCardInventory = 0;
            // string input = "";
            const ushort LimitSelection = 3;
            const ushort LimitShowCards = 3;
            ConsoleKeyInfo key;
            Int32 maxCardsNum = p.listPioche.Count();
            do{
                Console.Clear();
                this.CenterText(p.Name+", choissisez une carte:");
                Console.WriteLine();
                this.CenterText("^^^Z^^^");



                indexCardSelected += Convert.ToInt32(indexCardSelected < 0) - Convert.ToInt32(indexCardSelected > 9);
                indexCardInventory = 0;
                foreach(Triangle t in p.listPioche){
                    if (indexCardSelected < LimitSelection){
                        if (indexCardInventory <= LimitShowCards){
                            if (indexCardInventory == indexCardSelected){
                                this.CenterText("==>"+t._Name);
                            } else {
                                this.CenterText(t._Name);
                            }
                        }
                    } else {          
                        if (indexCardInventory > 2 && indexCardInventory < indexCardSelected+LimitShowCards){
                            if (indexCardSelected == indexCardInventory){
                                this.CenterText("==>"+t._Name);
                            } else {
                                this.CenterText(t._Name);
                            }
                        }
                    }

                    indexCardInventory++;
                }

                this.CenterText("^^^S^^^");
                this.CenterText("Enter?");
                key = Console.ReadKey();
                switch (key.Key.ToString()){
                    case "S":
                        indexCardSelected++;
                        break;
                    case "Z":
                        indexCardSelected--;
                        break;
                }
            } while(key.Key != ConsoleKey.Enter);
            return p.listPioche[indexCardSelected];
        }

        public (string, string) ShowPlayer(List<Player> listPlayers){
            // Console.Clear();
            int index = 0;
            string un = "Player 1";
            string deux = "Player 2";
            foreach(Player p in listPlayers){
                if (index == 0) {
                    un = p.Name;
                    index++;
                } else {
                    deux = p.Name;
                }
                
            }
            return (un, deux);
        }

        private void ShowRules(){
            List<string> listLines = new List<string>(){
                "Voici les règles:",
                "C'est un jeu de carte qui confronte deux adversaires. Ces adversaires vont s'affronter pour obtenir les cartes adverse !",
                "Le but du jeu est d'obtenir le plus de carte une fois les cartes épuisées",
                "Dans ce jeu, les cartes sont réparties en classes. [Famille_Royale, Chevalier, Assassin, Paysan]",
                "- La carte la plus forte remporte le pli.",
                "**A la fin de la partie, on compte le nombre de cartes de chacun, celui qui en a le plus l'emporte !**",
                "1. Les joueurs choississent une carte parmis leur carte disponible et la confronte à la carte adverse dans", 
                "*la zone de divulgation* puis sont retournée en meme temps.",
                "2. Lors d'une confrontation, *En cas d'égalité* on met les deux cartes de coté et le gagnant suivant les récupère.",
                "Entre les **10** cartes remise à chaques joueurs et la carte *BONUS* placée sur le tapis,", 
                "le jeu compte ***21 cartes*** en tout et pour tout.",
                "Bonne Dégustation !"
            };

            ushort iLines = 0;

            foreach(string line in listLines){
                this.CenterText(line);
                if (iLines != listLines.Count()){
                    Console.WriteLine();
                }
                iLines++;
            }
            string s = "Appuyez sur n'importe quel touche pour retourner sur le menu";
            Console.WriteLine();
            this.CenterText(s);
            this.WaitKeys();
        }
        
        private void OnError(string message){
            Console.WriteLine(message);
            Console.Beep();
            Thread.Sleep(60*10);
            Console.Clear();
        }

        //Permet de centrer un texte dans le terminal
        public void CenterText(string message, int forcePosition=-1){
            int StartPosition = (Console.WindowWidth/2) - (message.Length/2);
            if (forcePosition != -1){
                StartPosition = (Console.WindowWidth/2)-forcePosition;
            }
            // string result = "";
            for (ushort indexChar = 0; indexChar <= StartPosition; indexChar++){
                if (indexChar < StartPosition){
                    Console.Write(" ");
                } else {
                    Console.Write(message);
                }
            }
            Console.WriteLine();
        }

        /*Parametrer le nom du Player*/
        public string NomJoueur(){
            short Number = -1;

            while (Number == -1){
            string NamePlayer;
            Console.Write("Choisissez votre nom: ");
                do {
                    NamePlayer = Console.ReadLine();
                } while (NamePlayer == null);
                try{
                    switch (NamePlayer.Count()){
                    case < 3:
                    Console.WriteLine("Vous devez mettre au moins 3 caractères");
                    Thread.Sleep(60*10);
                    Console.Clear();
                    Number = -1;
                    break;
                    default:
                    Console.WriteLine("good input...");
                    Console.Clear();
                    return NamePlayer;
                    }
                }catch {
                    this.OnError("Une erreur s'est produite");
                }
            }
            return "Default";
        }

        public void IntroMessage(){
            List<string> listAsciiLines = new List<string>();
            listAsciiLines.Add(" /$$$$$$$  /$$                                                                      ");
            listAsciiLines.Add("| $$__  $$|__/                                                                      ");
            listAsciiLines.Add("| $$  \\ $$ /$$  /$$$$$$  /$$$$$$$  /$$    /$$ /$$$$$$  /$$$$$$$  /$$   /$$  /$$$$$$ ");
            listAsciiLines.Add("| $$$$$$$ | $$ /$$__  $$| $$__  $$|  $$  /$$//$$__  $$| $$__  $$| $$  | $$ /$$__  $$");
            listAsciiLines.Add("| $$__  $$| $$| $$$$$$$$| $$  \\ $$ \\  $$/$$/| $$$$$$$$| $$  \\ $$| $$  | $$| $$$$$$$$");
            listAsciiLines.Add("| $$  \\ $$| $$| $$_____/| $$  | $$  \\  $$$/ | $$_____/| $$  | $$| $$  | $$| $$_____/");
            listAsciiLines.Add("| $$$$$$$/| $$|  $$$$$$$| $$  | $$   \\  $/  |  $$$$$$$| $$  | $$|  $$$$$$/|  $$$$$$$");
            listAsciiLines.Add("|_______/ |__/ \\_______/|__/  |__/    \\_/    \\_______/|__/  |__/ \\______/  \\_______/");

            foreach(string line in listAsciiLines){
                this.CenterText(line);
            }

            Console.WriteLine();
            this.CenterText("Appuyer sur une touche pour continuer...");
            this.WaitKeys();
        }

        public void WaitKeys(){
            ConsoleKeyInfo Keys;
            do{
                Keys = Console.ReadKey();
            } while (Keys == null);

        }

        private void ExitMessage(){
            Console.Clear();
            List<string> listAsciiMessage = new List<string>(){};
            
            listAsciiMessage.Add(".----------------.  .----------------.  .----------------. ");
            listAsciiMessage.Add("| .--------------. || .--------------. || .--------------. |");
            listAsciiMessage.Add("| |   ______     | || |  ____  ____  | || |  _________   | |");
            listAsciiMessage.Add("| |  |_   _ \\    | || | |_  _||_  _| | || | |_   ___  |  | |");
            listAsciiMessage.Add("| |    | |_) |   | || |   \\ \\  / /   | || |   | |_  \\_|  | |");
            listAsciiMessage.Add("| |    |  __'.   | || |    \\ \\/ /    | || |   |  _|  _   | |");
            listAsciiMessage.Add("| |   _| |__) |  | || |    _|  |_    | || |  _| |___/ |  | |");
            listAsciiMessage.Add("| |  |_______/   | || |   |______|   | || | |_________|  | |");
            listAsciiMessage.Add("| |              | || |              | || |              | |");
            listAsciiMessage.Add("| '--------------' || '--------------' || '--------------' |");
            listAsciiMessage.Add("'----------------'  '----------------'  '----------------' ");

            foreach(string line in listAsciiMessage){
                this.CenterText(line);
                // Console.Beep();
            }
            
            Console.WriteLine();
            this.CenterText("Appuyer sur une touche");
            this.WaitKeys();

            Console.Clear();
        }
        /*Demande input mis dans une fonction pour etre répetable 
        en cas de mauvaise manipulation de l'input*/
         public int Askinput(string player){
            Console.Clear();
            this.CenterText(player+" à vos cartes!");
            Console.WriteLine();
            this.CenterText("[0]-Interrompre la partie",8);
            Console.WriteLine();
            this.CenterText("[1]-Choisir une carte",8);
            Console.WriteLine();
            int inputSelection = -1;
            string inputString;
            do {
                inputString = Console.ReadLine();
            } while (inputString == null);
 
            // if (inputString == "") {

            if (inputString == null){
                Console.WriteLine("réessai");
                Thread.Sleep(60*10);
                Askinput(player);
            }
            try{
                
                inputSelection = Int32.Parse(inputString);
                switch (inputSelection){
                    case 0:
                    return inputSelection;
                    
                    case 1:
                    return inputSelection;
                    
                    default:
                    Console.Clear();
                    Console.WriteLine("Vous ne pouvez choisir que 0 ou 1...");
                    Thread.Sleep(60*15);
                    return Askinput(player);
                }
            } catch {
                Console.WriteLine("Something went wrong for Askinput!");
                Askinput(player);
            }
            return inputSelection;
        }
        /*Une fois la carte choisie cette fonction permet 
        de d'afficher dans le terminal la carte choisie en detail*/
        public Triangle SelectionCard(Player player){
            Table t = new Table();
            InterfaceUI interfaceUI = new InterfaceUI();
            Triangle CarteJoueurUn;
            Triangle CarteJoueurDeux;
            string Newinput;
            do {
                // Console.Write("Newinput? ");
               Newinput = Console.ReadLine();
            } while (Newinput == null);
            
            Console.Clear();
            try {
                Int32 PlayerCard; 
                PlayerCard = Int16.Parse(Newinput);
                // PlayerCard = Newinput;

                //Matos de débugage
                //Console.WriteLine("Aide à résolution de probleme, \nNom du player: "+ player.Name+" Nombre de carte à sa disposition: "+ player.listPioche.Count());
                if (PlayerCard > 0 && PlayerCard <= player.listPioche.Count()){
                    if (player._Player == "Player 1") { //Player 1

                    Console.WriteLine("Cher "+player.Name);
                    Console.WriteLine("vous avez choisi la carte "+PlayerCard);

                    CarteJoueurUn = player.listPioche[PlayerCard-1];
                    CarteJoueurUn.Utilise = true;
                    // if (!string.IsNullOrEmpty(CarteJoueurUn._Name)){
                    //     Verifone = true;
                    // }
                    player.listPioche.Remove(CarteJoueurUn); // Fonctionne ?
                    t.UpdateCard(CarteJoueurUn); //NEW
                    //Fin d'aperçu
                    Console.WriteLine("Appuyez pour continuer");
                    interfaceUI.WaitKeys();
                    Console.Clear(); //test
                    return CarteJoueurUn;
                    } else { //Player 2
                
                    Console.WriteLine("Cher "+player.Name);
                    Console.WriteLine("vous avez choisi la carte "+PlayerCard);

                    CarteJoueurDeux = player.listPioche[PlayerCard-1];
                    CarteJoueurDeux.Utilise = true;

                    // player.listPioche.Remove(player.listPioche[PlayerCard-1]); // Fonctionne ?
                    player.listPioche.Remove(CarteJoueurDeux);
                    t.UpdateCard(CarteJoueurDeux); //NEW
                    //Fin d'aperçu
                    Console.WriteLine("Appuyez pour continuer");
                    interfaceUI.WaitKeys();
                    Console.Clear(); //test
                    return CarteJoueurDeux;
                    }
                } else {
                    Console.WriteLine("Mauvaise touche, 0 n'esiste pas");
                    Thread.Sleep(1*1000);
                    Console.Clear(); //test
                    //  SelectionCard(player);
                 }
            } catch { //pour des lettres ou autres informations arrive dans le catch
                Console.WriteLine("Bad try!");
            }
            return SelectionCard(player);
        } //fin de fonction selectionCard

        /*Fonction qui sert a créer un nom de fichier log 
        dans le chemin indiquer par GetPath()*/

        private string GetFileName(){
            Random random = new Random();
            string path = GetPath();
            bool fileExist = true;
            int indexFile = 9999;
            string[] listFiles = new string[0];
            while (fileExist){
                indexFile = random.Next(10000, 99999);
                listFiles = Directory.GetFiles(path);
                fileExist = listFiles.Contains(indexFile.ToString()+"_"+listFiles.Count().ToString());
            }
            string fn = indexFile.ToString()+"_"+listFiles.Count().ToString();
            return fn;
        }

        //Permet de récuperer le chemin pour enregistrer le fichier log
        private string GetPath(){
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath)+"/logs";
            return strWorkPath;
        }

    //écrit le fichier log
        public void WriteLog(string msg, string type=""){
            // Create a string array with the lines of text
            string strPath = GetPath();
            if (!Directory.Exists(strPath)){
                Directory.CreateDirectory(strPath);
            }
            if (this.fName == ""){
                this.fName = this.GetFileName()+".log";
            }
            var d = DateTime.Now;

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(strPath,fName), true))
            {
                if (type != ""){
                    // outputFile.Write("\033[38;2;255;0;0m");
                    outputFile.WriteLine(d.ToString()+">>"+type+">>"+msg);
                    // outputFile.Write("\033m");
                } else {
                    outputFile.WriteLine(d.ToString()+">>"+msg);
                }
            }
        }
    } //fin de classe
} //fin du namespace