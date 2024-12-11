using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp3
{
    
    public static class HareketliNesneler
    {
        private static int haritaBoyutu; 

        public static void SetHaritaBoyutu(int boyut)
        {
            haritaBoyutu = boyut; 
        }

        private static Point RastgeleKonumArı(Random random, Panel panel, Size pictureBoxSize)
        {
            int kareBoyutu = 20;
            int x = random.Next(0, panel.Width - kareBoyutu);
            int y = random.Next(0, panel.Height - kareBoyutu);
            return new Point(x, y);
        }

        private static Point RastgeleKonumKus(Random random, Panel panel, Size pictureBoxSize)
        {
            int kareBoyutu = 20;
            int x = random.Next(0, panel.Width - kareBoyutu);
            int y = random.Next(0, panel.Height - kareBoyutu);
            return new Point(x, y);
        }



        private static void ArıHareketEttir(PictureBox pictureBox, ref bool sağaMi)
        {
            
            Point mevcutKonum = pictureBox.Location;

           
            if (sağaMi)
            {
                
                if (mevcutKonum.X < pictureBox.Parent.Width - pictureBox.Width)
                {
                    
                    mevcutKonum.X += 20;
                }
                else 
                {
                    
                    sağaMi = false;
                }
            }
            else 
            {
                
                if (mevcutKonum.X > 0)
                {
                    
                    mevcutKonum.X -= 20;
                }
                else 
                {
                    
                    sağaMi = true;
                }
            }

            
            pictureBox.Location = mevcutKonum;
        }

        private static void KusHareketEttir(PictureBox pictureBox, ref bool yukariMi)
        {
            
            Point mevcutKonum = pictureBox.Location;

            
            if (yukariMi)
            {
                
                if (mevcutKonum.Y > 0)
                {
                   
                    mevcutKonum.Y -= 20;
                }
                else 
                {
                    
                    yukariMi = false;
                }
            }
            else 
            {
               
                if (mevcutKonum.Y < pictureBox.Parent.Height - pictureBox.Height)
                {
                    
                    mevcutKonum.Y += 20;
                }
                else 
                {
                    
                    yukariMi = true;
                }
            }

           
            pictureBox.Location = mevcutKonum;
        }

        public static void EkranaAriEkle(Panel haritaPanel, List<NesneBilgisi> nesneBilgileri, Random random)
        {
            
            string ariResimURL = "https://e7.pngegg.com/pngimages/961/579/png-clipart-bee-cuteness-heart-bee-s-cartoon-honey-bee-food.png";

            
            PictureBox arıPictureBox = new PictureBox();
            arıPictureBox.ImageLocation = ariResimURL;
            arıPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            
            int kareBoyutu = 20;
            int ariBoyutu = kareBoyutu * 2;

            arıPictureBox.Size = new Size(ariBoyutu, ariBoyutu);

           
            Point arıKonum = RastgeleKonumArı(random, haritaPanel, arıPictureBox.Size);
            arıPictureBox.Location = arıKonum;

           
            nesneBilgileri.Add(new NesneBilgisi(arıKonum, arıPictureBox.Size));

            
            haritaPanel.Controls.Add(arıPictureBox);

           
            bool sağaMi = true;

            
            System.Windows.Forms.Timer arıMovementTimer = new System.Windows.Forms.Timer();
            arıMovementTimer.Interval = 1; 
            arıMovementTimer.Enabled = true; 
            arıMovementTimer.Tick += (sender, e) =>
            {
                
                ArıHareketEttir(arıPictureBox, ref sağaMi);
            };
        }

        public static void EkranaKusEkle(Panel haritaPanel, List<NesneBilgisi> nesneBilgileri, Random random)
        {
            
            string kusResimURL = "https://w7.pngwing.com/pngs/377/962/png-transparent-bird-cartoon-bird-marine-mammal-animals-vertebrate.png";

            
            PictureBox kusPictureBox = new PictureBox();
            kusPictureBox.ImageLocation = kusResimURL;
            kusPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            
            int kareBoyutu = 20;
            int kusBoyutu = kareBoyutu * 2;

            
            kusPictureBox.Size = new Size(kusBoyutu, kusBoyutu);

            
            Point kusKonum = RastgeleKonumKus(random, haritaPanel, kusPictureBox.Size);
            kusPictureBox.Location = kusKonum;

            
            nesneBilgileri.Add(new NesneBilgisi(kusKonum, kusPictureBox.Size));

            
            haritaPanel.Controls.Add(kusPictureBox);

            bool yukariMi = true;

            
            Timer movementTimer = new Timer();
            movementTimer.Interval = 100; 
            movementTimer.Tick += (sender, e) =>
            {
                
                KusHareketEttir(kusPictureBox, ref yukariMi);
            };
            movementTimer.Start();
        }
    }
}