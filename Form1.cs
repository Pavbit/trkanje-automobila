using System;
using System.Drawing;
using System.Windows.Forms;

namespace trka
{
    public partial class Form1 : Form
    {
        // polja za igru
        private Timer gameTimer = new Timer();
        private PictureBox playerCar = new PictureBox();
        private PictureBox enemyCar = new PictureBox();
        private Random rnd = new Random();
        private PictureBox roadLine1 = new PictureBox();
        private PictureBox roadLine2 = new PictureBox();
        private PictureBox coin = new PictureBox();

        public Form1()
        {
            InitializeComponent();

            // Podesi formu
            this.Width = 400;
            this.Height = 600;
            this.BackColor = Color.Gray;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);

            // Auto (igrac)
            playerCar.Size = new Size(100, 150);
            playerCar.SizeMode = PictureBoxSizeMode.StretchImage;
            playerCar.Image = Properties.Resources.carplayer;
            playerCar.Top = this.ClientSize.Height - playerCar.Height - 20;
            playerCar.Left = this.ClientSize.Width / 2 - playerCar.Width / 2;
            this.Controls.Add(playerCar);

            // Auto (bot)
            enemyCar.Size = new Size(100, 150);
            enemyCar.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyCar.Image = Properties.Resources.carbotp;
            enemyCar.Top = -150;
            enemyCar.Left = rnd.Next(0, this.ClientSize.Width - enemyCar.Width);
            this.Controls.Add(enemyCar);

            // Put
            roadLine1.Size = new Size(10, 100);
            roadLine1.BackColor = Color.White;
            roadLine1.Left = this.ClientSize.Width / 2 - 5;
            roadLine1.Top = 0;
            this.Controls.Add(roadLine1);

            roadLine2.Size = new Size(10, 100);
            roadLine2.BackColor = Color.White;
            roadLine2.Left = this.ClientSize.Width / 2 - 5;
            roadLine2.Top = -200;
            this.Controls.Add(roadLine2);

           
            gameTimer.Interval = 20; // brzina igre
            gameTimer.Tick += new EventHandler(UpdateGame);
            gameTimer.Start();

            // coin
            coin.Size = new Size(50, 50);
            coin.SizeMode = PictureBoxSizeMode.StretchImage;
            coin.Image = Properties.Resources.coin;
            coin.Top = -200;
            coin.Left = rnd.Next(0, this.ClientSize.Width - coin.Width);
            this.Controls.Add(coin);
        }

        private int speed = 5;
        int coins = 0;

        private void UpdateGame(object sender, EventArgs e)
        {
            // pomera linije
            roadLine1.Top += speed;
            roadLine2.Top += speed;

            if (roadLine1.Top > this.ClientSize.Height) roadLine1.Top = -200;
            if (roadLine2.Top > this.ClientSize.Height) roadLine2.Top = -200;

            //pomera bot auto

            enemyCar.Top += 10;

            if (enemyCar.Top > this.ClientSize.Height)
            {
                enemyCar.Top = -150;
                enemyCar.Left = rnd.Next(0, this.ClientSize.Width - enemyCar.Width);
            }

            if (playerCar.Bounds.IntersectsWith(enemyCar.Bounds))
            {
                gameTimer.Stop();
                MessageBox.Show("Slupo si se");
                this.Close();


            }

            coin.Top += 15;
            if (coin.Top > this.ClientSize.Height)
            {
                coin.Top = -200;
                coin.Left = rnd.Next(0, this.ClientSize.Width - coin.Width);
            }

      
            if (playerCar.Bounds.IntersectsWith(coin.Bounds))
            {
                coins += 1;
                lblCoins.Text = "Coins: " + coins;
                coin.Top = -200;
                coin.Left = rnd.Next(0, this.ClientSize.Width - coin.Width);
                // dodaj poene
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // pomera auto
            if (e.KeyCode == Keys.A && playerCar.Left > 0)
                playerCar.Left -= 10;
            if (e.KeyCode == Keys.D && playerCar.Right < this.ClientSize.Width)
                playerCar.Left += 10;

            if (e.KeyCode == Keys.W && playerCar.Top > 0)
                playerCar.Top -= 10;
            if (e.KeyCode == Keys.S && playerCar.Bottom < this.ClientSize.Height)
                playerCar.Top += 10;

            if (e.KeyCode == Keys.W) speed = 10;
            if (e.KeyCode == Keys.S) speed = 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

