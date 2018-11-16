using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klet
{
    public partial class Form1 : Form
    {
        int im1 = 0, ip1 = 0, jm1 = 0, jp1 = 0;
        bool thread_stop = false;
        static int square = 50;
        Graphics gPanel;
        Thread workAndViewThread;
        Cell[,] cells = new Cell[square, square];
        public Form1()
        {
            InitializeComponent();
        }
        
        public void startWorking()
        {
            gPanel = panelKlet.CreateGraphics();
            startConfiguration();
            randomIn();
            workAndViewThread = new Thread(new ThreadStart(workAndView));
            thread_stop = false;
            workAndViewThread.Start();
        }

        public void workAndView()
        {

            for(int i = 0; !thread_stop; i++)
            {
                output();
                rule();
                reload();
                Thread.Sleep(100);
            }
        }

        private void randomIn()
        {
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                int[] bufRGB = { rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255) };

                cells[rand.Next(0, square), rand.Next(0, square)].colorRGB = bufRGB;
            }

        }
        private void startConfiguration()
        {
            int[] bufRGB = { 210, 100, 35 };
            for (int i = 0; i < square; i++)
                for (int k = 0; k < square; k++)
                {
                    cells[i, k] = new Cell();
                    cells[i, k].colorRGB = bufRGB;
                }
        }
        private void output()
        {
            for (int i = 0; i < square; i++)
                for (int k = 0; k < square; k++)
                {
                    int[] bufRGBV = cells[i, k].colorRGB;
                    
                    gPanel.FillRectangle(new SolidBrush(Color.FromArgb(bufRGBV[0], bufRGBV[1], bufRGBV[2])), 
                        new Rectangle(i*4, k*4, 4, 4));
                }
            
        }

        private void rule()
        {
            for (int i = 0; i < square; i++)
                for (int j = 0; j < square; j++)
                {
                    im1 = ((i - 1) + square) % square;
                    ip1 = (i + 1) % square;
                    jm1 = ((j - 1) + square) % square;
                    jp1 = (j + 1) % square;
                    cells[i,j].colorR = (((cells[im1, jm1].colorR + cells[i, jm1].colorR 
                        + cells[ip1, jm1].colorR + cells[im1, j].colorR + cells[ip1, j].colorR 
                        + cells[im1, jp1].colorR + cells[i, jp1].colorR 
                        + cells[ip1, jp1].colorR) / 5 + 3)) % 255;

                    cells[i, j].colorG = (((cells[im1, im1].colorG + cells[i, im1].colorG 
                        + cells[ip1, jm1].colorG + cells[im1, j].colorG + cells[ip1, j].colorG 
                        + cells[im1, jp1].colorG + cells[i, jp1].colorG 
                        + cells[ip1, jp1].colorG) / 8 + 1)) % 255;

                    cells[i, j].colorB = (((cells[im1, jm1].colorB + cells[i, im1].colorB 
                        + cells[ip1, jm1].colorB + cells[im1, j].colorB + cells[ip1, j].colorB 
                        + cells[im1, jp1].colorB + cells[i, jp1].colorB 
                        + cells[ip1, jp1].colorB) / 10 + 5)) % 255;
                }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread_stop = true;
        }

        private void reload()
        {
            for (int i = 0; i < square; i++)
                for (int j = 0; j < square; j++)
                {
                    cells[i, j].nextRGB();
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            startWorking();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            output();
            rule();
            reload();
        }
    }
}
