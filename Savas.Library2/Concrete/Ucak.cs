using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library2.Concrete;

internal class Ucak : Cisim
{

    private static readonly Random Random = new Random();
    public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
    {
        
        Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
    }
}
