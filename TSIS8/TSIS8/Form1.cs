using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSIS8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap b = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(b);
            pictureBox2.Image = b;
            GraphicsPath gp = new GraphicsPath();
            GraphicsPath gp1 = new GraphicsPath();
            GraphicsPath gp2 = new GraphicsPath();
            GraphicsPath gp3 = new GraphicsPath();

            gp.AddEllipse(20, 50, 30, 30);
            gp.AddEllipse(200, 30, 30, 30);
            gp.AddEllipse(350, 70, 30, 30);
            gp.AddEllipse(500, 100, 30, 30);
            gp.AddEllipse(30, 300, 30, 30);
            gp.AddEllipse(200, 250, 30, 30);
            gp.AddEllipse(400, 130, 30, 30);
            gp.AddEllipse(550, 300, 30, 30);
            g.FillPath(new Pen(Color.White).Brush, gp);

            gp1.AddPolygon(new Point[]
            {
                new Point(120, 120),
                new Point(170, 170),
                new Point(80, 170)
            });
            g.FillPath(new Pen(Color.Red).Brush, gp1);
            gp1.AddPolygon(new Point[]
            {
                new Point(120, 180),
                new Point(170, 140),
                new Point(80, 140)
            });
            g.FillPath(new Pen(Color.Red).Brush, gp1);

            gp2.AddRectangle(new Rectangle(200, 100, 40, 40));
            g.FillPath(new Pen(Color.Green).Brush, gp2);

            gp3.AddPolygon(new Point[]
            {
                new Point(220, 110),
                new Point(200, 120),
                new Point(210, 110)
            });
            g.FillPath(new Pen(Color.Yellow).Brush, gp3);
        }
    }
}
