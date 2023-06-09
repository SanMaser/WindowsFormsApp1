using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Color solidColor = Color.White;
        public Color lineColor = Color.Black;
        public int lineSize = 1;
        public int b1 =1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = CreateGraphics();
                string s = e.X.ToString();
                string c = e.Y.ToString();
                g.DrawString(s + " " + c, new Font("Times New Roman", 8),
                new SolidBrush(Color.Black), new Point(e.X, e.Y));
            }
            else
            {
                Graphics g = CreateGraphics();
                MessageBox.Show("очистка", "нажата правая кнопка");
                g.Clear(Color.White);
            }
        }



        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();


            for (int i = 0; i < this.MdiChildren.Length; ++i)
            {
                Form2 canvas = (Form2)this.MdiChildren[i];
                if (canvas.FilePathSave == openFileDialog.FileName)
                {
                    MessageBox.Show("Файл с данным именем уже открыт!");
                    return;
                }
            }


            if (dialogResult == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Figure> array = (List<Figure>)formatter.Deserialize(stream);
                stream.Close();

                Form2 canvas = new Form2(j)
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                this.сохранитьToolStripMenuItem.Enabled = true;
                this.сохранитьКакToolStripMenuItem.Enabled = true;

                f.Show();
            }
        }

        private void окноToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form2(j);
            f.MdiParent = this;
            f.Text = "Рисунок " + this.MdiChildren.Length.ToString();
            f.Show();
        }
      
        public void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 canvas = (Form2)this.ActiveMdiChild;

            if (canvas.FilePathSave == "")
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            } canvas = (Form2)this.ActiveMdiChild;

            if (canvas.FilePathSave == "")
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "pic",
                Title = "Сохранить",
                FileName = "Изображение",
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                Form2 canvas = (Form2)this.ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }
        }

        private void цветЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
            }
        }

        private void толщинаЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSizeForm lineSize = new LineSizeForm();

            lineSize.SetSize(this.lineSize);
            if (lineSize.ShowDialog() == DialogResult.OK)
            {
                this.lineSize = lineSize.GetSize();
            }
        }
        public Size j=new Size(320,240);
        private void размерОкнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Form4 x = new Form4();
            if(x.ShowDialog()==DialogResult.OK)
            {
                j = x.size;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (прямоугольникToolStripMenuItem.Checked==true)
            {
                b1 = 1;
                элипсToolStripMenuItem.Checked = false;
                прямаяЛинияToolStripMenuItem.Checked=false;
                линияToolStripMenuItem.Checked = false;
            }
        }

        private void элипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (элипсToolStripMenuItem.Checked == true)
            {
                b1 = 2;
                прямаяЛинияToolStripMenuItem.Checked = false;
                линияToolStripMenuItem.Checked = false;
                прямоугольникToolStripMenuItem.Checked = false;
            }
        }

        private void прямаяЛинияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (прямаяЛинияToolStripMenuItem.Checked == true)
            {
                b1 = 3;
                линияToolStripMenuItem.Checked = false;
                прямоугольникToolStripMenuItem.Checked = false;
                элипсToolStripMenuItem.Checked = false;
            }
        }

        private void линияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (линияToolStripMenuItem.Checked == true)
            {
                b1 = 4;
                прямоугольникToolStripMenuItem.Checked = false;
                элипсToolStripMenuItem.Checked = false;
                прямаяЛинияToolStripMenuItem.Checked = false;
            }
        }
        public bool sus=false;
        private void заливкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(заливкаToolStripMenuItem.Checked== true)
            {
                sus=true;
            }
            else
            {
                sus = false;
            }
        }
    }
}

