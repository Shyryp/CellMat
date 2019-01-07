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
    public partial class MainWindow : Form
    {
        static int im1 = 0, ip1 = 0, jm1 = 0, jp1 = 0;
        static bool thread_stop = false;
        static int square = 50; //Количество квадратов по ширине/длине
        static int space = 4; //Множитель размера графического окна   
        static Cell[,] cells = new Cell[square, square];
        static Mutex mutexProcess = new Mutex();
        Graphics gPanel; //графическая панель, куда выводистся изображение
        Thread workThread;

        public MainWindow()
        {
            InitializeComponent();
            gPanel = panelCell.CreateGraphics();
            StartConfiguration();
        }
        
        public void StartWorking()
        {
            StartConfiguration();
            RandomIn();
            workThread = new Thread(new ThreadStart(WorkAndView));
            thread_stop = false;
            workThread.Start();
        }

        public static void WorkAndView()
        {
            for(int i = 0; !thread_stop; i++)
            {
                mutexProcess.WaitOne();
                Rule();
                Reload();
                mutexProcess.ReleaseMutex();
            }
        }

        private void RandomIn()
        {
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                int[] bufRGB = { rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255) };

                cells[rand.Next(0, square), rand.Next(0, square)].colorRGB = bufRGB;
            }

        }
        private void StartConfiguration()
        {
            int[] bufRGB = { 210, 100, 35 };
            for (int i = 0; i < square; i++)
                for (int k = 0; k < square; k++)
                {
                    cells[i, k] = new Cell();
                    cells[i, k].colorRGB = bufRGB;
                }
        }
        private void Output() //Вывод в окошко
        {
            for (int i = 0; i < square; i++)
                for (int k = 0; k < square; k++)
                {
                    int[] bufRGBV = cells[i, k].colorRGB;
                    gPanel.FillRectangle(new SolidBrush(Color.FromArgb(bufRGBV[0], bufRGBV[1], bufRGBV[2])), 
                        new Rectangle(i*space, k* space, space, space));
                }
        }

        private static void Rule()
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

        private static void Reload()
        {
            for (int i = 0; i < square; i++)
                for (int j = 0; j < square; j++)
                {
                    cells[i, j].nextRGB();
                }
        }

        private void TimerProcess_Tick(object sender, EventArgs e)
        {
            mutexProcess.WaitOne();
            Output();
            mutexProcess.ReleaseMutex();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread_stop = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            thread_stop = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartWorking();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            Output();
            Rule();
            Reload();
        }
    }
}
