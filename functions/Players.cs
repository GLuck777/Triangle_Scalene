using System;


namespace Triangle_Scalene{
    class Players{

        public List<Player> ListPlayers = new List<Player>() {};
        public void AddPlayer(Int16 playerNumber, List<Triangle> listCards){
            /*
                Ajoutes les instances de joueur (Player) en fonction d'un nombre
                précis (playerNumber) passé en argument.

                Les joueurs ont donc leurs numéros dans l'ordre de création
                attribué

                Une classe de joueur se définit avec un type
                dont ce type ici est assigner de manière paire/impaire
                voir fonction 'GetPlayerType'
            */
            InterfaceUI interfaceUI = new InterfaceUI();
            Random rnd = new Random();
            List<string> Set = new List<string>(){"A","B"};
            int mIndex = rnd.Next(Set.Count);
            // string type = "B";
            string type = Set[mIndex];
           
            for(int i = 1; i <= playerNumber; i++){
                type = this.GetPlayerType(type);
                Console.WriteLine("Pour le player "+i.ToString()+" Voici votre set " + type);
                
                string NamePlayer = interfaceUI.NomJoueur(); /*Permet de mettre son nom comme Player*/
                if (NamePlayer == "") {
                    NamePlayer = "Player "+i.ToString();
                }
                // Player player = new Player("Player "+i.ToString(), type);
                Player player = new Player(NamePlayer, type);
                player.GeneratePioche(listCards);
                this.ListPlayers.Add(player);
            }
        }

        private string GetPlayerType(string t){
            /*
                Retourne le type d'un joueur
                Selon la documentation apporté par README:
                '
                    SetA appelée "la main forte"
                    SetB appelée "la main faible"
                '
                Ici 'Set' est supprimé mais la lettre finale en majuscule
                est gardé.
            */
            if (t == "B"){
                return "A";
            }
            return "B";
        }


    }
}