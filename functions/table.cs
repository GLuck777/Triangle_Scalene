using System;


namespace Triangle_Scalene{
    class Table{

        List<string> listCards = new List<string>();

        public void CreateCase(List<Triangle> listPioches){
            int incrementation = 0;
            string card;
            foreach(Triangle triangle in listPioches){
                incrementation++;
                card = "________________________________";
                card += "\nTaper ["+incrementation+ "]: \n";
                card += "   Carte "+triangle._Name+"\n";
                card += "       Number :" + triangle._Number+"\n";
                if (triangle._Effect != ""){
                    card += "    Effect: " + triangle._Effect+"\n";
                    card += "    Description:\n" + triangle._Description+"\n";
                } else {
                    card += "    Effect: None\n";
                    card += "    \n\n";
                }
                card += "________________________________\n";
                
                this.listCards.Add(card);
            }
        }

        private string GetLine(ushort fromCard, ushort maxCardsByLine = 3){
            /*
                Cette méthode permet de construire la ligne et de l'obtenir
                à l'aide d'une string.
                Durant l'itération des cartes, initialialement toutes les cartes
                sont contenus dans l'itération cependant grâce à les arguments suivant:
                    fromCard (ushort) indique à partir dequelle carte l'affichage commence
                    endCard (ushort) indique à partir de quelle carte l'affichage prend fin
            */
            const ushort maxLines = 7;
            const ushort maxSpacesBtwCard = 42;
            Int32 toEnd = fromCard + maxCardsByLine;
            ushort countCardByLine = 0;
            string rows = "";
            string line = "";
            for(Int32 y = 0; y <= maxLines; y++){
                countCardByLine = 0;
                foreach(string card in this.listCards){
                    if (countCardByLine >= fromCard && countCardByLine <= toEnd){
                        rows = card.Split("\n")[y];
                        line += rows;
                        /*
                        if (countCardByLine == maxCardsByLine){
                            break;
                        }*/
                        while (rows.Length < maxSpacesBtwCard){
                            rows += " ";
                            line += " ";
                        }
                    } else if (countCardByLine > toEnd){
                        break;
                    }
                    countCardByLine ++;
                }
                line += "\n";
            }

            return line;
        }


        public void DrawCase(InterfaceUI interfaceUI=null){
            /*
                Cette méthode est appelé pour dessiner le tableau de selection de carte.
                
                Pour afficher une carte (un élément de la liste), deux boucles for seront utilisé:
                    Une première pour les colonnes; 
                    Une seconde pour les cellules ou lignes,
                        ATTENTION:Celle-ci affiche la ligne par lignes, c'est à dire qu'elle itère
                        sur une hauteur données de la carte

                Pour l'affichage d'une ligne (boucle finale) à la fin de l'itération:
                    Les espaces pour séparer chacune des cartes sont mis   
            */
            Console.Clear();
            ushort indexCard = 0;
            string line;
            //Faut faire en sorte que cette itération se fasse sur plusieurs étages,
            //Sans la première boucle les trois premières colonnes de la ligne 1 sont bien affiché
            //Peut-être que la division (10/7) est (10/5)
            for (int etage =0; etage <  10*7; etage+=7){
                line = this.GetLine(indexCard);
                indexCard += 3;
                foreach(string l in line.Split("\n")){
                    interfaceUI.CenterText(l);
                }
            }
        }
    
        public void UpdateCard(Triangle cartejoueur){
            
        
            
            Console.WriteLine(cartejoueur._Name);
            //Aperçu de la carte choisie
            Console.WriteLine("________________________________");
            Console.Write(" Carte: "+cartejoueur._Name+"\n");
            Console.Write("\t  Number: " + cartejoueur._Number+"\n");
            if (cartejoueur._Effect!=""){
                Console.Write("\t  Effect: " + cartejoueur._Effect+"\n");
                Console.Write("\t  Description:\n" + cartejoueur._Description+"\n");
            } else {
                Console.Write("\t  Effect: None\n");
            }
            Console.WriteLine("________________________________\n");
        }
    }
}