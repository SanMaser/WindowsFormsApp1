using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable()]
    abstract class Figure
    {

        public Point nach;
        public Point kon;
        public int tol1;
        protected Color solidColor;
        protected Color lineColor;
        protected int lineSize;
        public bool zalivka;
        public Figure(Point a, Point b, int lineSize, Color lineColor, Color solidColor)
        {
            this.nach = a;
            this.kon = b;
            this.lineSize = lineSize;
            this.lineColor = lineColor;
            this.solidColor = solidColor;
        }
        //public int a;
        public Color ColrFigure { set; get; }
        public Color ColrFon { set; get; }


        public abstract void Draw(Graphics g, Point offset);
        public abstract void DrawDash(Graphics g, Point offset);
        public abstract void Hide(Graphics g, Point offset);


        public void norm(ref Point a,ref Point c)
        {
            int l;
            if (a.X > c.X)
            {
                l = a.X;
                a.X = c.X;
                c.X = l;
            }
            if (a.Y > c.Y)
            {
                l = a.Y;
                a.Y = c.Y;
                c.Y = l;
            }
        }
    }
    [Serializable()]
    internal class Rect:Figure
    {
        public Rect(Point a, Point b, int lineSize, Color lineColor, Color solidColor) : base(a, b, lineSize, lineColor, solidColor) { }
        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            Brush zal= new SolidBrush(ColrFon);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            norm(ref normPointOne, ref normPointTwo);
            Rectangle r = Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            if (zalivka)
            {
                g.FillRectangle(zal, r);
            }
            
            g.DrawRectangle(pen, r);

        }
        public override void DrawDash(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            norm(ref normPointOne, ref normPointTwo);
            Rectangle r = Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            g.DrawRectangle(pen, r);
        }
        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, tol1);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            norm(ref normPointOne, ref normPointTwo);
            Rectangle r = Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            g.DrawRectangle(pen, r);
        }
    }
    [Serializable()]
    internal class line : Figure
    {
        public line(Point a, Point b, int lineSize, Color lineColor, Color solidColor) : base(a, b, lineSize, lineColor, solidColor) { }
        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            Brush zal = new SolidBrush(ColrFon);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);
            
            g.DrawLine(pen, normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);

        }
        public override void DrawDash(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

      
            g.DrawLine(pen, normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
        }
        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, tol1+1);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            
            g.DrawLine(pen, normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
        }
    }
    [Serializable()]
    internal class el : Figure
    {
        public el(Point a, Point b, int lineSize, Color lineColor, Color solidColor) : base(a, b, lineSize, lineColor, solidColor) { }
        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            Brush zal = new SolidBrush(ColrFon);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);
            norm(ref normPointOne, ref normPointTwo);
            Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            if (zalivka)
            {
                g.FillEllipse(zal, rectangle);
            }
            g.DrawEllipse(pen, rectangle);

        }
        public override void DrawDash(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            norm(ref normPointOne, ref normPointTwo);
            Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            g.DrawEllipse(pen, rectangle);
        }
        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, tol1+1);
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);

            norm(ref normPointOne, ref normPointTwo);
            Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.X, normPointOne.Y, normPointTwo.X, normPointTwo.Y);
            g.DrawEllipse(pen, rectangle);
        }
    }
    [Serializable()]
    internal class lineK : Figure
    {
        public List<Point> points = new List<Point>();
        public lineK(Point a, Point b, int lineSize, Color lineColor, Color solidColor) : base(a, b, lineSize, lineColor, solidColor) { }
        public override void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            Brush zal = new SolidBrush(ColrFon);
            Point[] r= points.ToArray() ;
            int i = 0;
            foreach (Point f in r)
            {
                r[i].X = f.X + offset.X;
                r[i].Y=f.Y + offset.Y;
                i++;
            }
            g.DrawCurve(pen,r);

        }
        public override void DrawDash(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.Black, tol1);
            pen.Color = ColrFigure;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point[] r = points.ToArray();
            Point normPointOne = new Point(nach.X + offset.X, nach.Y + offset.Y);
            Point normPointTwo = new Point(kon.X + offset.X, kon.Y + offset.Y);
            int i = 0;
            foreach (Point f in r)
            {
                r[i].X = f.X + offset.X;
                r[i].Y = f.Y + offset.Y;
                i++;
            }
            g.DrawCurve(pen, r);
        }
        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, tol1);
            Point[] r = points.ToArray();
            int i = 0;
            foreach (Point f in r)
            {
                r[i].X = f.X + offset.X;
                r[i].Y = f.Y + offset.Y;
                i++;
            }
            if (r.Length > 2)
            {
                Point[] c = r.Take(r.Length - 1).ToArray();
                g.DrawCurve(pen, c);
            }
            else
            {
                g.DrawCurve(pen, r);
            }
        }
    }
}
