﻿using Savas.Library.Abstract;
using Savas.Library2.Abstract;
using Savas.Library2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Savas.Library.myEventArgs;
using System.Diagnostics;

namespace Savas.Library2.Concrete
{
    internal class Ucaksavar : Cisim
    {

        public delegate void CanEventHandler(object sender, CanEventArgs e);

        public event CanEventHandler CanDegisti;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MermiHasari { get; private set; }
       

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Can 
        { 
            get => field;
            set
            {

                if (Can < 0) field = 0;
             
                field = value;
                if (Can < 0) field = 0;

                var e = new CanEventArgs();
                e.Can = Can;
                CanDegisti?.Invoke(this, e);
            }
        }
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            MermiHasari = 1;
       
            Size = new Size(80, 80);
            Center = panelGenisligi / 2;
            Bottom = hareketAlaniBoyutlari.Height;
            HareketMesafesi = 12;
            YatayHareketMesafesi = 14;
            BackColor = Color.Transparent;
      
        }

        internal bool yakalandiMi(Cisim cisim)
        {
            if (cisim is null) return false;

            var yakalandiMi = 
               ((cisim.Left > Left && cisim.Left < Right) || (cisim.Right < Right && cisim.Right > Left))
                &&
                ((cisim.Bottom < Bottom && cisim.Bottom > Top) || (cisim.Top > Top && cisim.Top < Bottom));
            return yakalandiMi;
        }

        internal Ucak CarptiMi(List<Ucak> ucaklar)
        {
            bool yakalandiMi = false;

            if (ucaklar is null) return null;

            foreach (var ucak in ucaklar)
            {
                yakalandiMi =
                ((ucak.Left > Left && ucak.Left < Right) || (ucak.Right < Right && ucak.Right > Left))
                &&
                    ((ucak.Bottom < Bottom && ucak.Bottom > Top) || (ucak.Top > Top && ucak.Top < Bottom));

                if(yakalandiMi) return ucak;
            }

            return null;
        }

        internal async void UcakSavarCarpti()
        {
            var eskiHareketMesafesi = HareketMesafesi;
            var eskiYatayHareketMesafesi = YatayHareketMesafesi;

            HareketMesafesi = (int)(HareketMesafesi * 0.3);
            YatayHareketMesafesi = (int)(YatayHareketMesafesi * 0.3);
            await Task.Delay(300);
            HareketMesafesi = eskiHareketMesafesi;
            YatayHareketMesafesi = eskiYatayHareketMesafesi;
        }
    }
}
