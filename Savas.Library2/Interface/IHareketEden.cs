using Savas.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library2.Interface
{
    interface IHareketEden
    {
        //sadece public olanlar yazılır private set benzeri şeyler implement eden sınıfa yazılabilir


        //nereye kadar hareket edebileceği
        Size HareketAlaniBoyutlari { get; } 

        //tek seferde ne kadar hareket edeceği
        int HareketMesafesi { get; }

        /// <summary>
        /// Cismi istenilen yönde hareket ettirir
        /// </summary>
        /// <param name="yon">Hangi yöne hareket edileceği</param>
        /// <returns>Cisim bir yere çarparsa true döndürür</returns>   
        bool HareketEttir(Yon yon); 

    }
}
