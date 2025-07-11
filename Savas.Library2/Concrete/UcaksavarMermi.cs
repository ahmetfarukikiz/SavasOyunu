using Savas.Library.Abstract;
using Savas.Library.Helpers;
using Savas.Library2.Abstract;

namespace Savas.Library2.Concrete
{
    class UcakSavarMermi : Mermi
    {
        private static readonly string[] mermiResimleri = { "Mermi1", "Mermi2", "Mermi3" };
        private int mermiResmiIndexi = 0;

        public UcakSavarMermi(Size hareketAlaniBoyutlari, int namluOrtasiX, int namluOrtasiY) : base(hareketAlaniBoyutlari, namluOrtasiX,namluOrtasiY)
        { 
        }

        public void AnimasyonluResimAyarla()
        {
            Image = ResimYukleyici.GorselGetir($@"{mermiResimleri[mermiResmiIndexi]}.png");
            if (mermiResmiIndexi < 2) mermiResmiIndexi++;
            if (mermiResmiIndexi == 2) mermiResmiIndexi = 0;
        }


    }
}
