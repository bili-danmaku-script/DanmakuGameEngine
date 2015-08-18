using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineCore;
using EngineCore.Components;

namespace testProgram
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Y:\Documents\test\Assets\QQ20150816-1@2x.png");
        }

        private Color tint(Color origin, Color tintColor)
        {
            double red = Math.Max((double)origin.R * (double)tintColor.R / 255d, 0);
            double green = Math.Max((double)origin.G * (double)tintColor.G / 255d, 0);
            double blue = Math.Max((double)origin.B * (double)tintColor.B / 255d, 0);
            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                Bitmap test = new Bitmap(Image.FromFile(@"Y:\Documents\test\Assets\QQ20150816-1@2x.png"));
                for (int j = 0; j < test.Height; j++)
                {
                    for (int i = 0; i< test.Width; i++)
                    {
                        Color transform = test.GetPixel(i, j);
                        transform = tint(transform, colorDialog1.Color);
                        test.SetPixel(i, j, transform);
                    }
                }
                pictureBox1.Image = test;
            }
        }
    }
}
