using Savas.Library.Helpers;
using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Abstract
{
    internal abstract class Mermi : Cisim
    {

        private static readonly string[] mermiResimleri = { "Mermi1", "Mermi2", "Mermi3" };
        private int mermiResmiIndexi = 0;

        public Mermi(Size hareketAlaniBoyutlari, int namluOrtasiX, int namluOrtasiY) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namluOrtasiX, namluOrtasiY);
        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX, int namluOrtasiY)
        {
            Bottom = namluOrtasiY;
            Center = namluOrtasiX;
            HareketMesafesi = (int)(Height * 1.5);
        }

        public void AnimasyonluResimAyarla()
        {
            Image = ResimYukleyici.GorselGetir($@"{mermiResimleri[mermiResmiIndexi]}.png");
            if (mermiResmiIndexi < 2) mermiResmiIndexi++;
            if (mermiResmiIndexi == 2) mermiResmiIndexi = 0;
        }
    }
}
