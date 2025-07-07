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
            Can = 1;
            HareketMesafesi = (int)(Height * 0.15) + Random.Next(10);

        }

        public override void UcagiPatlat()
        {
            HareketMesafesi = (int)(Height * 0.10);
            Image = ResimYukleyici.GorselGetir($@"patlamisKucukUcak.png");
        }
    }
}
