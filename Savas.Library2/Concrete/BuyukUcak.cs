using Savas.Library.Abstract;
using Savas.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    class BuyukUcak : Ucak
    {
        private static readonly Random Random = new Random();
        public BuyukUcak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Puan = 15;
            Can = 3;
            HareketMesafesi = (int)(Height * 0.07) + Random.Next(-2,2);
        }

        public async override void UcagiPatlat()
        {
            var eskiHareketMesafesi = HareketMesafesi;
            HareketMesafesi = (int)(HareketMesafesi * 0.3);
            Image = ResimYukleyici.GorselGetir($@"patlamisBuyukUcak.png");
            await Task.Delay(400);
            Image = ResimYukleyici.GorselGetir($@"BuyukUcak.png");
            HareketMesafesi = eskiHareketMesafesi;
        }
    }
}
