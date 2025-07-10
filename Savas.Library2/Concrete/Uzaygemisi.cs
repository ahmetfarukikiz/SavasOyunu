using Savas.Library.Abstract;
using Savas.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    class Uzaygemisi : Ucak
    {
        public Uzaygemisi(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Top = 10;
            Puan = 30;
            can = 10;
            YatayHareketMesafesi = 13;

            HareketMesafesi = 5;
        }

        public override void Patlat()
        {
            HareketMesafesi = (int)(Height * 0.10);
            Image = ResimYukleyici.GorselGetir($@"patlamisUzaygemisi.png");
        }
    }
}
