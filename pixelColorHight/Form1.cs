using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Globalization;

namespace pixelColorHight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        Graphics g;
        Bitmap bmp = new Bitmap("img.png");
        Color c1;
        int ccode = 0;
        int c1code = 0;

        int dimensiune = 1;

        Color lowerBound = Color.FromArgb(0, 0, 0);
        Color upperBound = Color.FromArgb(255, 89, 89);

        Color pixelColor;

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
          
           
            panel1.BackgroundImage = bmp;
            
        }


        public void selectPixelsRange()
        {
            for (int x = 0; x < bmp.Height; x+= dimensiune)
            {
                for (int y = 0; y < bmp.Width; y+= dimensiune)
                {
                     pixelColor = bmp.GetPixel(y,x);
                    if (pixelColor.R >= lowerBound.R && pixelColor.G >= lowerBound.G && pixelColor.B >= lowerBound.B &&
                        pixelColor.R <= upperBound.R && pixelColor.G <= upperBound.G && pixelColor.B <= upperBound.B)
                    {


                        //do nothing
                        //or
                        //g.DrawLine(new Pen(pixelColor), y, x, y +1, x +1);
                        //g.DrawRectangle(new Pen(Color.White), y, x, dimensiune, dimensiune);
                       // g.FillRectangle(new SolidBrush(Color.White), y, x, dimensiune, dimensiune);
                    }
                    else
                    {
                        //delete the pixel is not in range
                        //bmp.SetPixel(y, x, Color.White);
                        //g.DrawLine(new Pen(pixelColor), y,x, y+1,x+1);
                        //g.DrawLine(new Pen(Color.White), y,x, y-1,x-1);
                        // g.DrawLine(new Pen(pixelColor), y, x, y + 10, x + 10);
                        // g.DrawRectangle(new Pen(pixelColor),y,x, dimensiune, dimensiune);
                        //g.FillRectangle(new SolidBrush(pixelColor), y, x, dimensiune, dimensiune);
                        // g.FillRectangle(new SolidBrush(Color.White), y, x, dimensiune, dimensiune);
                        //g.FillRectangle(new SolidBrush(Color.Black), y, x, dimensiune, dimensiune);
                        g.FillRectangle(new SolidBrush(Color.White), y, x, dimensiune, dimensiune);
                    }
                    panel3.Top = panel1.Top;
                    panel3.Left = y - panel1.Top + 2 + panel1.Left;
                        
                    
                    panel2.Left = panel1.Left;
                    panel2.Top = panel1.Left+2+x+panel1.Top;
                }

            }
            //panel1.BackgroundImage = bmp;
        }

        public void selectedPIxelAlongate()
        {
            for (int i = 1; i < bmp.Height; i+= dimensiune)
            {
                for (int j = 1; j < bmp.Width; j+= dimensiune)
                {
                    Color c = bmp.GetPixel(j, i);
                    ccode = c.A + c.R + c.G + c.B;
                    if (ccode > c1code - 10 && ccode < c1code + 10)
                    {
                        g.DrawLine(new Pen(c), j, i, j + ccode / 100, i + ccode / 100);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
           selectedPIxelAlongate();
        }


        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            c1 = bmp.GetPixel(e.X,e.Y);
            c1code = c1.A + c1.R  + c1.G + c1.B;
            Text = c1code.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectPixelsRange();
        }
    }
}
