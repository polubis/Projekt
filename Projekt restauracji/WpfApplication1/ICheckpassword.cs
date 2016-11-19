using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    interface ICheckpassword
    {
        bool SprawdzamLogowanie(string login, string haslo);
    }
}
