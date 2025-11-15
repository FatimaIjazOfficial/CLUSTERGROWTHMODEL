using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CLUSTERGROWTHMODEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Generic cluster growth method
        private void StartCluster(int size, Point offset, Color color, bool isDLA)
        {
            bool[,] occupied = new bool[size, size];
            bool[,] perimeter = new bool[size, size];
            occupied[size / 2, size / 2] = true;

            Graphics g = CreateGraphics();
            SolidBrush sb = new SolidBrush(color);
            Timer timer = new Timer();
            timer.Interval = 10;
            Random rnd = new Random();

            timer.Tick += (s, ev) =>
            {
                // Update perimeter
                bool[,] newPerimeter = new bool[size, size];
                for (int i = 1; i < size - 1; i++)
                {
                    for (int j = 1; j < size - 1; j++)
                    {
                        if (occupied[i, j])
                        {
                            if (!occupied[i + 1, j]) newPerimeter[i + 1, j] = true;
                            if (!occupied[i - 1, j]) newPerimeter[i - 1, j] = true;
                            if (!occupied[i, j + 1]) newPerimeter[i, j + 1] = true;
                            if (!occupied[i, j - 1]) newPerimeter[i, j - 1] = true;
                        }
                    }
                }
                perimeter = newPerimeter;

                int x, y;
                if (isDLA)
                {
                    // Corrected: start walker from boundary instead of anywhere
                    int edge = rnd.Next(4);
                    switch (edge)
                    {
                        case 0: x = 0; y = rnd.Next(size); break;           // left edge
                        case 1: x = size - 1; y = rnd.Next(size); break;    // right edge
                        case 2: x = rnd.Next(size); y = 0; break;           // top edge
                        default: x = rnd.Next(size); y = size - 1; break;   // bottom edge
                    }

                    // Random walk until hitting perimeter
                    while (!perimeter[x, y])
                    {
                        double r = rnd.NextDouble();
                        if (r < 0.25 && x > 0) x--;
                        else if (r >= 0.25 && r < 0.5 && x < size - 1) x++;
                        else if (r >= 0.5 && r < 0.75 && y > 0) y--;
                        else if (y < size - 1) y++;
                    }
                }
                else
                {
                    // Random perimeter selection (ECGM)
                    List<Point> perimeterPoints = new List<Point>();
                    for (int i = 1; i < size - 1; i++)
                    {
                        for (int j = 1; j < size - 1; j++)
                        {
                            if (perimeter[i, j]) perimeterPoints.Add(new Point(i, j));
                        }
                    }
                    if (perimeterPoints.Count == 0) return;
                    Point chosen = perimeterPoints[rnd.Next(perimeterPoints.Count)];
                    x = chosen.X;
                    y = chosen.Y;
                }

                occupied[x, y] = true;
                int scale = 1; 
                g.FillEllipse(sb, offset.X + x * scale, offset.Y - y * scale, 5, 5);
            };

            timer.Start();
        }

        private void dLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DLA on the left side
            StartCluster(300, new Point(250, 650), Color.DeepSkyBlue, true);
        }

        private void eCGMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ECGM on the right side
            StartCluster(300, new Point(700, 650), Color.PaleVioletRed, false);
        }
    }
}
