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
    interface ICheckpassword
    {
        bool Sprawdzam(string Login, string Haslo, StreamReader Odczyt, bool SprawdzamLogin, bool SprawdzamHalso);
    }
}
