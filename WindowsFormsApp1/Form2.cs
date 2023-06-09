using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form2 : Form
    {
        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;
        public Form2(Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            this.size = size;
            this.AutoScrollMinSize = size;

        }
        public string FilePathSave = System.String.Empty;
        public bool isModificated = false;
        public Size size;
        Point a;
        Point c;
        Point h;
        Point a1,c1;
        List<Figure> array;
        int l;
        bool b = false;
        Figure prem,rec;
        lineK xui;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            Form1 m = (Form1)ParentForm;
            Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            Point p1 = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            if (m.b1 == 1) 
            {
               prem = new Rect(p,p1,m.lineSize,m.lineColor,m.solidColor);
                rec = new Rect(p, p1, m.lineSize, m.lineColor, m.solidColor);
            }
            else if (m.b1 == 2)
            {
                prem = new el(p, p1, m.lineSize, m.lineColor, m.solidColor);
                rec = new el(p, p1, m.lineSize, m.lineColor, m.solidColor);
            }
            else if (m.b1 == 3)
            {
                prem = new line(p, p1, m.lineSize, m.lineColor, m.solidColor);
                rec = new line(p, p1, m.lineSize, m.lineColor, m.solidColor);
            }
            else if (m.b1 == 4)
            {
                xui = new lineK(p, p1, m.lineSize, m.lineColor, m.solidColor);
                prem = new lineK(p, p1, m.lineSize, m.lineColor, m.solidColor);
            }
            if ((e.X > size.Width) || (e.Y > size.Height))
            {
                return;
            }
            if (m.b1 == 4)
            {
                Graphics g = CreateGraphics();
                a = e.Location;
                a.X = a.X - this.AutoScrollPosition.X;
                a.Y = a.Y - this.AutoScrollPosition.Y;
                xui.points.Add(a);

                b = true;
                h = a;
                a1 = a;
            }
            else
            {
                Graphics g = CreateGraphics();
                a = e.Location;
                a.X = a.X - this.AutoScrollPosition.X;
                a.Y = a.Y - this.AutoScrollPosition.Y;
                prem.nach = a;

                b = true;
                h = a;
                a1 = a;
            }
            
            
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Form1 f = (Form1)this.MdiParent;
            if (b) { 
                c = e.Location;
                c.X=c.X - this.AutoScrollPosition.X;
                c.Y = c.Y - this.AutoScrollPosition.Y;
                if ((c.X < size.Width) && (c.Y < size.Height))
                {
                    if (f.b1 == 4)
                    {
                        xui.points.Add(c);

                        c1 = c;
                        a = a1;
                        xui.tol1 = f.lineSize;
                        xui.ColrFon = f.solidColor;
                        xui.ColrFigure = f.lineColor;
                        xui.Hide(grafx.Graphics, this.AutoScrollPosition);
                        xui.DrawDash(grafx.Graphics, this.AutoScrollPosition);

                        ;
                    }
                    else
                    {
                        prem.kon = c;

                        c1 = c;
                        a = a1;
                        prem.nach = a;

                        prem.tol1 = f.lineSize;
                        prem.ColrFigure = f.lineColor;

                        a = a1;
                        prem.nach = a;


                        rec.tol1 = f.lineSize;
                        rec.nach = a;

                        rec.kon = h;

                        if (h != c1)
                        {




                            rec.Hide(grafx.Graphics, this.AutoScrollPosition);

                            h = c1;
                            rec.kon = h;

                        }

                        prem.DrawDash(grafx.Graphics, this.AutoScrollPosition);
                    }
                    grafx.Render();

                }
                
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Point startPoint = new Point(0, 0);
            Rectangle rectangle = new Rectangle(startPoint, this.size);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            grafx.Graphics.FillRectangle(solidBrush, rectangle);
            foreach (Figure f in array)
            {
                f.Draw(grafx.Graphics, this.AutoScrollPosition);

            }
            grafx.Render(e.Graphics);
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Form1 f = (Form1)this.MdiParent;
            if (b == true)
            {
                c = e.Location;
                c.X = c.X - this.AutoScrollPosition.X;
                c.Y = c.Y - this.AutoScrollPosition.Y;
                
                    if ((c.X < size.Width) && (c.Y  < size.Height) )
                {
                    if (f.b1 == 4)
                    {


                        
                        xui.tol1 = f.lineSize;
                        xui.ColrFon = f.solidColor;
                        xui.ColrFigure = f.lineColor;
                        xui.Draw(grafx.Graphics, this.AutoScrollPosition);
                        prem = xui;
                        array.Add(prem);
                    }
                    else
                    {
                        a = a1;
                        prem.nach = a;

                        prem.kon = c;

                        prem.zalivka = f.sus;
                        prem.tol1 = f.lineSize;
                        prem.ColrFon = f.solidColor;
                        prem.ColrFigure = f.lineColor;
                        prem.Draw(grafx.Graphics, this.AutoScrollPosition);
                        array.Add(prem);
                    }
                }
                Invalidate();
                b = false;
                isModificated = true;

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModificated)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить последние изменения?", this.Text, MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    Form1 mainWindow = (Form1)this.MdiParent;

                    mainWindow.сохранитьToolStripMenuItem_Click(sender,e);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            Rectangle t = new Rectangle(0, 0, SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height);
            grafx = context.Allocate(g, t);
            Point startPoint = new System.Drawing.Point(0, 0);
            Rectangle rectangle = new System.Drawing.Rectangle(startPoint, SystemInformation.PrimaryMonitorMaximizedWindowSize);
            SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            grafx.Graphics.FillRectangle(solidBrush, rectangle);
            //grafx.Graphics.FillRectangle(Brush Color.Gray)
        }

        private void Form2_Scroll(object sender, ScrollEventArgs e)
        {
            grafx.Render();
        }

        internal List<Figure> Array { get => array; set => array = value; }

    }
}
