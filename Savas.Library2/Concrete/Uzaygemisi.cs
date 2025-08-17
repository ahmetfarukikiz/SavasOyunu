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
        private Size _hareketAlaniBoyutlari;
        public Uzaygemisi(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Top = 10;
            Puan = 30;
            can = 10;
            YatayHareketMesafesi = 13;
            _hareketAlaniBoyutlari = hareketAlaniBoyutlari;
            HareketMesafesi = 5;
        }

        public async override Task Patlat()
        {
            var eskiHareketMesafesi = HareketMesafesi;
            HareketMesafesi = (int)(HareketMesafesi * 0.3);
            Image = ResimYukleyici.GorselGetir($@"patlamisUzaygemisi.png");
            await Task.Delay(400);
            Image = ResimYukleyici.GorselGetir($@"Uzaygemisi.png");
            HareketMesafesi = eskiHareketMesafesi;
        }


        public DusmanMermi AtesEt()
        {
            var mermi = new DusmanMermi(_hareketAlaniBoyutlari, Center, Middle);
            return mermi;
        }
    }
}
