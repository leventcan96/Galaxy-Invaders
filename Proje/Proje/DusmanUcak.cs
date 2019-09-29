using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Proje
{
    class DusmanUcak
    {
        Random rnd = new Random();

        private int x;
        private int y;
        public int X
        {
            get
            {
              
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        Image resim;
        public DusmanUcak()
        {
            x = rnd.Next(0,1250);
            resim = Image.FromFile("DusmanUcak.png");//dusman ucak resminin dosyadan alınması
        }
        public void ciz(Graphics g)//kordinatları ve boyutları belirleyip resmi çizen fonksiyon
        {
            
             g.DrawImage(resim,X,Y, 100, 100);
        }
        
    }
}
