using System.Drawing.Drawing2D;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private int haritaBoyutu;
        private Panel haritaPanel;
        private PictureBox resimPictureBox;
        private Random random = new Random();
        private Karakter karakter;
        private List<NesneBilgisi> nesneBilgileri = new List<NesneBilgisi>();

        public Form1()
        {
            InitializeComponent();

        }

        private List<Engel> engeller = new List<Engel>();

        private System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer();



        private List<Point> altinSandikKonumlari = new List<Point>();

        private int siradakiAltinSandikIndex = 0;


        private void KarakteriHareketEttir(Point hedefNokta)
        {
            Point karakterKonumu = resimPictureBox.Location;

            if (karakterKonumu.X < hedefNokta.X)
                karakterKonumu.X += 10;
            else if (karakterKonumu.X > hedefNokta.X)
                karakterKonumu.X -= 10;

            if (karakterKonumu.Y < hedefNokta.Y)
                karakterKonumu.Y += 10;
            else if (karakterKonumu.Y > hedefNokta.Y)
                karakterKonumu.Y -= 10;


            resimPictureBox.Location = karakterKonumu;


            if (karakterKonumu == hedefNokta)
            {
                siradakiAltinSandikIndex++;
                if (siradakiAltinSandikIndex < altinSandikKonumlari.Count)
                {
                    hedefNokta = altinSandikKonumlari[siradakiAltinSandikIndex];
                    MessageBox.Show((siradakiAltinSandikIndex + 1) + ". sandýða ulaþtýnýz! Sandýk konumu: " + hedefNokta.ToString());
                }
                else
                {

                    MessageBox.Show("Tüm altýn sandýklarýna ulaþýldý!");
                }
            }
        }



        private Point hedefNokta;

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Harita boyutunu girin:", "Harita Boyutu", "1000"), out haritaBoyutu) && haritaBoyutu > 0)
            {

                Form haritaFormu = new Form();
                haritaFormu.Text = "Harita";
                haritaFormu.Size = new Size(haritaBoyutu * 25, haritaBoyutu * 25);

                haritaPanel = new Panel();
                haritaPanel.Size = haritaFormu.ClientSize;

                resimPictureBox = new PictureBox();
                resimPictureBox.ImageLocation = "https://i.pinimg.com/280x280_RS/11/42/33/1142336884a1f32ddc00c31baafaf62b.jpg";
                resimPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                resimPictureBox.Size = new Size(kareBoyutu * 25, kareBoyutu * 25);


                Point konum = RastgeleKonum();
                resimPictureBox.Location = konum;


                while (CakismaKontrolu(new NesneBilgisi(konum, resimPictureBox.Size)))
                {
                    konum = RastgeleKonum();
                    resimPictureBox.Location = konum;
                }


                AltinSandiklariEkranaEkle(5);


                Point hedefNokta = altinSandikKonumlari[siradakiAltinSandikIndex];


                nesneBilgileri.Add(new NesneBilgisi(konum, resimPictureBox.Size));


                haritaPanel.Controls.Add(resimPictureBox);

                movementTimer.Interval = 1;
                movementTimer.Enabled = true;


                movementTimer.Tick += (sender, e) =>
                {
                    KarakteriHareketEttir(hedefNokta);
                };


                EkranaKisAgaciEkle();


                EkranaYazAgaciEkle();


                EkranaKisKayasiEkle();


                EkranaYazKayasiEkle();


                EkranaKisDagiEkle();


                EkranaYazDagiEkle();


                EkranaDuvarEngeliEkle();




                for (int i = 0; i < 3; i++)
                {
                    HareketliNesneler.EkranaAriEkle(haritaPanel, nesneBilgileri, random);
                }



                for (int i = 0; i < 3; i++)
                {
                    HareketliNesneler.EkranaKusEkle(haritaPanel, nesneBilgileri, random);
                }



                EkranaGumusSandikEkle();


                EkranaBakirSandikEkle();


                EkranaZumrutSandikEkle();




                haritaFormu.Controls.Add(haritaPanel);


                haritaPanel.Paint += HaritaPanel_Paint;


                haritaFormu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Geçersiz harita boyutu!");
            }
        }
        private void EkranaKisAgaciEkle()
        {

            string kisAgaciResimURL = "https://img.pixers.pics/pho_wat(s3:700/FO/46/36/36/68/700_FO46363668_8291362166d95a8f59d4625f543caac8.jpg,700,700,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,650,jpg)/cikartmalar-kis-agac.jpg.jpg";

            for (int i = 0; i < 3; i++)
            {


                PictureBox kisAgaciPictureBox = new PictureBox();
                kisAgaciPictureBox.ImageLocation = kisAgaciResimURL;
                kisAgaciPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int agacBoyutu = kareBoyutu * 60;


                kisAgaciPictureBox.Size = new Size(agacBoyutu, agacBoyutu);


                int x = random.Next(0, haritaPanel.Width / 2 - agacBoyutu);
                int y = random.Next(0, haritaPanel.Height - agacBoyutu);

                // Çakýþma kontrolü yap
                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width / 2 - agacBoyutu);
                    y = random.Next(0, haritaPanel.Height - agacBoyutu);
                }


                kisAgaciPictureBox.Location = new Point(x, y);


                haritaPanel.Controls.Add(kisAgaciPictureBox);


                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(agacBoyutu, agacBoyutu)));

            }

        }

        private void EkranaYazAgaciEkle()
        {

            string yazAgaciResimURL = "https://img.pixers.pics/pho_wat(s3:700/FO/27/88/61/50/700_FO27886150_be0011c74558f05b866408dc57ce1535.jpg,635,700,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,415,650,jpg)/duvar-resimleri-yaz-soyut-cicek-agac.jpg.jpg";

            for (int i = 0; i < 3; i++)
            {


                PictureBox yazAgaciPictureBox = new PictureBox();
                yazAgaciPictureBox.ImageLocation = yazAgaciResimURL;
                yazAgaciPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int agacBoyutu = kareBoyutu * 60;


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


        private void EkranaKisKayasiEkle()
        {

            string kisKayasiResimURL = "https://w7.pngwing.com/pngs/657/437/png-transparent-rock-dry-land-rock-dry-land-animation.png";

            for (int i = 0; i < 5; i++)
            {


                PictureBox kisKayasiPictureBox = new PictureBox();
                kisKayasiPictureBox.ImageLocation = kisKayasiResimURL;
                kisKayasiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int kayaBoyutu = kareBoyutu * 30;


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

        private void EkranaYazKayasiEkle()
        {

            string yazKayasiResimURL = "https://w7.pngwing.com/pngs/746/66/png-transparent-cartoon-rock-illustration-cartoon-painted-mountain-rock-watercolor-painting-cartoon-character-purple.png";

            for (int i = 0; i < 5; i++)
            {


                PictureBox yazKayasiPictureBox = new PictureBox();
                yazKayasiPictureBox.ImageLocation = yazKayasiResimURL;
                yazKayasiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int kayaBoyutu = kareBoyutu * 30;


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


        private void EkranaKisDagiEkle()
        {

            string kisDagiResimURL = "https://png.pngtree.com/png-vector/20240216/ourlarge/pngtree-snow-mountain-3d-cartoon-graphic-png-image_11746296.png"; // Kýþ Daðý resmi URL'sini güncelleyin

            for (int i = 0; i < 2; i++)
            {


                PictureBox kisDagiPictureBox = new PictureBox();
                kisDagiPictureBox.ImageLocation = kisDagiResimURL;
                kisDagiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int dagBoyutu = kareBoyutu * 90;


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

        private void EkranaYazDagiEkle()
        {

            string yazDagiResimURL = "https://e7.pngegg.com/pngimages/539/618/png-clipart-mountain-cartoon-snow-mountain-angle-triangle.png"; // Yaz Daðý resmi URL'sini güncelleyin

            for (int i = 0; i < 2; i++)
            {


                PictureBox yazDagiPictureBox = new PictureBox();
                yazDagiPictureBox.ImageLocation = yazDagiResimURL;
                yazDagiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int dagBoyutu = kareBoyutu * 90;


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


        private void EkranaDuvarEngeliEkle()
        {

            string duvarEngeliResimURL = "https://media.istockphoto.com/id/940685622/tr/vekt%C3%B6r/%C3%A7izgi-film-el-bo%C4%9Fulmak-turuncu-ger%C3%A7ek%C3%A7i-sorunsuz-tu%C4%9Fla-duvar-doku.jpg?s=612x612&w=0&k=20&c=osFI0thpHQ1EaeGfFooO4qDB1JPqGWcESaeg6ZQJp9Y="; // Duvar Engeli resmi URL'sini güncelleyin


            int kareBoyutu = haritaPanel.Width / haritaBoyutu;
            int duvarBoyutu = kareBoyutu * 60;

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



        private void EkranaGumusSandikEkle()
        {

            string gumusSandikResimURL = "https://m.media-amazon.com/images/I/81H6dn6lFlL.AC_UF1000,1000_QL80.jpg";

            int sandikSayisi = random.Next(5, 7);

            for (int i = 0; i < sandikSayisi; i++)
            {

                PictureBox gumusSandikPictureBox = new PictureBox();
                gumusSandikPictureBox.ImageLocation = gumusSandikResimURL;
                gumusSandikPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int sandikBoyutu = kareBoyutu * 60;


                gumusSandikPictureBox.Size = new Size(sandikBoyutu, sandikBoyutu);


                int x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                int y = random.Next(0, haritaPanel.Height - sandikBoyutu);


                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                    y = random.Next(0, haritaPanel.Height - sandikBoyutu);
                }


                gumusSandikPictureBox.Location = new Point(x, y);


                haritaPanel.Controls.Add(gumusSandikPictureBox);


                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu)));
            }
        }

        private void EkranaBakirSandikEkle()
        {

            string bakirSandikResimURL = "https://png.pngtree.com/png-vector/20240204/ourlarge/pngtree-opened-treasure-chest-png-image_11539174.png";

            int sandikSayisi = random.Next(5, 7);

            for (int i = 0; i < sandikSayisi; i++)
            {

                PictureBox bakirSandikPictureBox = new PictureBox();
                bakirSandikPictureBox.ImageLocation = bakirSandikResimURL;
                bakirSandikPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int sandikBoyutu = kareBoyutu * 60;


                bakirSandikPictureBox.Size = new Size(sandikBoyutu, sandikBoyutu);


                int x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                int y = random.Next(0, haritaPanel.Height - sandikBoyutu);


                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                    y = random.Next(0, haritaPanel.Height - sandikBoyutu);
                }


                bakirSandikPictureBox.Location = new Point(x, y);


                haritaPanel.Controls.Add(bakirSandikPictureBox);


                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu)));
            }
        }

        private void EkranaZumrutSandikEkle()
        {

            string zumrutSandikResimURL = "https://st3.depositphotos.com/5984660/18210/v/950/depositphotos_182108386-stock-illustration-emerald-gem-stone-vintage-color.jpg";

            int sandikSayisi = random.Next(5, 7);

            for (int i = 0; i < sandikSayisi; i++)
            {

                PictureBox zumrutSandikPictureBox = new PictureBox();
                zumrutSandikPictureBox.ImageLocation = zumrutSandikResimURL;
                zumrutSandikPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                int kareBoyutu = haritaPanel.Width / haritaBoyutu;
                int sandikBoyutu = kareBoyutu * 60;


                zumrutSandikPictureBox.Size = new Size(sandikBoyutu, sandikBoyutu);


                int x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                int y = random.Next(0, haritaPanel.Height - sandikBoyutu);


                while (CakismaKontrolu(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu))))
                {
                    x = random.Next(0, haritaPanel.Width - sandikBoyutu);
                    y = random.Next(0, haritaPanel.Height - sandikBoyutu);
                }


                zumrutSandikPictureBox.Location = new Point(x, y);


                haritaPanel.Controls.Add(zumrutSandikPictureBox);

                nesneBilgileri.Add(new NesneBilgisi(new Point(x, y), new Size(sandikBoyutu, sandikBoyutu)));
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


        private void AltinSandiklariEkranaEkle(int sandikSayisi)
        {
            for (int i = 0; i < sandikSayisi; i++)
            {

                Point yeniSandikKonumu = RastgeleSandikKonumu();


                while (SandiklarlaCakisiyorMu(yeniSandikKonumu) || DigerPictureBoxlarlaCakisiyorMu(yeniSandikKonumu))
                {
                    yeniSandikKonumu = RastgeleSandikKonumu();
                }


                altinSandikKonumlari.Add(yeniSandikKonumu);


                PictureBox altinSandikPictureBox = new PictureBox();
                altinSandikPictureBox.ImageLocation = "https://img.pixers.pics/pho_wat(s3:700/FO/49/63/74/05/700_FO49637405_a64d15975aa42b9326da9aa278628f58.jpg,700,616,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,566,jpg)/cikartmalar-altin-sikke-vektor-cizim-ile-eski-ahsap-sandik.jpg.jpg";
                altinSandikPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                altinSandikPictureBox.Size = new Size(60, 60);
                altinSandikPictureBox.Location = yeniSandikKonumu;


                haritaPanel.Controls.Add(altinSandikPictureBox);
            }
        }


        private Point RastgeleSandikKonumu()
        {
            int x = random.Next(0, haritaPanel.Width - 60);
            int y = random.Next(0, haritaPanel.Height - 60);
            return new Point(x, y);
        }


        private bool SandiklarlaCakisiyorMu(Point yeniKonum)
        {
            foreach (Point konum in altinSandikKonumlari)
            {

                if (Math.Abs(konum.X - yeniKonum.X) < 60 && Math.Abs(konum.Y - yeniKonum.Y) < 60)
                {
                    return true;
                }
            }
            return false;
        }


        private bool DigerPictureBoxlarlaCakisiyorMu(Point yeniKonum)
        {
            foreach (Control kontrol in haritaPanel.Controls)
            {
                if (kontrol is PictureBox && kontrol != resimPictureBox)
                {
                    PictureBox digerPictureBox = (PictureBox)kontrol;

                    if (Math.Abs(digerPictureBox.Location.X - yeniKonum.X) < 60 && Math.Abs(digerPictureBox.Location.Y - yeniKonum.Y) < 60)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private List<Point> AltinSandiklaraGitmeSirasi(Point karakterKonumu)
        {
            List<Point> siraliSandiklar = new List<Point>(altinSandikKonumlari);


            siraliSandiklar.Sort((a, b) => MesafeHesapla(a, karakterKonumu).CompareTo(MesafeHesapla(b, karakterKonumu)));

            return siraliSandiklar;
        }


        private double MesafeHesapla(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }




        private void MovementTimer_Tick(object sender, EventArgs e)
        {

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


        private Point RastgeleKonum()
        {
            int kareBoyutu = haritaPanel.Width / haritaBoyutu;
            int x = random.Next(0, haritaPanel.Width - kareBoyutu);
            int y = random.Next(0, haritaPanel.Height - kareBoyutu);
            return new Point(x, y);
        }


        private void HaritaPanel_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            int kareBoyutu = haritaPanel.Width / (haritaBoyutu / 8);


            Brush solYarisiBrush = new LinearGradientBrush(new Rectangle(0, 0, haritaPanel.Width / 2, haritaPanel.Height), Color.LightBlue, Color.LightBlue, LinearGradientMode.Horizontal);
            Brush sagYarisiBrush = new LinearGradientBrush(new Rectangle(haritaPanel.Width / 2, 0, haritaPanel.Width / 2, haritaPanel.Height), Color.Green, Color.Green, LinearGradientMode.Horizontal);

            g.FillRectangle(solYarisiBrush, 0, 0, haritaPanel.Width / 2, haritaPanel.Height);
            g.FillRectangle(sagYarisiBrush, haritaPanel.Width / 2, 0, haritaPanel.Width / 2, haritaPanel.Height);

            solYarisiBrush.Dispose();
            sagYarisiBrush.Dispose();


            for (int i = 0; i < haritaBoyutu; i++)
            {
                for (int j = 0; j < haritaBoyutu; j++)
                {
                    int x = i * kareBoyutu;
                    int y = j * kareBoyutu;

                    g.DrawRectangle(pen, x, y, kareBoyutu, kareBoyutu);
                }
            }

            g.Dispose();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}