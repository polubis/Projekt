using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Uzytkownicy
    {
        protected internal string Login { get; set; }
        protected internal string Haslo { get; set; }
        public Uzytkownicy() { }
        public Uzytkownicy(string Login,string Haslo)
        {
            this.Login = Login;
            this.Haslo = Haslo;
        }
      

        
        
    
    }
}
