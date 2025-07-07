using System;
using Savas.Library.Interface;
using Savas.Library.Enum;
using System.Windows.Forms;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.Versioning;
using System.Resources;
using Savas.Library2.Concrete;
using Savas.Library.Abstract;


namespace Savas.Library.Concrete
{
   

    public class Oyun : IOyun
    {


        #region Alanlar
        private const int DEFATESGECİKMESİ = 550;
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _yavasHareketTimer = new Timer { Interval = 150 };
        private readonly Timer _HizliHareketTimer = new Timer { Interval = 60 };
        private readonly Timer _KucukUcakOlusturmaTimer = new Timer { Interval = 2000 };
        private readonly Timer _BuyukUcakOlusturmaTimer = new Timer { Interval = 15000 };
        private readonly Timer _YildizOlusturmaTimer = new Timer { Interval = 26693 };


        private TimeSpan _gecenSure;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private bool atesEdiliyor = false;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();
        private Yildiz _yildiz;
        private int _puan;
        private bool yeniCarpisildi;


        #endregion

        #region olaylar
        public event EventHandler GecenSureDegisti;
        public event EventHandler PuanDegisti;
        public event EventHandler OyunBitti;
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

        public int Puan 
        {  
            get => _puan; 
            private set 
            {
                if (Puan < 0) return; 
                _puan = value;
                if(Puan < 0) _puan = 0;

                PuanDegisti?.Invoke(this, EventArgs.Empty);
            }
        }


        #endregion

        #region Methodlar

        public Oyun(Panel savasAlaniPanel)
        {
            _savasAlaniPanel = savasAlaniPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _yavasHareketTimer.Tick += YavasHareketTimer_Tick;
            _HizliHareketTimer.Tick += HizliHareket_Tick;
            _KucukUcakOlusturmaTimer.Tick += KucukUcakOlusturma_Tick;
            _YildizOlusturmaTimer.Tick += YildizOlusturma_Tick;
            _BuyukUcakOlusturmaTimer.Tick += BuyukUcakOlusturma_Tick;
            PuanDegisti += PuanDegitiginde;

            Puan = 0;
        }

        private void PuanDegitiginde(object? sender, EventArgs e)
        {
            if (Puan == 60) _BuyukUcakOlusturmaTimer.Start();
        }

        private void BuyukUcakOlusturma_Tick(object? sender, EventArgs e)
        {
            BuyukUcakOlustur();
        }

        private void YildizOlusturma_Tick(object? sender, EventArgs e)
        {
            YildizOlustur();
        }

        

        private void KucukUcakOlusturma_Tick(object? sender, EventArgs e)
        {
            KucukUcakOlustur();
        }

        private void HizliHareket_Tick(object? sender, EventArgs e)
        {
            if (_ucaksavar.yakalandiMi(_yildiz)) { YildizEfekti(); YildiziSil(); }
            if (_ucaksavar.CarptiMi(_ucaklar) is not null) UcaksavarUcaklaCarpisti();

            MermilerinResimleriniDegistir();
            MermileriHareketEttir();
            YildizlariHareketEttir();
        }

        private async void UcaksavarUcaklaCarpisti()
        {
            if (yeniCarpisildi == true) return;
            yeniCarpisildi = true;
            _ucaksavar.UcakSavarCarpti(); 
            UcagiSil(_ucaksavar.CarptiMi(_ucaklar));
            Puan -= 5;
            await Task.Delay(400);
            yeniCarpisildi = false;
           
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

                ucak.VurulmaSayisi++;
                _mermiler.Remove(vuranMermi);
                _savasAlaniPanel.Controls.Remove(vuranMermi);

                if (ucak.VurulmaSayisi < ucak.Can) continue;

                Puan += ucak.Puan;
                UcagiSil(ucak);
                
              
               
            
            }
        }

        private async void UcagiSil(Ucak ucak)
        {
            ucak.UcagiPatlat();
            await Task.Delay(400);
            _ucaklar.Remove(ucak);
            _savasAlaniPanel.Controls.Remove(ucak);
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
            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center, _ucaksavar.Top);
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
            GecenSure = TimeSpan.Zero;
            AtesGecikmesi = DEFATESGECİKMESİ;
            Puan = 0;
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            OyunBitti?.Invoke(this, EventArgs.Empty);
            ZamanliyicilariDurdur();
           
        }

        

        public void ZamanliyicilariBaslat()
        {
            _KucukUcakOlusturmaTimer.Start();
            _gecenSureTimer.Start();
            _yavasHareketTimer.Start();
            _HizliHareketTimer.Start();
            _YildizOlusturmaTimer.Start();
        }

       

        public void ZamanliyicilariDurdur()
        {
            _KucukUcakOlusturmaTimer.Stop();
            _gecenSureTimer.Stop();
            _yavasHareketTimer.Stop();
            _HizliHareketTimer.Stop();
            _YildizOlusturmaTimer.Stop();
            _BuyukUcakOlusturmaTimer.Stop();
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
                YildiziSil();
            }
        }

        private void YildiziSil()
        {
            _savasAlaniPanel.Controls.Remove(_yildiz);
            _yildiz = null;
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


            _ucaksavar = new Ucaksavar(_savasAlaniPanel.Width, _savasAlaniPanel.Size);

            _savasAlaniPanel.Controls.Add(_ucaksavar);
        }

        private void KucukUcakOlustur()
        {
            var ucak = new KucukUcak(_savasAlaniPanel.Size);
            _ucaklar.Add(ucak);
            _savasAlaniPanel.Controls.Add(ucak);
        }
        private void BuyukUcakOlustur()
        {
            var ucak = new BuyukUcak(_savasAlaniPanel.Size);
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
