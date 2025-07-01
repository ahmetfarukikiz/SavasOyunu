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
        private bool yeniBasildi = false;
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private Ucaksavar _ucaksavar;
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
       
        public Oyun(Panel ucaksavarPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        public void AtesEt()
        {
            throw new NotImplementedException();
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            _gecenSureTimer.Start();

            UcaksavarOlustur();


        }

        private void UcaksavarOlustur()
        {


            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);

            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

        private void Bitir()            
        {
            if (!DevamEdiyorMu) return;
      
            DevamEdiyorMu = false;
            _gecenSureTimer.Stop();
        }

        public async void UcaksavariHareketEttir(Yon yon)
        {
            if (yeniBasildi == true || !DevamEdiyorMu) return;

            _ucaksavar.HareketEttir(yon);

            yeniBasildi = true;
            await Task.Delay(45);
            yeniBasildi = false;
        }

        #endregion
    }
}
