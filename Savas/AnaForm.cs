using Savas.Library.Concrete;
using Savas.Library.Enum;

namespace Savas
{
    public partial class AnaForm : Form
    {
        private Oyun _oyun;
        public AnaForm()
        {
            InitializeComponent();

            _oyun = new Oyun(ucaksavarPanel, savasAlaniPanel);

            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_oyun.DevamEdiyorMu && e.KeyCode != Keys.Enter) return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                case Keys.Right:
                    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.UcaksavariHareketEttir(Yon.Sola);
                    break;
                case Keys.D:
                    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    break;
                case Keys.A:
                    _oyun.UcaksavariHareketEttir(Yon.Sola);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
            }
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e) //önce nesnenin adý sonra eventin adý
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");
        }
    }
}
