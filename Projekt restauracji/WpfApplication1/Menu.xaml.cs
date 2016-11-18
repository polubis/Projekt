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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        ObservableCollection<Dania> daniaList = new ObservableCollection<Dania>();
        ObservableCollection<Dania> daniaListCopied = new ObservableCollection<Dania>();
        public Menu()
        {
            InitializeComponent();
            // Spis dan w MENU
            #region
            daniaList.Add(new Dania(1, "CocaCola 330ml", 4, "Napoj"));
            daniaList.Add(new Dania(2, "Sprite 330ml", 4, "Napoj"));
            daniaList.Add(new Dania(3, "Fanta 330ml", 4, "Napoj"));
            daniaList.Add(new Dania(4, "Pepsi 330ml", 4, "Napoj"));
            daniaList.Add(new Dania(5, "Mirinda 330ml", 4, "Napoj"));
            daniaList.Add(new Dania(6, "Woda gazowana 0.5l", 3, "Napoj"));
            daniaList.Add(new Dania(7, "Woda niegazowana 0.5l", 3, "Napoj"));
            daniaList.Add(new Dania(8, "Sok owocowy 0.5l", 4, "Napoj"));
            daniaList.Add(new Dania(9, "Czarna", 5, "Kawa"));
            daniaList.Add(new Dania(10, "Espresso", 6, "Kawa"));
            daniaList.Add(new Dania(11, "Latte", 8, "Kawa"));
            daniaList.Add(new Dania(12, "Americana", 11, "Kawa"));
            daniaList.Add(new Dania(13, "Chaina", 15, "Kawa"));
            daniaList.Add(new Dania(14, "Kawa biała", 7, "Kawa"));
            daniaList.Add(new Dania(15, "Kawa zimna", 10, "Kawa"));
            daniaList.Add(new Dania(16, "Herbata owocowa", 7, "Kawa"));
            daniaList.Add(new Dania(17, "Zwykła", 5, "Herbata"));
            daniaList.Add(new Dania(18, "Elgrey", 9, "Herbata"));
            daniaList.Add(new Dania(19, "Yerbamate", 11, "Herbata"));
            daniaList.Add(new Dania(20, "Mix", 13, "Herbata"));
            daniaList.Add(new Dania(21, "Zupa dnia", 5, "Zupa"));
            daniaList.Add(new Dania(22, "Rosół", 6, "Zupa"));
            daniaList.Add(new Dania(23, "Ogórkowa", 6, "Zupa"));
            daniaList.Add(new Dania(24, "Pomidorro", 6, "Zupa"));
            daniaList.Add(new Dania(25, "Krupnik", 6, "Zupa"));
            daniaList.Add(new Dania(26, "Zupa krem", 7, "Zupa"));
            daniaList.Add(new Dania(27, "Bułeczki pizzowe", 5, "Przystawka"));
            daniaList.Add(new Dania(28, "Pieczywko tostowe", 6, "Przystawka"));
            daniaList.Add(new Dania(29, "Rollada", 8, "Przystawka"));
            daniaList.Add(new Dania(30, "Podbrzuszek", 6, "Przystawka"));
            daniaList.Add(new Dania(31, "Ciasteczka prawdy", 5, "Przystawka"));
            daniaList.Add(new Dania(32, "HNZ", 10, "Przystawka"));
            daniaList.Add(new Dania(33, "Skrzydełka", 15, "DanieGłówne"));
            daniaList.Add(new Dania(34, "Pierś z kuraczaka", 14, "DanieGłówne"));
            daniaList.Add(new Dania(35, "Sandacz w sosie szpinakowym", 17, "DanieGłówne"));
            daniaList.Add(new Dania(36, "Sandacz w sosie koperkowym", 19, "DanieGłówne"));
            daniaList.Add(new Dania(37, "Sandacz w sosie śmietanowym", 21, "DanieGłówne"));
            daniaList.Add(new Dania(38, "Pstrąg z grilla", 17, "DanieGłówne"));
            daniaList.Add(new Dania(39, "Łazanki", 17, "DanieGłówne"));
            daniaList.Add(new Dania(40, "Frytki ze stynki", 11, "DanieGłówne"));
            daniaList.Add(new Dania(41, "Kotlet schabowy", 15, "DanieGłówne"));
            daniaList.Add(new Dania(42, "Owoce morza", 13, "DanieGłówne"));
            daniaList.Add(new Dania(43, "Zapiekanka mazurska", 11, "DanieGłówne"));
            daniaList.Add(new Dania(44, "Łosoś", 17, "DanieGłówne"));
            daniaList.Add(new Dania(45, "Makrela w occie", 17.5, "DanieGłówne"));
            listaDan.ItemsSource = daniaList;
          
            #endregion
            ApplicationCommands.Open.InputGestures.Add(new KeyGesture(Key.K, ModifierKeys.Control));  // uzbrojenie kontroli w skrot
            ApplicationCommands.Delete.InputGestures.Add(new KeyGesture(Key.Delete));

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaDan.ItemsSource); // inicjalizacja i deklaracja nowego widoku na bazie z listy wyzej
            view.Filter = IdFilter;             // Przypisanie wyniku funkcji do zmiennej view

          

          

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
            CollectionViewSource.GetDefaultView(listaDan.ItemsSource).Refresh();
        }
        #endregion
       

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

        private void add_button(object sender, RoutedEventArgs e)  // Przycisk dodajacy wartosci do pol 
        {
            
            if (string.IsNullOrEmpty(Convert.ToString(pobierzID.Text)) || string.IsNullOrEmpty(pobierzDanie.Text) || string.IsNullOrEmpty(Convert.ToString(pobierzCene.Text)) || string.IsNullOrEmpty(pobierzRodzaj.Text))
            {
                
                MessageBox.Show("Nie dodałeś wartości do pól");
            }
            else
            {
                daniaList.Add(new Dania(Convert.ToInt32(pobierzID.Text), pobierzDanie.Text, double.Parse(pobierzCene.Text),pobierzRodzaj.Text)); 
            }
        }

        private void delete_button(object sender, RoutedEventArgs e) // przycisk usuwajacy wybrana wartosc
        {
            
            int wybranyWiersz = listaDan.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if(wybranyWiersz!=-1)
            daniaList.RemoveAt(wybranyWiersz);
             
          
        }

        private void listaDan_SelectionChanged(object sender, SelectionChangedEventArgs e) // przechwytuje zaznaczenie
        {
        }

        private void BdodajDoRachunku(object sender, RoutedEventArgs e)
        {
            int WybranyWiersz = listaDan.SelectedIndex;
            if(WybranyWiersz!=-1)
            {

                foreach (var element in daniaList)
                {
                        daniaListCopied.Add(new Dania(element.ID, element.Danie, element.Cena,element.Rodzaj));
                        break;
                    
                }
                ListaDanCopy.ItemsSource = daniaListCopied;
            }
        }

        private void BUsunZRachunku(object sender, RoutedEventArgs e)
        {

            int wybranyWiersz = ListaDanCopy.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
                daniaListCopied.RemoveAt(wybranyWiersz);
        }

        private void BObliczKwote(object sender, RoutedEventArgs e)
        {

          foreach(var element in daniaListCopied)
          {
             double wynik = element.ObliczCene(daniaListCopied.Count, element.Cena);

            
             Wyswietl(wynik);
          }

          
         
        }
      
        private void Wyswietl(double Wynik)
        {
            MessageBox.Show(Convert.ToString(Wynik));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int LiczbaRekordowBazie = daniaList.Count;
            MessageBox.Show("Liczba rekordow w bazie : " + Convert.ToString(LiczbaRekordowBazie));
            int LiczbaRekordowKoszyk = daniaListCopied.Count;
            MessageBox.Show("Liczba rekordow w koszyku : " + Convert.ToString(LiczbaRekordowKoszyk));

        }

        // Ustawienie kontrolki DELETE
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)  
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int wybranyWiersz = ListaDanCopy.SelectedIndex;   
            if (wybranyWiersz != -1)
            {
                daniaListCopied.RemoveAt(wybranyWiersz);
            }
            
        }

    }
     

     
    }


