using Savas.Library.Enum;

namespace Savas.Library.Interface
{
    internal interface IOyun
    {

        event EventHandler GecenSureDegisti;
        event EventHandler PuanDegisti;
        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
        void Baslat();
        Task UcaksavariAtesEttir();
        void UcaksavariHareketEttir(Yon yon);


    }
}
