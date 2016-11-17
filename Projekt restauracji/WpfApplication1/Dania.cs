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
        public Dania() { }
        public Dania(int ID, string Danie, double Cena)
        {
            this.ID = ID;
            this.Danie = Danie;
            this.Cena = Cena;
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
    public enum rodzajDania { Herbata, Kawa, Napoj, Alkohole, Przystawka, Zupa, DanieGłówne, Pizza, Deser, Dodatki };  // Kopia enum z klasy wyzej. Jest potrzebna, aby kod w xamlu mogl zbindowac wartosci enum
                                                                                                                      // z ComboBoxem, ktory wyswietla wartosci enum i pobiera wybrana wartosc
}
