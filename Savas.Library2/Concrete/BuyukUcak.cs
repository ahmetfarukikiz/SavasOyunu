using Savas.Library.Abstract;
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
            HareketMesafesi = (int)(Height * 0.03) + Random.Next(-2,2);
        }

        public override void UcagiPatlat()
        {
            HareketMesafesi = (int)(Height * 0.10);
            Image = Image.FromFile($"images\\patlamisBuyukUcak.png");
        }
    }
}
