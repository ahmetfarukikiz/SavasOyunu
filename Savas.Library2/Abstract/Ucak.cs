using Savas.Library2.Abstract;
using Savas.Library2.Concrete;
using System.ComponentModel;
using Savas.Library.Helpers;
using Savas.Library.Concrete;

namespace Savas.Library.Abstract;

internal abstract class Ucak : Cisim
{


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int can;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Puan { get; protected set; }

    private static readonly Random Random = new Random();
    public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
    {
        Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);

    }

    public virtual void Patlat()
    {
        HareketMesafesi = (int)(Height * 0.10);
        Image = ResimYukleyici.GorselGetir($@"patlamisUcak.png");
    }

    public virtual Mermi? VurulduMu(List<Mermi> mermiler)
    {
        foreach(var mermi in mermiler)
        {
            if (mermi is DusmanMermi) continue;
            var vurulduMu = (mermi.Left > Left && mermi.Left < Right || mermi.Right < Right && mermi.Right > Left)
            &&
            (mermi.Bottom < Bottom && mermi.Bottom > Top || mermi.Top > Top && mermi.Top < Bottom);
            if (vurulduMu) return mermi;
        }
       
        return null;
    }
}
