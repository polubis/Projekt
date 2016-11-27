using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    class Uzytkownik:ICheckpassword
    {
        private string Login;
        private string Haslo;
        private List<Uzytkownik> ListaUzytkownikow; // Deklaracja pola, listy 
        public Uzytkownik()
        {
            ListaUzytkownikow = new List<Uzytkownik>();       // W konstruktorze automatycznie tworzona jest lista
        }
        public Uzytkownik(string Login, string Haslo)
        {
            this.Login = Login;
            this.Haslo = Haslo;
        }
        public void TworzeKonto(string Login, string Haslo)               // Zakaldam konto, 1. sprawdza czy wartosci w textboxie albo passboxie sa puste. Jezeli tak to wyswietla komunikat
        {
            if (String.IsNullOrEmpty(Login) || String.IsNullOrEmpty(Haslo))
            {
                MessageBox.Show("Nie masz wartosci w polach");

            }
            else
            {                                                                          // Dodaje nowego uzytkownika do listy, Nastepnie zapisuje do pliku tekstowego jego dane i zamyka odczyt strumienia
                ListaUzytkownikow.Add(new Uzytkownik(Login, Haslo));
                if (File.Exists(Login + ".txt"))
                {
                    MessageBox.Show("Takie konto juz istnieje !");
                }
                if (!File.Exists(Login + ".txt"))
                {
                    TextWriter Strumien = new StreamWriter(Login + ".txt", true);
                    TworzePlikTxt(Strumien, Login, Haslo);
                    Strumien.Close();
                    MessageBox.Show("Utworzono konto");
                }
            }
        }
        private void TworzePlikTxt(TextWriter strumien, string Login, string Haslo)
        {
            using (strumien)
            {
                strumien.WriteLine(Login + Haslo+":"); // Tworzy plik txt
            }
        }
        public bool Sprawdzam(string Login,string Haslo, StreamReader Odczyt,bool SprawdzamLogin,bool SprawdzamHaslo) // Sprawdza czy dane wejsciowe sa poprawne z tymi w pliku tekstowym.
        {
            using(Odczyt)
            {
                if (SprawdzamLogin|| SprawdzamHaslo)
                {
                    MessageBox.Show("Zalogowano");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
     
 
    
    }
}
