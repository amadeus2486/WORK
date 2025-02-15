using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Gac;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DownLoadFile dlf = new DownLoadFile();//创建DownLoadFile对象，用于网络资源下载
        private void btnTest_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("软件下载1.txt");//打开名为“软件下载1”的文本文件，包含资源名称和URL
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);//按照文本文件的格式逐条读取
                if (line.Length == 2)//按格式分解后，正确的字符串长度应该为2
                {
                    string path = Uri.EscapeUriString(line[1]);//读取第二个字符串，即下载地址（URL）
                    string filename = Path.GetFileName(path);//一般用下载路径做文件名，可改为用第一个字符串做文件名
                    string dir = @"D:\Download";//本地的存储路径
                    ListViewItem item = listView1.Items.Add(new ListViewItem(new string[] { (listView1.Items.Count + 1).ToString(), 
                        filename, "0", "0", "0%", "0", "0", DateTime.Now.ToString(), "等待中", line[1] }));//在List中添加任务显示下载信息，进行可视化
                    int id = item.Index;
                    dlf.AddDown(path, dir, id, id.ToString());//获取路径和文件名，添加到实例中进行下载
                }
            }
            dlf.StartDown();//全部任务添加后，开始下载
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dlf.ThreadNum = 3;//线程数，不设置默认为3
            dlf.doSendMsg += SendMsgHander;//下载过程处理事件
        }
        private void SendMsgHander(DownMsg msg)//DownMsg为下载信息实例
        {
            switch (msg.Tag)//通过msg的标签来判断下载进行状态
            {
                case DownStatus.Start:
                    this.Invoke((MethodInvoker)delegate ()//添加任务后
                    {
                        listView1.Items[msg.Id].SubItems[8].Text = "开始下载";//更改状态
                        listView1.Items[msg.Id].SubItems[7].Text = DateTime.Now.ToString();//添加任务时间
                    });
                    break;
                case DownStatus.GetLength:
                    this.Invoke((MethodInvoker)delegate ()//获取连接后
                    {
                        listView1.Items[msg.Id].SubItems[3].Text = msg.LengthInfo;//下载是否完成情况
                        listView1.Items[msg.Id].SubItems[8].Text = "连接成功";//更改状态
                    });
                    break;
                case DownStatus.End://在下载结束后
                case DownStatus.DownLoad://在下载进行时
                    this.Invoke(new MethodInvoker(() =>
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            listView1.Items[msg.Id].SubItems[2].Text = msg.SizeInfo;//给出文件大小
                            listView1.Items[msg.Id].SubItems[4].Text = msg.Progress.ToString() + "%";//给出下载进度
                            listView1.Items[msg.Id].SubItems[5].Text = msg.SpeedInfo;//给出下载速度
                            listView1.Items[msg.Id].SubItems[6].Text = msg.SurplusInfo;//给出剩余下载量
                            if (msg.Tag == DownStatus.DownLoad)//嵌套中分别更改文件下载状态
                            {
                                listView1.Items[msg.Id].SubItems[8].Text = "下载中";
                            }
                            else
                            {
                                listView1.Items[msg.Id].SubItems[8].Text = "下载完成";
                            }
                            Application.DoEvents();//有文件完成下载时，不影响其他线程
                        });
                    }));
                    break;
                case DownStatus.Error:
                    this.Invoke((MethodInvoker)delegate ()//若有任务下载出现错误时暂停，其余线程继续进行下载
                    {
                        listView1.Items[msg.Id].SubItems[6].Text = "失败";//修改剩余下载量为失败
                        listView1.Items[msg.Id].SubItems[8].Text = msg.ErrMessage;//给出错误信息
                        Application.DoEvents();//其余线程继续下载
                    });
                    break;
            }
        }
    }
}
