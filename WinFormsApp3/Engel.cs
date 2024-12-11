using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public class Engel
    {
        public enum Engeltipi
        {
            Agac,
            Kaya,
            Duvar,
            Dag,
            Kus,
            Ari,
        }

        public Engeltipi Tip { get; set; }
        public Point Lokasyon { get; set; }
        public Size Boyut { get; set; }
        public int Hiz { get; set; } 

        public Panel HaritaPanel { get; set; }

        private System.Windows.Forms.Timer engelTimer;

        public Engel(Engeltipi tip, Point lokasyon, Size boyut, int hiz = 0)
        {
            Tip = tip;
            Lokasyon = lokasyon;
            Boyut = boyut;
            Hiz = hiz;
        }




        public bool OyuncuGecisEngeli()
        {
            
            if (Tip == Engeltipi.Agac || Tip == Engeltipi.Kaya || Tip == Engeltipi.Duvar || Tip == Engeltipi.Dag)
            {
                return true;
            }
            return false;
        }

        public bool HareketliEngel()
        {
            
            return Tip == Engeltipi.Kus || Tip == Engeltipi.Ari;
        }

        private Panel haritaPanel;
        private List<NesneBilgisi> nesneBilgileri;
        private Random random;
        private int haritaBoyutu;

        public void EngelEkle(Panel haritaPanelParam, List<NesneBilgisi> nesneBilgileriParam, Random randomParam, int haritaBoyutuParam)
        {
            haritaPanel = haritaPanelParam;
            nesneBilgileri = nesneBilgileriParam;
            random = randomParam;
            haritaBoyutu = haritaBoyutuParam;

        }

        private bool CakismaKontrolu(NesneBilgisi yeniNesne)
        {
            foreach (var nesne in nesneBilgileri)
            {
                if (nesne.Alan.IntersectsWith(yeniNesne.Alan))
                {
                    return true; 
                }
            }
            return false; 
        }
        public void EkranaKisAgaciEkle(Panel haritaPanel)
        {
            
            string kisAgaciResimURL = "https://img.pixers.pics/pho_wat(s3:700/FO/46/36/36/68/700_FO46363668_8291362166d95a8f59d4625f543caac8.jpg,700,700,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,650,jpg)/cikartmalar-kis-agac.jpg.jpg";

            for (int i = 0; i < 3; i++)
            {
               
                PictureBox kisAgaciPictureBox = new PictureBox();
                kisAgaciPictureBox.ImageLocation = kisAgaciResimURL;
                kisAgaciPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                int kareBoyutu = 20;
                int agacBoyutu = kareBoyutu * 3;

                
                kisAgaciPictureBox.Size = new Size(agacBoyutu, agacBoyutu);

                
                int x = random.Next(0, haritaPanel.Width / 2 - agacBoyutu);
                int y = random.Next(0, haritaPanel.Height - agacBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width - agacBoyutu);
                    y = random.Next(0, haritaPanel.Height - agacBoyutu);
                }

                
                kisAgaciPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(kisAgaciPictureBox);

                
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu)));
            }
        }
        public  void EkranaYazAgaciEkle()
        {
            
            string yazAgaciResimURL = "https://img.pixers.pics/pho_wat(s3:700/FO/27/88/61/50/700_FO27886150_be0011c74558f05b866408dc57ce1535.jpg,635,700,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,415,650,jpg)/duvar-resimleri-yaz-soyut-cicek-agac.jpg.jpg";

            for (int i = 0; i < 3; i++)
            {

               
                PictureBox yazAgaciPictureBox = new PictureBox();
                yazAgaciPictureBox.ImageLocation = yazAgaciResimURL;
                yazAgaciPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                int kareBoyutu = 20;
                int agacBoyutu = kareBoyutu * 3;

                
                yazAgaciPictureBox.Size = new Size(agacBoyutu, agacBoyutu);

                
                int x = random.Next(haritaPanel.Width / 2, haritaPanel.Width - agacBoyutu);
                int y = random.Next(0, haritaPanel.Height - agacBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - agacBoyutu);
                    y = random.Next(0, haritaPanel.Height - agacBoyutu);
                }


                
                yazAgaciPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(yazAgaciPictureBox);

                
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu)));

            }
        }


        public  void EkranaKisKayasiEkle()
        {
            
            string kisKayasiResimURL = "https://w7.pngwing.com/pngs/657/437/png-transparent-rock-dry-land-rock-dry-land-animation.png";

            for (int i = 0; i < 5; i++)
            {

                
                PictureBox kisKayasiPictureBox = new PictureBox();
                kisKayasiPictureBox.ImageLocation = kisKayasiResimURL;
                kisKayasiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                int kareBoyutu = 20;
                int kayaBoyutu = kareBoyutu * 2;

                
                kisKayasiPictureBox.Size = new Size(kayaBoyutu, kayaBoyutu);

                
                int x = random.Next(0, haritaPanel.Width / 2 - kayaBoyutu);
                int y = random.Next(0, haritaPanel.Height - kayaBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(kayaBoyutu, kayaBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - kayaBoyutu);
                    y = random.Next(0, haritaPanel.Height - kayaBoyutu);
                }


                
                kisKayasiPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(kisKayasiPictureBox);

                
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(kayaBoyutu, kayaBoyutu)));

            }
        }

        public  void EkranaYazKayasiEkle()
        {
            
            string yazKayasiResimURL = "https://w7.pngwing.com/pngs/746/66/png-transparent-cartoon-rock-illustration-cartoon-painted-mountain-rock-watercolor-painting-cartoon-character-purple.png";

            for (int i = 0; i < 5; i++)
            {

                
                PictureBox yazKayasiPictureBox = new PictureBox();
                yazKayasiPictureBox.ImageLocation = yazKayasiResimURL;
                yazKayasiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                int kareBoyutu = 20;
                int kayaBoyutu = kareBoyutu * 2;

               
                yazKayasiPictureBox.Size = new Size(kayaBoyutu, kayaBoyutu);

                
                int x = random.Next(haritaPanel.Width / 2, haritaPanel.Width - kayaBoyutu);
                int y = random.Next(0, haritaPanel.Height - kayaBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(kayaBoyutu, kayaBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - kayaBoyutu);
                    y = random.Next(0, haritaPanel.Height - kayaBoyutu);
                }


                
                yazKayasiPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(yazKayasiPictureBox);

                
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(kayaBoyutu, kayaBoyutu)));

            }
        }


        public  void EkranaKisDagiEkle()
        {
            
            string kisDagiResimURL = "https://png.pngtree.com/png-vector/20240216/ourlarge/pngtree-snow-mountain-3d-cartoon-graphic-png-image_11746296.png"; // Kış Dağı resmi URL'sini güncelleyin

            for (int i = 0; i < 2; i++)
            {

                
                PictureBox kisDagiPictureBox = new PictureBox();
                kisDagiPictureBox.ImageLocation = kisDagiResimURL;
                kisDagiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = 20;
                int dagBoyutu = kareBoyutu * 7;

                
                kisDagiPictureBox.Size = new Size(dagBoyutu, dagBoyutu);

                
                int x = random.Next(0, haritaPanel.Width / 2 - dagBoyutu);
                int y = random.Next(0, haritaPanel.Height - dagBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(dagBoyutu, dagBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - dagBoyutu);
                    y = random.Next(0, haritaPanel.Height - dagBoyutu);
                }


                
                kisDagiPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(kisDagiPictureBox);

                
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(dagBoyutu, dagBoyutu)));

            }
        }

        public  void EkranaYazDagiEkle()
        {
            
            string yazDagiResimURL = "https://e7.pngegg.com/pngimages/539/618/png-clipart-mountain-cartoon-snow-mountain-angle-triangle.png"; // Yaz Dağı resmi URL'sini güncelleyin

            for (int i = 0; i < 2; i++)
            {

                
                PictureBox yazDagiPictureBox = new PictureBox();
                yazDagiPictureBox.ImageLocation = yazDagiResimURL;
                yazDagiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = 20;
                int dagBoyutu = kareBoyutu * 7;

                
                yazDagiPictureBox.Size = new Size(dagBoyutu, dagBoyutu);

                
                int x = random.Next(haritaPanel.Width / 2, haritaPanel.Width - dagBoyutu);
                int y = random.Next(0, haritaPanel.Height - dagBoyutu);

                
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(dagBoyutu, dagBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - dagBoyutu);
                    y = random.Next(0, haritaPanel.Height - dagBoyutu);
                }


                
                yazDagiPictureBox.Location = new Point(x, y);

                
                haritaPanel.Controls.Add(yazDagiPictureBox);

               
                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(dagBoyutu, dagBoyutu)));

            }
        }


        public  void EkranaDuvarEngeliEkle()
        {
            
            string duvarEngeliResimURL = "https://media.istockphoto.com/id/940685622/tr/vekt%C3%B6r/%C3%A7izgi-film-el-bo%C4%9Fulmak-turuncu-ger%C3%A7ek%C3%A7i-sorunsuz-tu%C4%9Fla-duvar-doku.jpg?s=612x612&w=0&k=20&c=osFI0thpHQ1EaeGfFooO4qDB1JPqGWcESaeg6ZQJp9Y="; // Duvar Engeli resmi URL'sini güncelleyin

            
            int kareBoyutu = 20;
            int duvarBoyutu = kareBoyutu * 5;

            for (int i = 0; i < 5; i++)
            {
               
                PictureBox duvarEngeliPictureBox = new PictureBox();
                duvarEngeliPictureBox.ImageLocation = duvarEngeliResimURL;
                duvarEngeliPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                duvarEngeliPictureBox.Size = new Size(duvarBoyutu, duvarBoyutu);

               
                Point rastgeleKonum = RastgeleDuvarKonumu(duvarBoyutu, kareBoyutu);

                
                duvarEngeliPictureBox.Location = rastgeleKonum;

                
                haritaPanel.Controls.Add(duvarEngeliPictureBox);

                nesneBilgileri.Add(new NesneBilgisi(rastgeleKonum, new Size(duvarBoyutu, duvarBoyutu)));
            }
        }

        private Point RastgeleDuvarKonumu(int duvarBoyutu, int kareBoyutu)
        {
            int x, y;

            do
            {
                
                x = random.Next(0, haritaPanel.Width - duvarBoyutu);
                y = random.Next(0, haritaPanel.Height - duvarBoyutu);

                
            } while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(duvarBoyutu, duvarBoyutu))) ||
                     CakismaKontrolu(new NesneBilgisi(new Point(x - 5 * kareBoyutu, y), new Size(duvarBoyutu, duvarBoyutu))) ||
                     CakismaKontrolu(new NesneBilgisi(new Point(x + 5 * kareBoyutu, y), new Size(duvarBoyutu, duvarBoyutu))));

            return new Point(x, y);
        }
    }
}