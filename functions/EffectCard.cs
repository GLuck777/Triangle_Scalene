using System;
using System.Reflection.Metadata.Ecma335;

namespace Triangle_Scalene{
    class EffectCard{
        Program p = new Program();
        // Plateau plateau = new Plateau();

        // EffectCard(Plateau p){
        //     this.plateau = p;
        // }

        public void Cheval_de_troie(Player joueur1, Player joueur2){
            /*
                La personne qui remporte cette carte perd la moitié de sa liste carte gagné et
                les cartes perdus sont transferée vers l'autre joueur (si cdt appartient au
                joueur qui la remporte alors l'effet n'est pas activé)
            */
        }
        public void Croissance_Explosive(string card1,string card2){
           /*
             gagne les cartes s'il ya qui se trouvent dans les cartes gagnaient
           */
        }
        public void Grande_Revolution(string card){
        //     card.Add(p.cardBonus);
        }
        public void Exil(string card1,string card2){
            /*
            carte adverse est transférée vers le graveyards cependant la carte exil fait égalité
            */
        }
        public void Reinitialisation(Player joueur1, Player joueur2, List<Triangle> list1, List<Triangle> list2){
            /*
            une fois la carte activé dans la zone de confrontation les deux zones de carte gagnées
            se réinitialisent (toutes les cartes retourne dans la main du propriétaire de la carte)
            cela n'affecte pas la zone de confrontation

            */
            int index = 0;
            bool isFound = false;
            foreach(Triangle rediscard1 in list1){
                if (rediscard1.Set == joueur1.GetSet()) {
                    joueur1.listPioche.Add(rediscard1);
                    isFound = true;                    
                } else {
                    joueur2.listPioche.Add(rediscard1);
                    isFound = true;
                }
                index += 1*Convert.ToInt32(!isFound);
            }
            Console.WriteLine("Removeateffectue", index);
            list1.RemoveAt(index+1);


            isFound = false;
            index = 0;

            foreach(Triangle rediscard2 in list2){
                if (rediscard2.Set == joueur1.GetSet()) {
                    joueur1.listPioche.Add(rediscard2);
                    isFound = true;
                } else {
                    joueur2.listPioche.Add(rediscard2);
                    isFound = true;
                }
                index += 1*Convert.ToInt32(!isFound);
            }
            Console.WriteLine("Removeateffectue", index);
            list2.RemoveAt(index+1);

            // joueur2.GetSet();
        }
        public void Hero_invincible(string card1,string card2){}
        public bool Roi(string card1,string card2){
            String str = card2;
            Int32 count = 2;
            String[] strlist = str.Split(" ", count,
               StringSplitOptions.RemoveEmptyEntries);
            foreach(String s in strlist)
            {
            //Console.WriteLine(s);
            
                if (s == "Prince"){
                //Roi KILL Prince
                    return true;
                } else {
                    return false;
                }
            }
            return false;    
        }
        public bool Reine(string card1,string card2){
            String str = card2;
            Int32 count = 2;
            String[] strlist = str.Split(" ", count,
               StringSplitOptions.RemoveEmptyEntries);
            foreach(String s in strlist)
            {
            //Console.WriteLine(s);
            
                if (s == "Roi"){
                //Reine KILL Roi
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }
        public bool Prince(string card1,string card2){
            String str = card2;
            Int32 count = 2;
            String[] strlist = str.Split(" ", count,
               StringSplitOptions.RemoveEmptyEntries);
            foreach(String s in strlist)
            {
                //Console.WriteLine(s);
            
                if (s == "Reine"){
                //Prince Kill Reine
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }
    }
}