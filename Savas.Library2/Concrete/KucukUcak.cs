using Savas.Library.Abstract;
using Savas.Library.Helpers;


namespace Savas.Library.Concrete
{
    class KucukUcak : Ucak
    {

        private static readonly Random Random = new Random();
        public KucukUcak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Puan = 5;
            can = 1;
            HareketMesafesi = (int)(Height * 0.12) + Random.Next(7);

        }

        public override void Patlat()
        {
            HareketMesafesi = (int)(Height * 0.10);
            Image = ResimYukleyici.GorselGetir($@"patlamisKucukUcak.png");
        }
    }
}
