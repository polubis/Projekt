using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Uzytkownik:ICheckpassword
    {
        private string Login { get; set; }
        private string Haslo { get; set; }
        public string ZwracamLogin()
        {
            return Login;
        }
        public string ZwracamHaslo()
        {
            return Haslo;
        }
        public Uzytkownik() { }
        public Uzytkownik(string Login,string Haslo)
        {
            this.Login = Login;
            this.Haslo = Haslo;
        }
        public bool SprawdzamLogowanie(string Login,string Haslo)
        {
            if (this.Login == Login && this.Haslo == Haslo)
                return true;
            else
                return false;
        }
        
        
    
    }
}
