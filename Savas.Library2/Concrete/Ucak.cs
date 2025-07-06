using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library2.Concrete;

internal class Ucak : Cisim
{

    private static readonly Random Random = new Random();
    public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
    {
        
        Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
        HareketMesafesi = (int)(Height * 0.15) + Random.Next(10);
    }

    public void UcagiPatlat()
    {
        HareketMesafesi = (int)(Height * 0.10);
        Image = Image.FromFile($"images\\patlamisUcak.png");
    }

    public Mermi? VurulduMu(List<Mermi> mermiler)
    {
        foreach(var mermi in mermiler)
        {
            var vurulduMu = ((mermi.Left > Left && mermi.Left < Right) || (mermi.Right < Right && mermi.Right > Left))
            &&
            ((mermi.Bottom < Bottom && mermi.Bottom > Top) || (mermi.Top > Top && mermi.Top < Bottom));
            if (vurulduMu) return mermi;
        }
       
        return null;
    }
}
