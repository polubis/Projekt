using System;
using System.Collections.Generic;      // potrzebna do sortowania
using System.Collections.ObjectModel;  // potrzebna do sort desc
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        ObservableCollection<Dania> DaniaList = new ObservableCollection<Dania>();
        ObservableCollection<Dania> DaniaListCopied = new ObservableCollection<Dania>();
        
        public Menu()
        {
            InitializeComponent();
            // Spis dan w MENU
            #region
            DaniaList.Add(new Dania(1, "CocaCola 330ml", 4, "Napoj"));
            DaniaList.Add(new Dania(2, "Sprite 330ml", 4, "Napoj"));
            DaniaList.Add(new Dania(3, "Fanta 330ml", 4, "Napoj"));
            DaniaList.Add(new Dania(4, "Pepsi 330ml", 4, "Napoj"));
            DaniaList.Add(new Dania(5, "Mirinda 330ml", 4, "Napoj"));
            DaniaList.Add(new Dania(6, "Woda gazowana 0.5l", 3, "Napoj"));
            DaniaList.Add(new Dania(7, "Woda niegazowana 0.5l", 3, "Napoj"));
            DaniaList.Add(new Dania(8, "Sok owocowy 0.5l", 4, "Napoj"));
            DaniaList.Add(new Dania(9, "Czarna", 5, "Kawa"));
            DaniaList.Add(new Dania(10, "Espresso", 6, "Kawa"));
            DaniaList.Add(new Dania(11, "Latte", 8, "Kawa"));
            DaniaList.Add(new Dania(12, "Americana", 11, "Kawa"));
            DaniaList.Add(new Dania(13, "Chaina", 15, "Kawa"));
            DaniaList.Add(new Dania(14, "Kawa biała", 7, "Kawa"));
            DaniaList.Add(new Dania(15, "Kawa zimna", 10, "Kawa"));
            DaniaList.Add(new Dania(16, "Herbata owocowa", 7, "Kawa"));
            DaniaList.Add(new Dania(17, "Zwykła", 5, "Herbata"));
            DaniaList.Add(new Dania(18, "Elgrey", 9, "Herbata"));
            DaniaList.Add(new Dania(19, "Yerbamate", 11, "Herbata"));
            DaniaList.Add(new Dania(20, "Mix", 13, "Herbata"));
            DaniaList.Add(new Dania(21, "Zupa dnia", 5, "Zupa"));
            DaniaList.Add(new Dania(22, "Rosół", 6, "Zupa"));
            DaniaList.Add(new Dania(23, "Ogórkowa", 6, "Zupa"));
            DaniaList.Add(new Dania(24, "Pomidorro", 6, "Zupa"));
            DaniaList.Add(new Dania(25, "Krupnik", 6, "Zupa"));
            DaniaList.Add(new Dania(26, "Zupa krem", 7, "Zupa"));
            DaniaList.Add(new Dania(27, "Bułeczki pizzowe", 5, "Przystawka"));
            DaniaList.Add(new Dania(28, "Pieczywko tostowe", 6, "Przystawka"));
            DaniaList.Add(new Dania(29, "Rollada", 8, "Przystawka"));
            DaniaList.Add(new Dania(30, "Podbrzuszek", 6, "Przystawka"));
            DaniaList.Add(new Dania(31, "Ciasteczka prawdy", 5, "Przystawka"));
            DaniaList.Add(new Dania(32, "HNZ", 10, "Przystawka"));
            DaniaList.Add(new Dania(33, "Skrzydełka", 15, "DanieGłówne"));
            DaniaList.Add(new Dania(34, "Pierś z kuraczaka", 14, "DanieGłówne"));
            DaniaList.Add(new Dania(35, "Sandacz w sosie szpinakowym", 17, "DanieGłówne"));
            DaniaList.Add(new Dania(36, "Sandacz w sosie koperkowym", 19, "DanieGłówne"));
            DaniaList.Add(new Dania(37, "Sandacz w sosie śmietanowym", 21, "DanieGłówne"));
            DaniaList.Add(new Dania(38, "Pstrąg z grilla", 17, "DanieGłówne"));
            DaniaList.Add(new Dania(39, "Łazanki", 17, "DanieGłówne"));
            DaniaList.Add(new Dania(40, "Frytki ze stynki", 11, "DanieGłówne"));
            DaniaList.Add(new Dania(41, "Kotlet schabowy", 15, "DanieGłówne"));
            DaniaList.Add(new Dania(42, "Owoce morza", 13, "DanieGłówne"));
            DaniaList.Add(new Dania(43, "Zapiekanka mazurska", 11, "DanieGłówne"));
            DaniaList.Add(new Dania(44, "Łosoś", 17, "DanieGłówne"));
            DaniaList.Add(new Dania(45, "Makrela w occie", 17.5, "DanieGłówne"));
            ListaDan.ItemsSource = DaniaList;
          
            #endregion
            ApplicationCommands.Open.InputGestures.Add(new KeyGesture(Key.K, ModifierKeys.Control));  // Uzbrojenie kontrolek w skrot
            ApplicationCommands.Delete.InputGestures.Add(new KeyGesture(Key.Delete));

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListaDan.ItemsSource); // inicjalizacja i deklaracja nowego widoku na bazie z listy wyzej
            view.Filter = IdFilter;                                                                          // Przypisanie wyniku funkcji do zmiennej view
            
            // ListaDan i ListaDanCopied sa to listy w kodzie XAML DaniaList i DaniaListCopied - kod C#

            

        }
        #region
        private bool IdFilter(object item)  // Sprawdza czy obiekt jest 0 albo pusty
        {
            if (string.IsNullOrEmpty(txtIdNazwaFilter.Text))
                return true;
            else
                return ((item as Dania).ID.ToString().IndexOf(txtIdNazwaFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) 
                    || ((item as Dania).Danie.IndexOf(txtIdNazwaFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Dania).Rodzaj.IndexOf(txtIdNazwaFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtIdNazwaFilter_TextChanged(object sender, TextChangedEventArgs e) // Funkcja aktualizujaca liste po wyszukiwaniu
        {
            CollectionViewSource.GetDefaultView(ListaDan.ItemsSource).Refresh();
        }
        #endregion
       
        private void UsunWybrany()
        {
            int wybranyWiersz = ListaDan.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
                DaniaList.RemoveAt(wybranyWiersz);
        }
        private void CommandBinding_CanExecute_3(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e) // Zamykanie aplikacji
        {
            Application.Current.Shutdown();
        }

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e) // Otwieranie kalkulatora
        {
            Kalkulator ob3 = new Kalkulator();
            ob3.Show();
        }

        private void add_button(object sender, RoutedEventArgs e)  // Przycisk dodajacy wartosci do pol Menu
        {
            
            if (string.IsNullOrEmpty(Convert.ToString(pobierzID.Text)) || string.IsNullOrEmpty(pobierzDanie.Text) || string.IsNullOrEmpty(Convert.ToString(pobierzCene.Text)) || string.IsNullOrEmpty(pobierzRodzaj.Text))
            {
                
                MessageBox.Show("Nie dodałeś wartości do pól");
            }
            else
            {
                
                DaniaList.Add(new Dania(Convert.ToInt32(pobierzID.Text), pobierzDanie.Text, double.Parse(pobierzCene.Text),pobierzRodzaj.Text)); 
            }
        }

        private void delete_button(object sender, RoutedEventArgs e) // Przycisk usuwajacy wartosc z Menu
        {
            UsunWybrany();
        }

    

        private void BdodajDoRachunku(object sender, RoutedEventArgs e)
        {
             
                Dania WybranyWiersz = (Dania)ListaDan.SelectedItem;
                DaniaListCopied.Add(new Dania(WybranyWiersz.ID, WybranyWiersz.Danie, WybranyWiersz.Cena, WybranyWiersz.Rodzaj));
                ListaDanCopy.ItemsSource = DaniaListCopied;
            
        }

        private void BUsunZRachunku(object sender, RoutedEventArgs e)
        {
            int wybranyWiersz =ListaDanCopy.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
                DaniaListCopied.RemoveAt(wybranyWiersz);
        }

        private void BObliczKwote(object sender, RoutedEventArgs e)
        {
            DateTime OstatniaDataSprzedazy = DateTime.Today;
            
             int RozmiarListy = DaniaListCopied.Count;
             double[] tablica = new double[RozmiarListy];
             double Suma=0;
             int i = 0;
            foreach(var element in DaniaListCopied)
            {
                tablica[i] = element.Cena;
                i++;
            }
            for(int j=0;j<DaniaListCopied.Count;j++)
            {
                Suma += tablica[j];
             
            }
            
            MessageBox.Show("Kwota do zaplaty "+Convert.ToString(Suma));
            StreamWriter TworzeFakture = new StreamWriter("Faktura.txt");
            using(TworzeFakture)
            {
                TworzeFakture.WriteLine(OstatniaDataSprzedazy.ToString());
             foreach(var element in DaniaListCopied)
             {
                
                TworzeFakture.WriteLine("{0},{1},{2},{3} ",element.ID.ToString(), element.Danie.ToString(), element.Cena.ToString(), element.Rodzaj.ToString());
             }
             TworzeFakture.WriteLine("Zapłacono : {0}", Suma.ToString());
            }
            DaniaListCopied.Clear();
            
        }
       
      

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int LiczbaRekordowBazie = DaniaList.Count;
            MessageBox.Show("Liczba rekordow w bazie : " + Convert.ToString(LiczbaRekordowBazie));
            int LiczbaRekordowKoszyk = DaniaListCopied.Count;
            MessageBox.Show("Liczba rekordow w koszyku : " + Convert.ToString(LiczbaRekordowKoszyk));

        }

        // Ustawienie kontrolki DELETE
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)  
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int wybranyWiersz = ListaDanCopy.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
                DaniaListCopied.RemoveAt(wybranyWiersz);

        }

    }
     

     
    }


