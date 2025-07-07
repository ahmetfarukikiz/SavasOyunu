using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    class Kalp : Cisim
    {
        private static readonly Random Random = new Random();
        public Kalp(Size hareketAlaniBoyutlari, int center, int middle) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(center, middle);
            HareketMesafesi = (int)(Height * 0.05);
        }

        private void BaslangicKonumunuAyarla(int center, int middle)
        {
            Center = center;
            Middle = middle;
        }
    }
}
