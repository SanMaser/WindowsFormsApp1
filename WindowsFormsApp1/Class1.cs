using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
[Serializable()]
abstract class Figure
{

    public Point nach;
    public Point kon;
    public int tol1;
    public void Figyra(Point a, Point b)
    {
        this.nach = a;
        this.kon = b;
    }
    //public int a;
    public Color ColrFigure { set; get; }
    public Color ColrFon { set; get; }


    public abstract void Draw(Graphics g);
    public abstract void DrawDash(Graphics g);
    public abstract void Hide(Graphics g);

}
public void norm(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            int l;
            if (x1 > x2)
            {
                l = x1;
                x1 = x2;
                x2 = l;
            }
            if (y1> y2)
            {
                l = y1;
                y1 = y2;
                y2 = l;
            }
        }