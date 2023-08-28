// using Internal;
using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Collections;


/*
This file contains a C# class witch is dedicated for the output console
*/

namespace Triangle_Scalene
{
    class InterfaceUI{

        const ushort MAX_PLAYER = 2;

        public Plateau plateau = new Plateau();

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
                this.CenterText("[0]-Quitter", LeftPosMessage);
                String input = Console.ReadLine();
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

        public void ShowGameLog(){
           
        }
        private void EndGame(string playersWon){
            Console.Clear();
            if (playersWon == "player1"){
                this.CenterText("Le joueur 1 gagne");
            } else if (playersWon == "player2"){
                this.CenterText("Le joueur 2 gagne");
            } else {
                this.CenterText("Tout les joueurs ont perdues...");
            }
            this.WaitKeys();
        }
        
        private Triangle PlayerChooseCard(Player p){
            /*
                Renvois la carte choisis par le joueur
            */
            Int32 indexCardSelected = 0;
            ushort indexCardInventory = 0;
            string input = "";
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

        public void ShowGameScore(List<Player> listPlayers){
            Console.Clear();
            foreach(Player p in listPlayers){

            }
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

        public void CenterText(string message, int forcePosition=-1){
            int StartPosition = (Console.WindowWidth/2) - (message.Length/2);
            if (forcePosition != -1){
                StartPosition = (Console.WindowWidth/2)-forcePosition;
            }
            string result = "";
            for (ushort indexChar = 0; indexChar <= StartPosition; indexChar++){
                if (indexChar < StartPosition){
                    Console.Write(" ");
                } else {
                    Console.Write(message);
                }
            }
            Console.WriteLine();
        }


        void ShowPlayerCard(){

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
    }   
}