using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    class KucukUcak : Ucak
    {

        private static readonly Random Random = new Random();
        public KucukUcak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Puan = 5;
            Can = 1;
            HareketMesafesi = (int)(Height * 0.15) + Random.Next(10);

        }

        public override void UcagiPatlat()
        {
            HareketMesafesi = (int)(Height * 0.10);
            Image = Image.FromFile($"images\\patlamisKucukUcak.png");
        }
    }
}
