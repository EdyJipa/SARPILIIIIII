using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SARPILIIIIII
{
    public partial class Form1 : Form
    {
        private List<Point> sarpe = new List<Point>(); 
        private Point mancare = Point.Empty;            
        private int directie = 0;                     
        private int scor = 0;                           
        private Random random = new Random();           

        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(TimerTick);
            this.KeyDown += new KeyEventHandler(FormKeyDown);
            IncepeJocul();
        }

        private void IncepeJocul()
        {
            sarpe.Clear();
            sarpe.Add(new Point(10, 10));
            directie = 0;              
            scor = 0;               
            GenerareMancare();
            timer1.Start();      
        }

        private void GenerareMancare()
        {
            int x = random.Next(0, this.ClientSize.Width / 10);
            int y = random.Next(0, this.ClientSize.Height / 10);
            mancare = new Point(x, y);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Point cap = sarpe[0];
            Point nouCap = Point.Empty;

            switch (directie)
            {
                case 0: nouCap = new Point(cap.X, cap.Y - 1); break;
                case 1: nouCap = new Point(cap.X + 1, cap.Y); break;
                case 2: nouCap = new Point(cap.X, cap.Y + 1); break;
                case 3: nouCap = new Point(cap.X - 1, cap.Y); break;
            }
            sarpe.Insert(0, nouCap);

            if (nouCap == mancare)
            {
                scor += 10;
                GenerareMancare();
            }
            else
            {
                sarpe.RemoveAt(sarpe.Count - 1);
            }

            if (nouCap.X < 0 || nouCap.Y < 0 || nouCap.X >= this.ClientSize.Width / 10 || nouCap.Y >= this.ClientSize.Height / 10 || sarpe.GetRange(1, sarpe.Count - 1).Contains(nouCap))
            {
                timer1.Stop();
                MessageBox.Show("Jocul s-a terminat! Scor: " + scor);
                IncepeJocul();
            }

            this.Invalidate();
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: if (directie != 2) directie = 0; break;
                case Keys.Right: if (directie != 3) directie = 1; break;
                case Keys.Down: if (directie != 0) directie = 2; break;
                case Keys.Left: if (directie != 1) directie = 3; break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (Point p in sarpe)
            {
                e.Graphics.FillRectangle(Brushes.Green, new Rectangle(p.X * 10, p.Y * 10, 10, 10));
            }

            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(mancare.X * 10, mancare.Y * 10, 10, 10));

            lblScor.Text = "Scor: " + scor;
        }
    }
}
