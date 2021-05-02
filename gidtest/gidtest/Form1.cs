using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gidtest
{
    public partial class Form1 : Form
    {

        //布尔型变量，是否正在绘图
        private bool isDrawing = false;
        //绘图时记录鼠标的位置
        private Point startPoint, oldPoint;
    
    
        //当前编辑的文件名
        private string editFileName;
        //进行操作的位图
        private Image theImage;

  
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //修改窗口标题 
                this.Text = "MyDraw\t" + openFileDialog1.FileName;
                editFileName = openFileDialog1.FileName;
                theImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = Image.FromFile( openFileDialog1.FileName);
                   
               
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);
            Pen pen1 = new Pen(Color.Black, 2);

            g.DrawLine(pen1, 100, 100, 200, 200);
            this.pictureBox1.Image = bmp;
            pen1.Dispose();
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //直接用Clear函数清除绘图表面而不用像素填充
            g.Clear(Color.White);
            Pen pen1 = new Pen(Color.Black, 2);
            this.pictureBox1.Image = bmp;
            g.DrawEllipse(pen1, 50, 50, 100, 100);
            pen1.Dispose();
            g.Dispose();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //直接用Clear函数清除绘图表面而不用像素填充
            g.Clear(Color.White);
            Pen pen1 = new Pen(Color.Black, 2);
            this.pictureBox1.Image = bmp;
            g.DrawRectangle(pen1, 50, 50, 100, 200);
            pen1.Dispose();
            g.Dispose();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            isDrawing = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing == true)
            {
                oldPoint.X = e.X;
                oldPoint.Y = e.Y;
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);

                g.Clear(Color.White);
                Pen pen1 = new Pen(Color.Black, 2);

                g.DrawLine(pen1, startPoint, oldPoint);
                this.pictureBox1.Image = bmp;
                pen1.Dispose();
                g.Dispose();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            oldPoint.X = e.X;
            oldPoint.Y = e.Y;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
           
            g.Clear(Color.White);
            Pen pen1 = new Pen(Color.Black, 2);
            
            g.DrawLine(pen1, startPoint, oldPoint);
            this.pictureBox1.Image = bmp;
            pen1.Dispose();
            g.Dispose();
            isDrawing = false;

        }
    }
}
