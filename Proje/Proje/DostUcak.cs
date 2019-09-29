using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class DostUcak
    {
        private int x;
        private int y=750;
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
        public DostUcak()
        {
            resim = Image.FromFile("DostUcak2.png");//dost ucak resminin dosyadan alınması
        }
        public void SolaGit()
        {
            if (x==0)
            {
                
            }
            else
            X-=10;
        }
        public void SagaGit()
        {
            if (X==1280)
            {
                
            }
            else
            X += 10;
        }
        public void ciz(Graphics g) //kordinatları ve boyutları belirleyip resmi çizen fonksiyon
        {
             g.DrawImage(resim,X, Y, 100, 100);
        }
        
    
    }
}
