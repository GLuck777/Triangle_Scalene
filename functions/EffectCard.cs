using System;
using System.Reflection.Metadata.Ecma335;

namespace Triangle_Scalene{
    class EffectCard{
        public void Cheval_de_troie(string card1,string card2){

        }
        public void Croissance_Explosive(string card1,string card2){}
        public void Grande_Revolution(string card1,string card2){}
        public void Exil(string card1,string card2){}
        public void Reinitialisation(string card1,string card2){}
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