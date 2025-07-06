using Savas.Library2.Abstract;

namespace Savas.Library2.Concrete
{
    class Mermi : Cisim
    {
        private static readonly string[] mermiResimleri = { "mermi1", "mermi2", "mermi3" };
        private int mermiResmiIndexi = 0;

        public Mermi(Size hareketAlaniBoyutlari, int namluOrtasiX) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namluOrtasiX);
        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX)
        {
            Bottom = HareketAlaniBoyutlari.Height;
            Center = namluOrtasiX;
            HareketMesafesi = (int)(Height * 1.5); 
        }

        public void AnimasyonluResimAyarla()
        {
            Image = Image.FromFile($@"images\{mermiResimleri[mermiResmiIndexi]}.png");
            if (mermiResmiIndexi < 2) mermiResmiIndexi++;
            if (mermiResmiIndexi == 2) mermiResmiIndexi = 0;
        }

       
    }
}
