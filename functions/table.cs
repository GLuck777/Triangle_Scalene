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


        public void DrawCase(){
            Console.Clear() ;
            Int32 indexHorizontal = 0;
            Int32 maximumHorizontal = 4; //attention valeur-2 à prendre en compte
            Int32 maximumWidth = 42;
            string line;
            //Faut faire en sorte que cette itération se fasse sur plusieurs étages,
            //Sans la première boucle les trois premières colonnes de la ligne 1 sont bien affiché
            //Peut-être que la division (10/7) est (10/5)
            for (int etage =0; etage <  10*7; etage+=7){
                for (int i = 0; i <= 7; i++){
                    indexHorizontal = 0;
                    foreach(string c in this.listCards){
                        line = c.Split("\n")[i+i];
                        indexHorizontal += Convert.ToInt32(indexHorizontal <= maximumHorizontal);
                        if (indexHorizontal == maximumHorizontal){
                            break;
                        }
                        Console.Write(line);
                        while(line.Length < maximumWidth){
                            line += " ";
                            Console.Write(" ");
                        }
                    }

                    Console.WriteLine();
                    
                }
                Console.WriteLine();
            }
            /*
            for (int i=0; i <= 7; i++){
                indexHorizontal = 0;
                isLineEnough = false;
                foreach(string c in this.listCards){
//                    if (!isLineEnough)
//                    {
                        if (indexHorizontal == maximumHorizontal){
                            break;
                        }
                        //isLineEnough = Convert.ToInt32(indexHorizontal <= maximumHorizontal);
                        line = c.Split('\n')[i];
                        Console.Write(line);
                        while (line.Length < maximumWidth)
                        {
                            line += " ";
                            Console.Write(" ");
                        }

//                    }
                }
                Console.WriteLine();
            }*/
            /*
            foreach(string c in this.listCards){
                for(int i = 0; i < 7; i++) {
                    Console.Write(c.Split('\n')[i]);
                }
                indexHorizontal += Convert.ToInt32(indexHorizontal <= maximumHorizontal);
                if (indexHorizontal == maximumHorizontal){
                    indexHorizontal = 0;
                    Console.WriteLine();
                }
                
            }*/

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