using Savas.Library2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library2.Concrete
{
    class Yildiz : Cisim
    {

        private static readonly Random Random = new Random();
        public Yildiz(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
            HareketMesafesi = (int)(Height * 0.15);
        }
    }
}
