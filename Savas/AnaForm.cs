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

            _oyun = new Oyun(ucaksavarPanel);

            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
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
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
            }
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e) //�nce nesnenin ad� sonra eventin ad�
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");
        }
    }
}
