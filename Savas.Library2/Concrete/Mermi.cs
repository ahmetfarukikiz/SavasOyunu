using Savas.Library2.Abstract;
using Timer = System.Windows.Forms.Timer;

namespace Savas.Library2.Concrete
{
    class Mermi : Cisim
    {
        private static readonly string[] mermiResimleri = { "mermi1", "mermi2", "mermi3" };
        private int mermiResmiIndexi = 0;
        private readonly Timer _mermiResimTimer = new Timer { Interval = 50 };

        public Mermi(Size hareketAlaniBoyutlari, int namluOrtasiX) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namluOrtasiX);

            _mermiResimTimer.Tick += MermiResimTimer_Tick;
            _mermiResimTimer.Start();

        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX)
        {
            Bottom = HareketAlaniBoyutlari.Height;
            Center = namluOrtasiX;
            HareketMesafesi = (int)(Height * 1.5); 
        }

        private void MermiResimTimer_Tick(object sender, EventArgs e)
        {
         
            Image = Image.FromFile($@"images\{mermiResimleri[mermiResmiIndexi]}.png");
            if(mermiResmiIndexi < 2) mermiResmiIndexi++;
            if (mermiResmiIndexi == 2) mermiResmiIndexi = 0;


        }
    }
}
