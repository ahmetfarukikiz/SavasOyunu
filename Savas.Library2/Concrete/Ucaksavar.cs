using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library2.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {   
            Size = new Size(80, 80);
            Center = panelGenisligi / 2;
            HareketMesafesi = Width-40;
        }
    }
}
