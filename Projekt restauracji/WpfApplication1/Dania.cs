﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Dania
    {
        public int ID { get; set; }                       // zmienne 
        public string Danie { get; set; }
        public float Cena { get; set; }
        public Dania() { }
        public Dania(int ID,string Danie,float Cena,rodzajDania jakieDanie) 
        {
            this.ID = ID;
            this.Danie = Danie;
            this.Cena = Cena;
            this.jakieDanie = jakieDanie;
        }
        public enum rodzajDania { Herbata, Kawa, Napoj, Alkohole, Przystawka, Zupa, DanieGłówne, Pizza,Deser,Dodatki };
        public rodzajDania jakieDanie {get; set;}
     
    }
}
