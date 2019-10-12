using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperCaptcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap CaptchaToImage(string text, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, bmp.Width, bmp.Height);
            Font font = new Font("Tahoma", 25);
            sb = new SolidBrush(Color.Black);
            g.DrawString(text, font, sb, bmp.Width / 2 - (text.Length / 2) * font.Size, (bmp.Height / 2) - font.Size);
            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                sb = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(sb, rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), 4, 2);
                count++;
            }
            count = 0;
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Bisque), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height));
                count++;
            }
            return bmp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int minLenght = 6;
            int maxLenght = 8;

            string charAvailable = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder captcha = new StringBuilder();
            Random rdm = new Random();

            int captchaLenght = rdm.Next(minLenght, maxLenght + 1);

            while (captchaLenght-- > 0)
                captcha.Append(charAvailable[rdm.Next(charAvailable.Length)]);

            txtCaptcha.Text = captcha.ToString();
            picCaptcha.Image = CaptchaToImage(txtCaptcha.Text, picCaptcha.Width, picCaptcha.Height);
        }
        public string RandomString()
        {
            Random rnd = new Random();
            int number = rnd.Next(10000, 99999);
            return MD5(number.ToString()).ToUpperInvariant().Substring(0, 6);
        }
        public string MD5(string input)
        {
            using (System.Security.Cryptography.MD5CryptoServiceProvider cryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                byte[] hashedBytes = cryptoServiceProvider.ComputeHash(UnicodeEncoding.Unicode.GetBytes(input));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter captcha.");
            }
            else if (textBox1.Text == txtCaptcha.Text)
            {
                MessageBox.Show("You are not a robot !");
            }
            else
            {
                MessageBox.Show("Wrong captcha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            int minLenght = 8;
            int maxLenght = 12;

            string charAvailable = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder password = new StringBuilder();
            Random rdm = new Random();

            int passwordLenght = rdm.Next(minLenght, maxLenght + 1);

            while (passwordLenght-- > 0)
                password.Append(charAvailable[rdm.Next(charAvailable.Length)]);

            txtCaptcha.Text = password.ToString();
            picCaptcha.Image = CaptchaToImage(txtCaptcha.Text, picCaptcha.Width, picCaptcha.Height);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter captcha.");
                }
                else if (textBox1.Text == txtCaptcha.Text)
                {
                    MessageBox.Show("You are not a robot !");
                }
                else
                {
                    MessageBox.Show("Wrong captcha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.buymeacoffee.com/PaLit59Ce");
        }
    }
}
