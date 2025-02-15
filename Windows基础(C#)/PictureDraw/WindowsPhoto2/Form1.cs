using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPhoto2
{
    public partial class Form1 : Form
    {
        private string input = "";
        public Form1()
        {
            InitializeComponent();
        }
        //在任意地方布置画布
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 5);
           
            Color color= Color.FromArgb(255,64,200,64);
            Point point1 = new Point(20, 20);
            Point point2 = new Point(80, 80);

            graphics.DrawRectangle(pen, 300, 300, 120, 60);
            graphics.DrawEllipse(pen, 300, 300, 120, 60);

            //Brush brush = new SolidBrush(color);
            //Brush brush1 = new HatchBrush(HatchStyle.Percent75,color);
            Brush brush2=new LinearGradientBrush(point1,point2,Color.Red,color);

            LinearGradientBrush brush=new LinearGradientBrush(point1,point2,Color.Green,Color.Red);
            Font font = new Font("正楷", 24);
            string str = "渐变色字体展示+绘图如下：";
            graphics.DrawString(str, font, brush,new Point(200,200));
            brush.Dispose();
            font.Dispose();
            

            //graphics.FillEllipse(brush2, 20, 20, 100, 200);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();

            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddString(input, new FontFamily("方正舒体"), (int)FontStyle.Regular,80, new PointF(10, 20), new StringFormat());

            LinearGradientBrush brush = new LinearGradientBrush(new Point(20,20), new Point(80,80), Color.Yellow, Color.Red);
            graphics.DrawPath(Pens.Green, gp);
            graphics.FillPath(brush, gp);

            brush.Dispose();
            gp.Dispose();

        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input=textBox1.Text;
            this.Invalidate();
        }
    }
}
