using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class Mermi
    {
        DostUcak dd = new DostUcak();
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
        public Mermi()
        {
            
            resim = Image.FromFile("Bullet.png");//mermi resminin dosyadan alınması
        }
        public void ciz(Graphics g)//kordinatları ve boyutları belirleyip resmi çizen fonksiyon
        {
            
             g.DrawImage(resim,X,Y, 100, 100);
        }
        
    
    }
}
