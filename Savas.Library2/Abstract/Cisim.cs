using Savas.Library.Enum;
using Savas.Library2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Savas.Library2.Abstract
{
    internal abstract class Cisim : PictureBox, IHareketEden
    {
        public Size HareketAlaniBoyutlari { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HareketMesafesi { get; protected set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int YatayHareketMesafesi { get; protected set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Right { 
            get => base.Right;
            protected set => Left = value - Width; 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Bottom { 
            get => base.Bottom; 
            protected set => Top = value - Height; 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Center { 
            get => Left + Width / 2; 
            set => Left = value - Width / 2; 
        }
         
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Middle
        {
            get => Top + Height / 2; 
            set => Top = value - Height / 2;
        }

        protected Cisim(Size hareketAlaniBoyutlari)
        {
            Image = Image.FromFile($@"images\{GetType().Name}.png");

            SizeMode = PictureBoxSizeMode.AutoSize;
            HareketAlaniBoyutlari = hareketAlaniBoyutlari;
        }



        public bool HareketEttir(Yon yon)
        {
            switch (yon)
            {
                case Yon.Yukari:
                    return YukariHareketEttir();
                case Yon.Saga:
                    return SagaHareketEttir();
                case Yon.Sola:
                    return SolaHareketEttir();
                case Yon.Asagi:
                    return AsagiHareketEttir(); ;
                default:
                    return true;
            }
        }

       

        private bool SolaHareketEttir()
        {
            if (Left == 0) return true;

            var yeniLeft = Left - YatayHareketMesafesi;
            var tasacakMi = yeniLeft < 0;

            Left = tasacakMi ? 0 : yeniLeft; 

            return Left == 0; //çartıysa true
        }

        private bool YukariHareketEttir()
        {
            if (Top == 0) return true;

            var yeniTop = Top - HareketMesafesi;
            var tasacakMi = yeniTop < 0;

            Top = tasacakMi ? 0 : yeniTop;

            return Top == 0; //çartıysa true
        }

        private bool SagaHareketEttir()
        {
            if (Right == HareketAlaniBoyutlari.Width) return true;

            var yeniRight = YatayHareketMesafesi + Right;
            var tasacakMi = yeniRight > HareketAlaniBoyutlari.Width;
                
            Right = tasacakMi ? HareketAlaniBoyutlari.Width : yeniRight;
            

            return Left == HareketAlaniBoyutlari.Width; //çartıysa true
        }

        private bool AsagiHareketEttir()
        {
            if (Bottom == HareketAlaniBoyutlari.Height) return true;

            var yeniBottom = HareketMesafesi + Bottom;
            var tasacakMi = yeniBottom > HareketAlaniBoyutlari.Height;

            Bottom = tasacakMi ? HareketAlaniBoyutlari.Height : yeniBottom;


            return Bottom == HareketAlaniBoyutlari.Height; //çartıysa true
        }


    }
}
