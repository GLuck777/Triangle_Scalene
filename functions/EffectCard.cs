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
        public void Roi(string card1,string card2){
            if (card2)
            //Roi KILL Prince
            
            
        }
        public void Reine(string card1,string card2){
            //Reine KILL Roi
        }
        public void Prince(string card1,string card2){
            //Prince Kill Reine
        }
    }
}