using System;
using Savas.Library.Interface;
using Savas.Library.Enum;
using System.Windows.Forms;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.Versioning;
using System.Resources;
using Savas.Library2.Concrete;


namespace Savas.Library.Concrete
{
   

    public class Oyun : IOyun
    {


        #region Alanlar
        private const int DEFATESGECİKMESİ = 400;
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 130 };
        private readonly Timer _AnimasyonluResimTimer = new Timer { Interval = 60 };
        private readonly Timer _UcakOlusturmaTimer = new Timer { Interval = 1600 };
        private readonly Timer _YildizOlusturmaTimer = new Timer { Interval = 30000 };


        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private bool atesEdiliyor = false;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();
        private Yildiz _yildiz;


        #endregion

        #region olaylar
        public event EventHandler GecenSureDegisti;
        #endregion

        #region Özellikler
        public bool DevamEdiyorMu { get; private set; } = false; //private set bu sınıftan atayaabiliriz değer
        public int AtesGecikmesi { get; private set; } = DEFATESGECİKMESİ;

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Methodlar
       
        public Oyun(Panel ucaksavarPanel, Panel savasAlaniPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _savasAlaniPanel = savasAlaniPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += YavasHareketTimer_Tick;
            _AnimasyonluResimTimer.Tick += HizliHareket_Tick;
            _UcakOlusturmaTimer.Tick += UcakOlusturma_Tick;
            _YildizOlusturmaTimer.Tick += YildizOlusturma_Tick;


        }

        private void YildizOlusturma_Tick(object? sender, EventArgs e)
        {
            YildizOlustur();
        }

        

        private void UcakOlusturma_Tick(object? sender, EventArgs e)
        {
            UcakOlustur();
        }

        private void HizliHareket_Tick(object? sender, EventArgs e)
        {
            MermilerinResimleriniDegistir();
            MermileriHareketEttir();
            YildizlariHareketEttir();
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void YavasHareketTimer_Tick(object sender, EventArgs e)
        {
            UcaklarihareketEttir();
            VurulanUcaklariCikar();
        }

        private void VurulanUcaklariCikar()
        {
            for (var i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];

                var vuranMermi = ucak.VurulduMu(_mermiler);
                if (vuranMermi is null) continue;

                _ucaklar.Remove(ucak);
                _mermiler.Remove(vuranMermi);
                _savasAlaniPanel.Controls.Remove(ucak);
                _savasAlaniPanel.Controls.Remove(vuranMermi);
            }
        }

        private void UcaklarihareketEttir()
        {
            foreach(var ucak in _ucaklar)
            {
               var carptiMi = ucak.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                Bitir();
                break;
            }
        }

        private void MermileriHareketEttir()
        {
            //döngüyü tersten yazdık kaymasın diye
            for (int i = _mermiler.Count-1; i >= 0; i--) 
            {
                var mermi = _mermiler[i];
                var carptiMi = mermi.HareketEttir(Yon.Yukari);
                if (carptiMi)
                {
                    _mermiler.Remove(mermi);
                    _savasAlaniPanel.Controls.Remove(mermi);
                }
            }
        }

        private void MermilerinResimleriniDegistir()
        {
            foreach(var mermi in _mermiler)
            {
                mermi.AnimasyonluResimAyarla();
            }
        }
            
        public async void AtesEt()
        {
            if (!DevamEdiyorMu || atesEdiliyor) return;

            atesEdiliyor = true;
            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlaniPanel.Controls.Add(mermi);
            await Task.Delay(AtesGecikmesi);
            atesEdiliyor = false;
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            Sifirla();

            DevamEdiyorMu = true;

            ZamanliyicilariBaslat();

            UcaksavarOlustur();

         



        }

        private void Sifirla()
        {
            _ucaklar.Clear();
            _mermiler.Clear();
            _savasAlaniPanel.Controls.Clear();
            _ucaksavarPanel.Controls.Clear();
            GecenSure = TimeSpan.Zero;
            AtesGecikmesi = DEFATESGECİKMESİ;
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanliyicilariDurdur();

        }

        

        public void ZamanliyicilariBaslat()
        {
            _UcakOlusturmaTimer.Start();
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _AnimasyonluResimTimer.Start();
            _YildizOlusturmaTimer.Start();
        }

       

        public void ZamanliyicilariDurdur()
        {
            _UcakOlusturmaTimer.Stop();
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _AnimasyonluResimTimer.Stop();
            _YildizOlusturmaTimer.Stop();
        }

        private void YildizOlustur()
        {

            _yildiz = new Yildiz(_savasAlaniPanel.Size);
            _savasAlaniPanel.Controls.Add(_yildiz);
        }

        private void YildizlariHareketEttir()
        {
            if (_yildiz is null) return;
             var carptiMi = _yildiz.HareketEttir(Yon.Asagi);

            if(carptiMi)
            {
                if (_ucaksavar.yakalandiMi(_yildiz)) YildizEfekti();
                _savasAlaniPanel.Controls.Remove(_yildiz);
                _yildiz = null;
            }
        }

        private async void YildizEfekti()
        {
            AtesGecikmesi = 70;
            await Task.Delay(7000); //7 sn sürecek
            AtesGecikmesi = DEFATESGECİKMESİ;
        }

        private void UcaksavarOlustur()
        {
            if (!DevamEdiyorMu) return;


            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);

            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

        private void UcakOlustur()
        {
            var ucak = new Ucak(_savasAlaniPanel.Size);
            _ucaklar.Add(ucak);
            _savasAlaniPanel.Controls.Add(ucak);
        }


        public void UcaksavariHareketEttir(Yon yon)
        {

            if (!DevamEdiyorMu) return;

            _ucaksavar.HareketEttir(yon);

        }

        #endregion
    }
}
