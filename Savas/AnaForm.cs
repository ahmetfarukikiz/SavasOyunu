using Savas.Library.Concrete;
using Savas.Library.Enum;
using Timer = System.Windows.Forms.Timer;

namespace Savas
{
    public partial class AnaForm : Form
    {
        private readonly HashSet<Keys> _basiliTuslar = new();
        private readonly Timer _kontrolTimer = new();
        private Oyun _oyun;
        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(savasAlaniPanel);
            _oyun.PuanDegisti += Oyun_PuanDegisti;
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
            _oyun.OyunBitti += Oyun_OyunBitti;

            // Timer ayarý
            _kontrolTimer.Interval = 20; // 50 FPS gibi
            _kontrolTimer.Tick += KontrolTimer_Tick;
            _kontrolTimer.Start();

            // Formun klavye olaylarýný alabilmesi için:
            this.KeyPreview = true;
            this.KeyDown += AnaForm_KeyDown;
            this.KeyUp += AnaForm_KeyUp;
       
            
        }

        private void Oyun_OyunBitti(object sender, EventArgs e)
        {
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_oyun.DevamEdiyorMu && e.KeyCode != Keys.Enter) return;

            if (e.KeyCode == Keys.Enter)
            {
                _oyun.Baslat();
            }

            _basiliTuslar.Add(e.KeyCode);
        }

        private void KontrolTimer_Tick(object sender, EventArgs e)
        {
            if (!_oyun.DevamEdiyorMu) return;

            if (_basiliTuslar.Contains(Keys.Right) || _basiliTuslar.Contains(Keys.D))
            {
                _oyun.UcaksavariHareketEttir(Yon.Saga);
            }

            if (_basiliTuslar.Contains(Keys.Left) || _basiliTuslar.Contains(Keys.A))
            {
                _oyun.UcaksavariHareketEttir(Yon.Sola);
            }

            if (_basiliTuslar.Contains(Keys.Up) || _basiliTuslar.Contains(Keys.W))
            {
                _oyun.UcaksavariHareketEttir(Yon.Yukari);
            }

            if (_basiliTuslar.Contains(Keys.Down) || _basiliTuslar.Contains(Keys.S))
            {
                _oyun.UcaksavariHareketEttir(Yon.Asagi);
            }


            if (_basiliTuslar.Contains(Keys.Space) ||_basiliTuslar.Contains(Keys.L))
            {
                _oyun.AtesEt();
            }
        }

        private void AnaForm_KeyUp(object sender, KeyEventArgs e)
        {
            _basiliTuslar.Remove(e.KeyCode);
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e) //önce nesnenin adý sonra eventin adý
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");
        }

        private void Oyun_PuanDegisti(object sender, EventArgs e) //önce nesnenin adý sonra eventin adý
        {
            puanLabel.Text = $"Puan: {_oyun.Puan}";
        }


    }
}
