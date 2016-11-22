using System;
using System.Collections.Generic;
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
    /// Interaction logic for Faktura.xaml
    /// </summary>
    public partial class Faktura : Window
    {
        public Faktura()
        {
            InitializeComponent();
            if(File.Exists("Faktura.txt"))
            {
                StreamReader Odczyt = File.OpenText("Faktura.txt");
                string ZawartoscFaktury = Odczyt.ReadToEnd();
                WyswietlFakture.Text = ZawartoscFaktury;
            }

        }
    }
}
