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
        public Menu()
        {
            InitializeComponent();
            // Spis dan w MENU
            #region
            daniaList.Add(new Dania(1, "CocaCola 330ml", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(2, "Sprite 330ml", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(3, "Fanta 330ml", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(4, "Pepsi 330ml", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(5, "Mirinda 330ml", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(6, "Woda gazowana 0.5l", 3, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(7, "Woda niegazowana 0.5l", 3, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(8, "Sok owocowy 0.5l", 4, Dania.rodzajDania.Napoj));
            daniaList.Add(new Dania(9, "Czarna", 5, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(10, "Espresso", 6, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(11, "Latte", 8, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(12, "Americana", 11, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(13, "Chaina", 15, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(14, "Kawa biała", 7, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(15, "Kawa zimna", 10, Dania.rodzajDania.Kawa));
            daniaList.Add(new Dania(16, "Herbata owocowa", 7, Dania.rodzajDania.Herbata));
            daniaList.Add(new Dania(17, "Zwykła", 5, Dania.rodzajDania.Herbata));
            daniaList.Add(new Dania(18, "Elgrey", 9, Dania.rodzajDania.Herbata));
            daniaList.Add(new Dania(19, "Yerbamate", 11, Dania.rodzajDania.Herbata));
            daniaList.Add(new Dania(20, "Mix", 13, Dania.rodzajDania.Herbata));
            daniaList.Add(new Dania(21, "Zupa dnia", 5, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(22, "Rosół", 6, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(23, "Ogórkowa", 6, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(24, "Pomidorro", 6, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(25, "Krupnik", 6, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(26, "Zupa krem", 7, Dania.rodzajDania.Zupa));
            daniaList.Add(new Dania(27, "Bułeczki pizzowe", 5, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(28, "Pieczywko tostowe", 6, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(29, "Rollada", 8, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(30, "Podbrzuszek", 6, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(31, "Ciasteczka prawdy", 5, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(32, "HNZ", 10, Dania.rodzajDania.Przystawka));
            daniaList.Add(new Dania(33, "Skrzydełka", 15, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(34, "Pierś z kuraczaka", 14, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(35, "Sandacz w sosie szpinakowym", 17, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(36, "Sandacz w sosie koperkowym", 19, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(37, "Sandacz w sosie śmietanowym", 21, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(38, "Pstrąg z grilla", 17, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(39, "Łazanki", 17, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(40, "Frytki ze stynki", 11, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(41, "Kotlet schabowy", 15, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(42, "Owoce morza", 13, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(43, "Zapiekanka mazurska", 11, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(44, "Łosoś", 17, Dania.rodzajDania.DanieGłówne));
            daniaList.Add(new Dania(45, "Makrela w occie", 17.5, Dania.rodzajDania.DanieGłówne));
            listaDan.ItemsSource = daniaList;
            #endregion
            ApplicationCommands.Open.InputGestures.Add(new KeyGesture(Key.K, ModifierKeys.Control));  // uzbrojenie kontroli w skrot

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
                    || ((item as Dania).jakieDanie.ToString().IndexOf(txtIdNazwaFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            if (string.IsNullOrEmpty(Convert.ToString(pobierzID.Text)) || string.IsNullOrEmpty(pobierzDanie.Text) || string.IsNullOrEmpty(Convert.ToString(pobierzCene.Text))) 
            {
                MessageBox.Show("Nie dodałeś wartości do pól");
            }
            else
            {
                daniaList.Add(new Dania(Convert.ToInt32(pobierzID.Text), pobierzDanie.Text, double.Parse(pobierzCene.Text)));
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

       

       
        

    }
     

     
    }


