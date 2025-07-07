using Savas.Library2.Abstract;
using Savas.Library2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Savas.Library.Helpers;

namespace Savas.Library.Abstract;

internal abstract class Ucak : Cisim
{

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VurulmaSayisi;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Can { get; protected set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Puan { get; protected set; }

    private static readonly Random Random = new Random();
    public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
    {
        VurulmaSayisi = 0;
        Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);

    }

    public virtual void UcagiPatlat()
    {
        HareketMesafesi = (int)(Height * 0.10);
        Image = ResimYukleyici.GorselGetir($@"patlamisUcak.png");
    }

    public Mermi? VurulduMu(List<Mermi> mermiler)
    {
        foreach(var mermi in mermiler)
        {
            var vurulduMu = (mermi.Left > Left && mermi.Left < Right || mermi.Right < Right && mermi.Right > Left)
            &&
            (mermi.Bottom < Bottom && mermi.Bottom > Top || mermi.Top > Top && mermi.Top < Bottom);
            if (vurulduMu) return mermi;
        }
       
        return null;
    }
}
