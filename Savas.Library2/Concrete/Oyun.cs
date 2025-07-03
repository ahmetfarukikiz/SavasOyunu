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
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _AnimasyonluResim = new Timer { Interval = 80 };

        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>(); 

        #endregion

        #region olaylar
        public event EventHandler GecenSureDegisti;
        #endregion

        #region Özellikler
        public bool DevamEdiyorMu { get; private set; } = false; //private set bu sınıftan atayaabiliriz değer
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
            _hareketTimer.Tick += HareketTimer_Tick;
            _AnimasyonluResim.Tick += AnimasyonluResim_Tick;

        }

        private void AnimasyonluResim_Tick(object? sender, EventArgs e)
        {
            MermilerinResimleriniDegistir();
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
      
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
            
        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlaniPanel.Controls.Add(mermi);
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;

            ZamanliyicilariBaslat();

            UcaksavarOlustur();


        }

        public void ZamanliyicilariBaslat()
        {
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _AnimasyonluResim.Start();
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanliyicilariDurdur();

        }

        public void ZamanliyicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _AnimasyonluResim.Stop();

        }

        private void UcaksavarOlustur()
        {
            if (!DevamEdiyorMu) return;


            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);

            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

       

        public void UcaksavariHareketEttir(Yon yon)
        {

            if (!DevamEdiyorMu) return;

            _ucaksavar.HareketEttir(yon);

        }

        #endregion
    }
}
