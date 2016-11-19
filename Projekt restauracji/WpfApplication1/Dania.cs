using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Dania
    {
        public int ID { get; set; }                       // Zmienne 
        public string Danie { get; set; }
        public double Cena { get; set; }
        public string Rodzaj { get; set; }
     
        public Dania() { }
        public Dania(int ID, string Danie, double Cena,string Rodzaj)
        {
            this.ID = ID;
            this.Danie = Danie;
            this.Cena = Cena;
            this.Rodzaj = Rodzaj;

        }
        public Dania(int ID,string Danie,double Cena,rodzajDania jakieDanie) 
        {
            this.ID = ID;
            this.Danie = Danie;
            this.Cena = Cena;
            this.jakieDanie = jakieDanie;
        }
      
       
        public enum rodzajDania { Herbata, Kawa, Napoj, Alkohole, Przystawka, Zupa, DanieGłówne, Pizza, Deser, Dodatki };
        public rodzajDania jakieDanie {get; set;} 
    }
   
}
