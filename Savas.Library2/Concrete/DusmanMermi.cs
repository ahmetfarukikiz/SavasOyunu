using Savas.Library.Abstract;
using Savas.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    internal class DusmanMermi : Mermi
    {
        public DusmanMermi(Size hareketAlaniBoyutlari, int namluOrtasiX, int namluOrtasiY) : base(hareketAlaniBoyutlari, namluOrtasiX, namluOrtasiY)
        {
        }

        public override void AnimasyonluResimAyarla()
        {
        }
    }
}
