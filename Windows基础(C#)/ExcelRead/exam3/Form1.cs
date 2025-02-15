using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;

namespace exam3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "表格|*.xls;*.xlsx";//确定两种类型
            string file;
            if(fd.ShowDialog() == DialogResult.OK)
            {
                file= fd.FileName;//获取路径
                label1.Text = Path.GetFileName(file);//获取名称
                Workbook wb = new Workbook(file);// 创建一个Workbook打开Excel文件
                Worksheet ws= wb.Worksheets[0];// 创建一个Worksheet获取第一个工作表（可能要调整）
                DataTable dt = new DataTable();// 创建一个DataTable来存储数据
                int rowCount = ws.Cells.Rows.Count;
                int columnCount = ws.Cells.Columns.Count;//行列计数
                for (int i = 0; i < columnCount; i++)
                {
                    dt.Columns.Add(ws.Cells[0, i].Value.ToString());//以第一行为标题行添加到数据区
                } 
                for (int i = 1; i < rowCount; i++)//从第二行往下开始读取
                {
                    DataRow dataRow = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dataRow[j] = ws.Cells[i, j].Value;
                    }
                    dt.Rows.Add(dataRow);
                }
                dataGridView1.DataSource = dt;//将数据区添加到DataGridView控件
                wb.Dispose();//释放Workbook
            }
        }
    }
}
